using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace AsynchronousFindInTreeList {
    public class AsyncSearchHelper {
        public event EventHandler AsyncOperationIsComplete;
        TreeList _treeList;
        BackgroundWorker bgwTextFinder;
        static string FindText;

        public AsyncSearchHelper(TreeList treeList) {
            _treeList = treeList;
            InitializeBackgroundWorker();
        }
        public void AsyncSearch(DataTable table, string text) {
            SearchHelper h = new SearchHelper() {
                Table = table,
                FindText = text,
                KeyFieldName = _treeList.KeyFieldName,
                ParentFieldName = _treeList.ParentFieldName
            };
            _treeList.Enabled = false;
            bgwTextFinder.RunWorkerAsync(h);
        }
        void InitializeBackgroundWorker() {
            bgwTextFinder = new BackgroundWorker();
            bgwTextFinder.DoWork += new DoWorkEventHandler(bgwTextFinder_DoWork);
            bgwTextFinder.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgwTextFinder_RunWorkerCompleted);
            bgwTextFinder.WorkerReportsProgress = true;
        }
        void bgwTextFinder_DoWork(object sender, DoWorkEventArgs e) {
            SearchHelper helper = e.Argument as SearchHelper;
            List<int> searchResult = SearchInDataSet(helper.Table, helper.KeyFieldName, helper.ParentFieldName, helper.FindText);
            e.Result = searchResult;
        }
        void bgwTextFinder_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            List<int> res = e.Result as List<int>;
            if(res == null) return;
            ExpandingToSpecificNode iterator = new ExpandingToSpecificNode(res);
            new Thread(new ThreadStart(() => {
                _treeList.BeginUpdate();
                try {
                    _treeList.NodesIterator.DoOperation(iterator);
                }
                finally {
                    _treeList.Invoke(new MethodInvoker(() => {
                        _treeList.EndUpdate();
                        _treeList.Enabled = true;
                        this.RaiseAsyncOperationIsComplete();
                        iterator.SelectedNode.Selected = true;
                    }));
                }
            }
            )).Start();
        }
        List<int> SearchInDataSet(DataTable table, string keyFieldName, string parentFieldName, string findText) {
            if(table == null || keyFieldName == null || parentFieldName == null || findText == null) return null;
            FindText = findText;
            List<int> result = new List<int>();
            DataRow foundRow = table.AsEnumerable().ToList().Find(FindRow);
            if(foundRow != null) {
                int id = Convert.ToInt32(foundRow.Field<double>(keyFieldName));
                while(id != 0) {
                    result.Add(id);
                    IEnumerable<DataRow> query =
                        from product in table.AsEnumerable()
                        where product.Field<double>(keyFieldName) == id
                        select product;
                    id = Convert.ToInt32(query.ToArray()[0].Field<double>(parentFieldName));
                }
            }
            else {
                Console.WriteLine("Nothing was found...");
                return null;
            }
            result.Sort();
            return result;
        }
        
        static bool FindRow(DataRow row) {
            List<string> colNames = new List<string>();
            foreach(var item in row.ItemArray) {
                if(item.ToString().Equals(FindText))
                    return true;
            }
            return false;
        }
        void RaiseAsyncOperationIsComplete() {
            if(AsyncOperationIsComplete != null) {
                AsyncOperationIsComplete(this, new EventArgs());
            }
        }
    }
}
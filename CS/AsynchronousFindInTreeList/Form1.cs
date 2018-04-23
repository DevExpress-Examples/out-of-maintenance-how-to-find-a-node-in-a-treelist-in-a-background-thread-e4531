using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using DevExpress.XtraSplashScreen;

namespace AsynchronousFindInTreeList {
    public partial class Form1 : Form {
        AsyncSearchHelper helper;
        public Form1() {
            InitializeComponent();
            helper = new AsyncSearchHelper(treeList1);
            helper.AsyncOperationIsComplete += new EventHandler(helper_AsyncOperationIsComplete);
        }

        void helper_AsyncOperationIsComplete(object sender, EventArgs e) {
            if(SplashScreenManager.Default != null)
                SplashScreenManager.CloseForm();
        }

        private void Form1_Load(object sender, EventArgs e) {
            DataTable dt = DataHelper.GetDataTable();
            if(dt.Rows.Count == 0) {
                DialogResult result = MessageBox.Show("Would you like to generate data?", "DataTable is empty", MessageBoxButtons.YesNo);
                if(result == System.Windows.Forms.DialogResult.Yes) {
                    SplashScreenManager.ShowForm(typeof(SplashScreen1));
                    //DataHelper.GenegateData(records_count, interval_for_new_root_node);
                    DataHelper.GenegateData(5000, 20);
                    CustomizeTreeListFields();
                    treeList1.DataSource = DataHelper.GetDataTable();
                    SplashScreenManager.CloseForm();
                }
                else {
                    MessageBox.Show("DataTable is empty");
                }
            }
            else {
                CustomizeTreeListFields();
                treeList1.DataSource = dt;
            }
        }
        void CustomizeTreeListFields() {
            treeList1.KeyFieldName = "ID";
            treeList1.ParentFieldName = "PARENTID";
            treeList1.ImageIndexFieldName = "IMAGEINDEX";
        }

        private void simpleButton1_Click(object sender, EventArgs e) {
            SplashScreenManager.ShowForm(typeof(WaitForm1));
            helper.AsyncSearch(DataHelper.GetDataTable(), textEdit1.Text);
        }
    }
}

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
using DevExpress.XtraTreeList.Nodes.Operations;

namespace AsynchronousFindInTreeList {
    public class SearchHelper {
        public DataTable Table { get; set; }
        public string KeyFieldName { get; set; }
        public string ParentFieldName { get; set; }
        public string FindText { get; set; }
    }
}

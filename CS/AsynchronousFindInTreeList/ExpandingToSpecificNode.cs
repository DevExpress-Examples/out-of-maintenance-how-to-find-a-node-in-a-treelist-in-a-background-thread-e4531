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
    public class ExpandingToSpecificNode : TreeListOperation {
        List<int> _idsToExpand;
        int currentNodeIndexInList;
        bool needsVisitChildren;
        public TreeListNode SelectedNode { get; set; }
        public ExpandingToSpecificNode(List<int> idsToExpand)
            : base() {
                needsVisitChildren = true;
            currentNodeIndexInList = 0;
            SelectedNode = null;
            _idsToExpand = idsToExpand;
        }
        public override void Execute(TreeListNode node) {
            if(currentNodeIndexInList > _idsToExpand.Count - 1) {
                return;
            }
            int idColumnValue = Convert.ToInt32(node.GetValue("ID"));
            if(idColumnValue == _idsToExpand[currentNodeIndexInList]) {
                node.Expanded = true;
                currentNodeIndexInList++;
                if(currentNodeIndexInList >= _idsToExpand.Count) {
                    SelectedNode = node;
                    needsVisitChildren = false;
                }
            }
        }
        public override bool NeedsVisitChildren(TreeListNode node) {
            return true;
        }
        public override bool NeedsFullIteration { get { return needsVisitChildren; } }
    }
}

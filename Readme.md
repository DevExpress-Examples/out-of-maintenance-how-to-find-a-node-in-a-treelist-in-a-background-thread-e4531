<!-- default file list -->
*Files to look at*:

* [AsyncSearchHelper.cs](./CS/AsynchronousFindInTreeList/AsyncSearchHelper.cs) (VB: [AsyncSearchHelper.vb](./VB/AsynchronousFindInTreeList/AsyncSearchHelper.vb))
* [DataHelper.cs](./CS/AsynchronousFindInTreeList/DataHelper.cs) (VB: [DataHelper.vb](./VB/AsynchronousFindInTreeList/DataHelper.vb))
* [ExpandingToSpecificNode.cs](./CS/AsynchronousFindInTreeList/ExpandingToSpecificNode.cs) (VB: [ExpandingToSpecificNode.vb](./VB/AsynchronousFindInTreeList/ExpandingToSpecificNode.vb))
* [Form1.cs](./CS/AsynchronousFindInTreeList/Form1.cs) (VB: [Form1.vb](./VB/AsynchronousFindInTreeList/Form1.vb))
* [Program.cs](./CS/AsynchronousFindInTreeList/Program.cs) (VB: [Program.vb](./VB/AsynchronousFindInTreeList/Program.vb))
* [SearchHelper.cs](./CS/AsynchronousFindInTreeList/SearchHelper.cs) (VB: [SearchHelper.vb](./VB/AsynchronousFindInTreeList/SearchHelper.vb))
* [SplashScreen1.cs](./CS/AsynchronousFindInTreeList/SplashScreen1.cs) (VB: [SplashScreen1.vb](./VB/AsynchronousFindInTreeList/SplashScreen1.vb))
* [WaitForm1.cs](./CS/AsynchronousFindInTreeList/WaitForm1.cs) (VB: [WaitForm1.vb](./VB/AsynchronousFindInTreeList/WaitForm1.vb))
<!-- default file list end -->
# How to find a node in a TreeList in a background thread


<p>This example demonstrates how to find a specific node in TreeList in a separate thread.</p><p>Please note that the approach shown in the project is very specific.</p><p>Searching for nodes in a separate thread works correctly only when TreeList is disabled. We do not recommend you enable TreeList during searching because any user activity with TreeList can cause unexpected effects.</p>

<br/>



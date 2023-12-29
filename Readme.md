<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/Controllers/HomeController.vb))
* [Global.asax.cs](./CS/Global.asax.cs) (VB: [Global.asax.vb](./VB/Global.asax.vb))
* [ArticleModel.cs](./CS/Models/ArticleModel.cs) (VB: [ArticleModel.vb](./VB/Models/ArticleModel.vb))
* [CategoryModel.cs](./CS/Models/CategoryModel.cs) (VB: [CategoryModel.vb](./VB/Models/CategoryModel.vb))
* [IXpoController.cs](./CS/Models/IXpoController.cs) (VB: [IXpoController.vb](./VB/Models/IXpoController.vb))
* [XpoHelper.cs](./CS/Models/XpoHelper.cs) (VB: [XpoHelper.vb](./VB/Models/XpoHelper.vb))
* [XpoModelBinder.cs](./CS/Models/XpoModelBinder.cs) (VB: [XpoModelBinder.vb](./VB/Models/XpoModelBinder.vb))
* [GridViewPartial.cshtml](./CS/Views/Home/GridViewPartial.cshtml)
* [Index.cshtml](./CS/Views/Home/Index.cshtml)
<!-- default file list end -->
# How to bind the ComboBox column to XPO Objects in the GridView extension


<p>The example illustrates how to create an application that utilizes the XPO framework in a manner described in the <a href="https://www.devexpress.com/Support/Center/p/K18525">How to use XPO in an ASP.NET MVC application</a> article.<br />
Using <a href="http://documentation.devexpress.com/#XPO/CustomDocument3113"><u>Property Descriptors</u></a> it is possible to get a correct key value from the XPO association and then select a correct item in a combobox editor. When a user posts changes to the server, a selected item value is posted as a custom argument, and then utilized in the Controller update/insert Action.</p>

<br/>



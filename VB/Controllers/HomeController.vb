Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Data
Imports DevExpress.Web.Mvc
Imports DevExpress.Xpo
Imports Xpo = DevExpress.Xpo

Namespace Example.Controllers
    Public Class HomeController
        Inherits Controller
        Implements IXpoController

        Private privateXpoSession As Session
        Public ReadOnly Property XpoSession() As Session Implements IXpoController.XpoSession
            Get
                Return privateXpoSession
            End Get
        End Property

        Public Sub New()
            privateXpoSession = XpoHelper.GetNewSession()
        End Sub

        Public Function Index() As ActionResult
            ViewBag.Message = "Welcome to DevExpress Extensions for ASP.NET MVC!"
            ViewBag.combobox = GetComboBoxTable()

            Return View(GetTable())
        End Function

        Public Function GridViewPartial() As ActionResult
            ViewBag.combobox = GetComboBoxTable()

            Return PartialView(GetTable())
        End Function

        <HttpPost()> _
        Public Function InsertPartial(ByVal article As Article) As ActionResult
            Dim categoryKey As Int32 = Convert.ToInt32(Request.Params("categoryId"))
            article.Category = XpoSession.GetObjectByKey(Of Category)(categoryKey)

            article.Save()

            ViewBag.combobox = GetComboBoxTable()
            Return PartialView("GridViewPartial", GetTable())
        End Function

        <HttpPost()> _
        Public Function UpdatePartial(ByVal article As Article) As ActionResult
            Dim categoryKey As Int32 = Convert.ToInt32(Request.Params("categoryId"))
            article.Category = XpoSession.GetObjectByKey(Of Category)(categoryKey)

            article.Save()

            ViewBag.combobox = GetComboBoxTable()
            Return PartialView("GridViewPartial", GetTable())
        End Function

        <HttpPost()> _
        Public Function DeletePartial(ByVal Oid As Int32) As ActionResult
            Dim article As Article = XpoSession.GetObjectByKey(Of Article)(Oid)
            article.Delete()

            article.Save()

            ViewBag.combobox = GetComboBoxTable()
            Return PartialView("GridViewPartial", GetTable())
        End Function

        Protected Function GetTable() As XPCollection(Of Article)
            Dim collection As New XPCollection(Of Article)(XpoSession)
            collection.Sorting.Add(New SortProperty("Oid", Xpo.DB.SortingDirection.Ascending))

            Return collection
        End Function

        Protected Function GetComboBoxTable() As XPCollection(Of Category)
            Dim collection As New XPCollection(Of Category)(XpoSession)
            collection.Sorting.Add(New SortProperty("Oid", Xpo.DB.SortingDirection.Ascending))

            Return collection
        End Function
    End Class
End Namespace

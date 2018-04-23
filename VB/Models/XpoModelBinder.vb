Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports DevExpress.Web.Mvc
Imports System.Web.Mvc
Imports DevExpress.Xpo.Metadata
Imports DevExpress.Xpo
Imports System.ComponentModel

Public Class XpoModelBinder
	Inherits DevExpressEditorsBinder
	Protected Overrides Function CreateModel(ByVal controllerContext As ControllerContext, ByVal bindingContext As ModelBindingContext, ByVal modelType As Type) As Object
		Dim xpoController As IXpoController = TryCast(controllerContext.Controller, IXpoController)

		If xpoController Is Nothing Then
			Throw New InvalidOperationException("The controller does not support IXpoController interface")
		End If

		Dim classInfo As XPClassInfo = xpoController.XpoSession.GetClassInfo(modelType)
		Dim result As ValueProviderResult = bindingContext.ValueProvider.GetValue(classInfo.KeyProperty.Name)

		Return If(result Is Nothing, classInfo.CreateNewObject(xpoController.XpoSession), xpoController.XpoSession.GetObjectByKey(classInfo, result.ConvertTo(classInfo.KeyProperty.MemberType)))
	End Function
End Class
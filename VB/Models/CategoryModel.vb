Imports System
Imports DevExpress.Xpo

Public Class Category
	Inherits XPObject
	Public Sub New()
		MyBase.New()
	End Sub

	Public Sub New(ByVal session As Session)
		MyBase.New(session)
	End Sub

	Public Overrides Sub AfterConstruction()
		MyBase.AfterConstruction()
	End Sub

	<Association("Category-Articles")> _
	Public ReadOnly Property Articles() As XPCollection(Of Article)
		Get
			Return GetCollection(Of Article)("Articles")
		End Get
	End Property

	Private _Name As String
	Public Property Name() As String
		Get
			Return _Name
		End Get
		Set(ByVal value As String)
			SetPropertyValue("Name", _Name, value)
		End Set
	End Property
End Class


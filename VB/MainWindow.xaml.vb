﻿Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports DevExpress.Xpf.LayoutControl
Imports DevExpress.Xpf.Editors
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations

Namespace DXLayoutControlSample
    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            DataContext = New Contact With {.FirstName = "Carolyn", .LastName = "Baker", .Email = "carolyn.baker@example.com", .Phone = "(555)349-3010", .Address = "1198 Theresa Cir", .City = "Whitinsville", .State = "MA", .Zip = "01582"}
            InitializeComponent()
        End Sub
        Private Sub OnDataLayoutControlAutoGeneratingItem(ByVal sender As Object, ByVal e As DataLayoutControlAutoGeneratingItemEventArgs)
            If e.PropertyName = "Id" Then
                e.Cancel = True
            End If
            If e.PropertyName.ToLower().Contains("phone") Then
                Dim editor = New ButtonEdit() With {.Mask = "(000)000-0000", .MaskType = MaskType.Simple}
                editor.SetBinding(BaseEdit.EditValueProperty, New Binding(e.PropertyName))
                e.Item.Content = editor
            End If
        End Sub
        Private Sub OnDataLayoutControlAutoGeneratedGroup(ByVal sender As Object, ByVal e As DataLayoutControlAutoGeneratedGroupEventArgs)
            e.Group.View = LayoutGroupView.Group
        End Sub
    End Class
    Public Class Contact
        Public Property Id() As Integer
        <Display(GroupName := "General")> _
        Public Property FirstName() As String
        <Display(GroupName := "General")> _
        Public Property LastName() As String
        <Display(GroupName := "Contacts")> _
        Public Property Email() As String
        <Display(GroupName := "Contacts")> _
        Public Property Phone() As String
        <Display(GroupName := "Address")> _
        Public Property Address() As String
        <Display(GroupName := "Address")> _
        Public Property City() As String
        <Display(GroupName := "Address")> _
        Public Property State() As String
        <Display(GroupName := "Address")> _
        Public Property Zip() As String
    End Class
End Namespace
@Html.DevExpress().GridView(Sub(settings)
                                     settings.Name = "grid"
                                     settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "GridViewPartial"}
                                     settings.SettingsEditing.AddNewRowRouteValues = New With {.Controller = "Home", .Action = "InsertPartial"}
                                     settings.SettingsEditing.UpdateRowRouteValues = New With {.Controller = "Home", .Action = "UpdatePartial"}
                                     settings.SettingsEditing.DeleteRowRouteValues = New With {.Controller = "Home", .Action = "DeletePartial"}

                                     settings.KeyFieldName = "Oid"

                                     settings.CommandColumn.Visible = True
                                     settings.CommandColumn.ShowNewButton = True
                                     settings.CommandColumn.ShowEditButton = True
                                     settings.CommandColumn.ShowDeleteButton = True

                                     settings.Columns.Add("Oid").EditFormSettings.Visible = DefaultBoolean.False
                                     settings.Columns.Add("Name")
                                     settings.Columns.Add(Sub(column)
                                                              column.ColumnType = MVCxGridViewColumnType.ComboBox
                                                              column.FieldName = "Category!Key"

                                                              Dim properties As ComboBoxProperties = TryCast(column.PropertiesEdit, ComboBoxProperties)
                                                              properties.ValueField = "Oid"
                                                              properties.TextField = "Name"
                                                              properties.ValueType = GetType(System.Int32)
                                                              properties.DataSource = ViewBag.combobox
                                                          End Sub)

                                     settings.ClientSideEvents.BeginCallback = _
                                         "function (s, e) { " & _
                                         "    if (s.IsEditing () && s.GetEditor('Category!Key') != null) {" & _
                                         "        e.customArgs['categoryId'] = s.GetEditor('Category!Key').GetValue();" & _
                                         "    }" & _
                                         "}"

                                 End Sub).Bind(Model).GetHtml()

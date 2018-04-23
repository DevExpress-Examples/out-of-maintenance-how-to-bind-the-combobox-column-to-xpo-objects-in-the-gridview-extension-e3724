<!DOCTYPE HTML>
<html>
<head>
    <title>@ViewBag.Title</title>
    @Html.DevExpress().GetStyleSheets(
        New StyleSheet With {.ExtensionSuite = ExtensionSuite.NavigationAndLayout},
        New StyleSheet With {.ExtensionSuite = ExtensionSuite.Editors},
        New StyleSheet With {.ExtensionSuite = ExtensionSuite.GridView}
    )
    <script src="@Url.Content("~/Scripts/jquery-1.4.4.min.js")" type="text/javascript"></script>
    @Html.DevExpress().GetScripts(
        New Script With {.ExtensionSuite = ExtensionSuite.NavigationAndLayout},
        New Script With {.ExtensionSuite = ExtensionSuite.GridView},
        New Script With {.ExtensionSuite = ExtensionSuite.Editors}
    )
</head>
<body>
    @RenderBody()
</body>
</html>

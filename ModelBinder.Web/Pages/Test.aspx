<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="ModelBinder.Web.Pages.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input id="iText" type="text" value="abc" /><br />
            <button id="Send" type="submit">Send</button>
        </div>
    </form>
    <%: Styles.Render("~/Content/css") %>
    <%: Scripts.Render("~/bundles/js") %>
    <script>
        $(function () {
            $("#Send").on("click", function (e) {
                e.preventDefault();

                var vm = {
                    method: "TestFunction",
                    args: {
                        m: {
                            a: 1,
                            b: "2",
                            c: [3, 4, 5],
                            d: ["6", "7", "8"]
                        }
                    }
                };

                $.ajax({
                    type: "POST",
                    url: "Test.aspx",
                    data: vm
                }).done(function (response) {
                    console.log(response);
                }).fail(function (jqXHR, textStatus) {
                    console.log(textStatus);
                });
            });
        });
    </script>
</body>
</html>
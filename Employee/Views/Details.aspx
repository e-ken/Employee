<%@ Page Language="C#" Inherits="Employee.Details" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<meta charset="utf-8">
	<link rel="stylesheet" href="../Styles/Style.css" />
	<title>Информация о сотруднике</title>
</head>
<body>
	<form id="form1" runat="server">
		<h3>Информация о сотруднике</h3>
		<asp:Table id="table1" runat="server" cellpadding="5" cellspacing="5"></asp:Table>
		<asp:Button id="button1" runat="server" Text="Выход" OnClick="button1Clicked" />
	</form>
</body>
</html>

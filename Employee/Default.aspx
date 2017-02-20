<%@ Page Language="C#" Inherits="Employee.Default" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<meta charset="utf-8" />
	<script src="https://code.jquery.com/jquery-3.1.1.min.js" integrity="sha256-hVVnYaiADRTO2PzUGmuLJr8BLUSjGIZsDYGmIJLv2b8=" crossorigin="anonymous"></script>
	<script type="text/javascript" src="Scripts/Script.js"></script>
	<link rel="stylesheet" href="Styles/Style.css" />
	<title>Полный список сотрудников</title>
</head>
<body>
	<form id="form1" runat="server">
		<h3>Список сотрудников компании</h3>
		<asp:Table id="table1" runat="server" cellpadding="5" cellspacing="5"></asp:Table>
		<asp:Button id="button1" runat="server" Text="Добавить сотрудника" OnClick="button1Clicked" />
	</form>
</body>
</html>

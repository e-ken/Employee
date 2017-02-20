<%@ Page Language="C#" Inherits="Employee.AddEmployee" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<meta charset="utf-8">
	<script src="https://code.jquery.com/jquery-3.1.1.min.js" integrity="sha256-hVVnYaiADRTO2PzUGmuLJr8BLUSjGIZsDYGmIJLv2b8=" crossorigin="anonymous"></script>
	<script type="text/javascript" src="../Scripts/Validate.js"></script>
	<link rel="stylesheet" href="../Styles/Style.css" />
	<title>Добавление нового сотрудника</title>
</head>
<body>
	<form id="form1" runat="server">
		<h3>Добавление нового сотрудника</h3>

		<label for="field1">Фамилия <span class="require">*</span></label>
		<asp:TextBox id="field1" runat="server" MaxLength="20" placeholder="Иванов" TabIndex="1" />
		<label for="field2">Имя <span class="require">*</span></label>
		<asp:TextBox id="field2" runat="server" MaxLength="20" placeholder="Иван" TabIndex="2" />
		<label for="field3">Отчество</label>
		<asp:TextBox id="field3" runat="server" MaxLength="20" placeholder="Иванович" TabIndex="3" />
		<label for="field4">ИНН <span>*</span></label>
		<asp:TextBox id="field4" runat="server" MaxLength="12" placeholder="000000000000" TabIndex="4" />
		<label for="field5">Номер паспорта <span>*</span></label>
		<asp:TextBox id="field5" runat="server" MaxLength="10" placeholder="0000000000" TabIndex="5" />
		<label for="field6">Дата рождения <span class="require">*</span></label>
		<asp:TextBox id="field6" runat="server" MaxLength="10" placeholder="дд.мм.гггг" TabIndex="6" />
		<label for="field7">Должность</label>
		<asp:DropDownList id="field7" runat="server" TabIndex="7" />
		<div>
			<asp:Label id="field8" runat="server" Visible="false" CssClass="require"></asp:Label>
		</div>
		<asp:Button id="button1" runat="server" Text="Добавить" OnClick="button1Clicked" Enabled="false" TabIndex="8" />
		<asp:Button id="button2" runat="server" Text="Отмена" OnClick="button2Clicked" TabIndex="9" />
	</form>
</body>
</html>

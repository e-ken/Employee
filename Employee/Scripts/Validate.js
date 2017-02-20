$(document).ready(function() {
	// Вешаем обработчик клика на строку таблицы

	function checkFields() {
		var field1 = $("#field1").val(), 
			check1 = field1.match(/^[a-za-я]{2,20}$/) != null; // Фамилия
		var field2 = $("#field2").val(), 
			check2 = field2.match(/^[a-za-я]{2,20}$/) != null; // Имя
		//var field3 = $("#field3").val(); // Отчество
		var field4 = $("#field4").val(), 
			check4 = field4.match(/^\d{12}$/) != null; // ИНН
		var field5 = $("#field5").val(), 
			check5 = field5.match(/^\d{10}$/) != null; // Номер паспорта
		var field6 = $("#field6").val(), 
			check6 = field6.match(/^((0[1-9])|(1[0-9])|(2[0-9])|(3[0-1]))\.((0[1-9])|(1[0-2]))\.[1-2]\d{3}/) != null; // Дата рождения
		//var field7 = $("#field7").val(); // Должность

		if (field1.length == 0 || check1) $("#field1").removeClass("error"); else $("#field1").addClass("error");
		if (field2.length == 0 || check2) $("#field2").removeClass("error"); else $("#field2").addClass("error");
		if (field4.length == 0 || check4) $("#field4").removeClass("error"); else $("#field4").addClass("error");
		if (field5.length == 0 || check5) $("#field5").removeClass("error"); else $("#field5").addClass("error");
		if (field6.length == 0 || check6) $("#field6").removeClass("error"); else $("#field6").addClass("error");


		var check = check1 && check2 && (check4 || check5) && check6 ;
		$("#button1").attr('disabled', !check);
	}

	$("#field1").change(checkFields);
	$("#field2").change(checkFields);
	$("#field4").change(checkFields);
	$("#field5").change(checkFields);
	$("#field6").change(checkFields);

	checkFields();

}); 

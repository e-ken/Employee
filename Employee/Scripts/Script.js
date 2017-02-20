$(document).ready(function() {
	// Вешаем обработчик клика на строку таблицы
	$("#table1 > tbody tr").click(function(event) {
		var id = $(this).closest('tr').attr('id');
   		var url = "../Views/Details.aspx?id=" + id; 
 		window.location.href = url;
	});
}); 

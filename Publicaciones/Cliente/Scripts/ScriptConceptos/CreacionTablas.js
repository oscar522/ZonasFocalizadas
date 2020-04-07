///////////////////////////////////////

$(document).ready(function () {
	
////// CREACION DE TABLAS

///////////////////////////////////////
////// tabla usuarios asociados
    var oTableAsociados = $('#table_Asociados_').dataTable({
        "language": { "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json" },
        "paging": false,
        "searching": false,
        "info": false,
        "scrollX": false,
        "columnDefs": [
        {
        "targets": [ 0 ],
        "visible": false,
        "searchable": false
        }],
    });

///////////////////////////////////////
////// creacion de la tabla soporte
    var oTableSoporte = $('#table_Soporte').dataTable({
        "language": { "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json" },
        "paging": false,
        "searching": false,
        "info": false,
        "scrollX": false,
        "columnDefs": [
        {
            "targets": [ 0 ],
            "visible": false,
                "searchable": false,
            "width": "20%",
            },
        {
            "targets": [ 1 ],
            "width": "20%",
        }],
    });

///////////////////////////////////////
////// creacion de la tabla Anexo
    var oTableAnexo = $('#table_Anexo').dataTable({
        "language": { "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json" },
        "paging": false,
        "searching": false,
        "info": false,
        "columnDefs": [
        {
            "targets": [ 0 ],
            "visible": false,
            "searchable": false
        },
        {
            "targets": [ 1 ],
            "width": "20%",
        }],
    });

///////////////////////////////////////
//////creacion de la tabla table_Exp_Aso
    var oTableExp_Aso = $('#table_Exp_Aso').dataTable({
        "language": { "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json" },
        "paging": false,
        "searching": false,
        "scrollX": false,
        "info": false,
        "columnDefs": [
        {
            "targets": [ 0 ],
            "visible": false,
            "searchable": false
        },
        {
            "targets": [ 1 ],
            "width": "20%",
        }],
    });
});
///////////////////////////////////////

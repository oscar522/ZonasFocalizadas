
$(document).ready(function () {

    var tablaSoporteZ = $('#table_Soporte').DataTable();
    $('#table_Soporte tbody').on('click', 'z1', function () {
        var data = tablaSoporteZ.row($(this).parents('tr')).data();
            $.ajax({
            type: 'POST',
            url: '@Url.Action("DeleteDocumentoSoporte")',
            dataType: 'json',
            data: { key: data[0] },
            success: function (s) {
                alert(s);
                TablaSoporte();
                return false;
            },
            error: function(e){
                return false;
            }
            });
        return false;
    });

    /////////////////////////////////////
    //// tabla Anexo
    var tablaAnexoZ = $('#table_Anexo').DataTable();
    $('#table_Anexo tbody').on('click', 'z1', function () {
        var data = tablaAnexoZ.row($(this).parents('tr')).data();
            $.ajax({
            type: 'POST',
            url: '@Url.Action("DeleteDocumentoAnexo")',
            dataType: 'json',
            data: { key: data[0] },
            success: function (s) {
                alert(s);
                TablaAnexo();
                return false;
            },
            error: function(e){
                return false;
            }
        });
        return false;
    });

        /////////////////////////////////////
    //// tabla Expediente asociado
    var tablaExpedienteAsociadoZ = $('#table_Exp_Aso').DataTable();
    $('#table_Exp_Aso tbody').on('click', 'z1', function () {
        var data = tablaExpedienteAsociadoZ.row($(this).parents('tr')).data();
            $.ajax({
            type: 'POST',
            url: '@Url.Action("DeleteExpediente")',
            dataType: 'json',
            data: { key: data[0] },
            success: function (s) {
                alert(s);
                ExpedientesAsociados();
                return false;
            },
            error: function(e){
                return false;
            }
        });
        return false;
    });

        /////////////////////////////////////
    //// tabla Usuario asociado
    var tablaUsuariosAsociadoZ = $('#table_Asociados_').DataTable();
    $('#table_Asociados_ tbody').on('click', 'z1', function () {
        var data = tablaUsuariosAsociadoZ.row($(this).parents('tr')).data();
            $.ajax({
            type: 'POST',
            url: '@Url.Action("DeleteUsuariosAsociados")',
            dataType: 'json',
            data: { key: data[0] },
            success: function (s) {
                alert(s);
                UsuariosAsociados();
                return false;
            },
            error: function(e){
                return false;
            }
        });
        return false;
    });
    
});
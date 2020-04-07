
$(document).ready(function () {

///////////////////////////////////////
    ////// tabla Soporte
    function TablaSoporte () {
        $.ajax({
            type: 'POST',
            url: '@Url.Action("ConsultaDocumentoSoporte")',
            dataType: 'json',
            data: { key: $("#Id").val() },
            success: function (s) {
                oTableSoporte.fnClearTable();
                debugger;
                var Ruta = $("#RutaCon").val();
                $.each(s, function (i, obj) {
                    oTableSoporte.fnAddData([
                        obj.ID_CT_PAIS,
                        "<z1 title='Eliminar' Data='"+obj.ID_CT_PAIS+"' class='EliminaDoc' ><i class='fa fa-times'></i></z1>",
                        '<a target="_blank" href="'+ Ruta + obj.NOMBRE + '" >'+ obj.NOMBRE+' </a>'
                    ]);
                });
                return false;
            },
            error: function(e){
                oTableSoporte.fnClearTable();
                return false;
            }
        });
        return false;
    };

    ///////////////////////////////////////
    ////// tabla Anexo
    function TablaAnexo () {
        $.ajax({
            type: 'POST',
            url: '@Url.Action("ConsultaDocumentoAnexo")',
            dataType: 'json',
            data: { key: $("#Id").val() },
            success: function (s) {
                oTableAnexo.fnClearTable();
                debugger;
                var Ruta = $("#RutaCon").val();
                $.each(s, function (i, obj) {
                    oTableAnexo.fnAddData([
                        obj.ID_CT_PAIS,
                        "<z1 title='Eliminar' Data='"+obj.ID_CT_PAIS+"' class='EliminaDoc' ><i class='fa fa-times'></i></z1>",
                        '<a target="_blank" href="'+ Ruta + obj.NOMBRE + '" >'+ obj.NOMBRE+' </a>'
                    ]);
                });
                CierraPopup();
                return false;
            },
            error: function(e){
                oTableAnexo.fnClearTable();
                CierraPopup();
                return false;
            }
        });
        CierraPopup();
        return false;
    };

    ///////////////////////////////////////
    ////// tabla Expedientes Asociados
    function ExpedientesAsociados () {
        $.ajax({
            type: 'POST',
            url: '@Url.Action("ConsultaExpedientesAsociados")',
            dataType: 'json',
            data: { key: $("#Id").val() },
            success: function (s) {
                oTableExp_Aso.fnClearTable();
                debugger;
                var Ruta = $("#RutaPdf").val();
                $.each(s, function (i, obj) {
                    var array = obj.NOMBRE.split("||");
                    oTableExp_Aso.fnAddData([
                        obj.ID_CT_PAIS,
                        "<z1 title='Eliminar' Data='"+obj.ID_CT_PAIS+"' class='EliminaDoc' ><i class='fa fa-times'></i></z1>",
                        '<a target="_blank" href="'+ Ruta + array[1] + '" >'+ array[0]+' </a>'
                    ]);
                });
                CierraPopup();
                return false;
            },
            error: function(e){
                oTableExp_Aso.fnClearTable();
                CierraPopup();
                return false;
            }
        });
        CierraPopup();
        return false;
    };

    ///////////////////////////////////////
    ////// tabla Expedientes Asociados
    function UsuariosAsociados () {
        $.ajax({
            type: 'POST',
            url: '@Url.Action("ConsultaUsuariosAsociados")',
            dataType: 'json',
            data: { key: $("#Id").val() },
            success: function (s) {
                oTableAsociados.fnClearTable();
                debugger;
                $.each(s, function (i, obj) {
                    oTableAsociados.fnAddData([
                        obj.Id,
                        "<z1 title='Eliminar' Data='"+obj.id+"' class='EliminaDoc' ><i class='fa fa-times'></i></z1>",
                        obj.Rol,
                        obj.NombreAspNetUsers,
                    ]);
                });
                CierraPopup();
                return false;
            },
            error: function(e){
                oTableAsociados.fnClearTable();
                CierraPopup();
                return false;
            }
        });
        CierraPopup();
        return false;
    };

    $( "#BuscarExp" ).click(function() {

        if ($("#IdExpediente").val() != "") {
            $.ajax({
                type: 'POST',
                url: '@Url.Action("ConsultaExpediente")',
                dataType: 'json',
                data: { key: $("#IdExpediente").val() },
                success: function (s) {
                    debugger;
                    $("#NumeroExpedienteT").text(s.NumeroExpediente.toLowerCase());
                    $("#IdT").val(s.id);
                    $("#DepartamentoT").text(s.NombreIdDepto.toLowerCase());
                    $("#MunicipioT").text(s.NombreIdCiudad.toLowerCase());
                    $("#VeredaT").text(s.Vereda.toLowerCase());
                    $("#PredioT").text(s.NombrePredio.toLowerCase());
                    $("#NombreSolitanteT").text(s.NombreBeneficiario.toLowerCase());
                    $("#IdentificaciónT").text( s.Identificacion.toLowerCase());
                    CierraPopup();
                    return false;
                },
                error: function (e) {
                    oTableAnexo.fnClearTable();
                    CierraPopup();
                    return false;
                }
            });
        } else {
            $('span[data-valmsg-for="IdExpediente"]').text("* Num. Exp. Requerido para Buscar");
        }
        CierraPopup();
        return false;
    });
});

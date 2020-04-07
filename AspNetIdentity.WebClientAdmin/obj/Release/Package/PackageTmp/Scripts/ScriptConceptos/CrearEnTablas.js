$(document).ready(function () {
        rutaload  = $("#rutaload").val();
    ///////////////////////////////////////
    ////// AJAX PARA GUARDAR

    ///////////////////////////////////////
    ////// Guardar Soporte
    $("#Soporte").change(function () {
        $('#centralModalLGInfoDemoSlim').modal({backdrop: 'static', keyboard: false})
        $("#centralModalLGInfoDemoSlim").modal();
        $('#HeaderSlim').html("")
        $('#BodySlim').html('<div class="loading">Cargando ... <img src="'+rutaload+'/loader.gif" alt="loading" /></div>');
        var form = $('#CrearForm')[0];
        var Data = new FormData(form);
        $.ajax({
            type: 'POST',
            url: 'CrearSoportes', // we are calling json method
            dataType: 'json',
            enctype: 'multipart/form-data',
            processData: false,
            contentType: false,
            cache: false,
            timeout: 600000,
            data: Data,
            success: function(states) {
                $("#Id").val(states.Id);
                TablaSoporte();
                CierraPopup();
            },
            error: function (ex) {
                console.log(ex.responseText);
                CierraPopup();
            }
        });
        CierraPopup();
        return false;
    });

    ///////////////////////////////////////
    ////// Guardar Anexo
    $("#Anexo").change(function () {
        $('#centralModalLGInfoDemoSlim').modal({backdrop: 'static', keyboard: false})
        $("#centralModalLGInfoDemoSlim").modal();
        $('#HeaderSlim').html("")
        $('#BodySlim').html('<div class="loading">Cargando ... <img src="'+rutaload+'/loader.gif" alt="loading" /></div>');
        var form = $('#CrearForm')[0];
        var Data = new FormData(form);
        $.ajax({
            type: 'POST',
            url: '@Url.Action("CrearAnexo")', // we are calling json method
            dataType: 'json',
            enctype: 'multipart/form-data',
            processData: false,
            contentType: false,
            cache: false,
            timeout: 600000,
            data: Data,
            success: function(states) {
                $("#Id").val(states.Id);
                CierraPopup();
                TablaAnexo();
            },
            error: function (ex) {
                console.log(ex.responseText);
                CierraPopup();
            }
        });
        CierraPopup();
        return false;
    });

    ///////////////////////////////////////
    ////// Guardar Expediente Asociado
    $("#GuardarExpAso").click(function () {
        $('#centralModalLGInfoDemoSlim').modal({backdrop: 'static', keyboard: false})
        $("#centralModalLGInfoDemoSlim").modal();
        $('#HeaderSlim').html("")
        $('#BodySlim').html('<div class="loading">Cargando ... <img src="'+rutaload+'/loader.gif" alt="loading" /></div>');
        $("#IdExpediente").val($("#IdT").val());
        debugger;
        var form = $('#CrearForm')[0];
        var Data = new FormData(form);
        $.ajax({
            type: 'POST',
            url: '@Url.Action("CrearExpedientes")', // we are calling json method
            dataType: 'json',
            enctype: 'multipart/form-data',
            processData: false,
            contentType: false,
            cache: false,
            timeout: 600000,
            data: Data,
            success: function(states) {
                $("#Id").val(states.Id);
                ExpedientesAsociados();
                $("#IdExpediente").val("");
                CierraPopup();
            },
            error: function (ex) {
                console.log(ex.responseText);
                CierraPopup();
            }
        });
        CierraPopup();
        return false;
    });

    ///////////////////////////////////////
    ////// Guardar usuario Asociado
    $("#AsociarUser").click(function () {
        $('#centralModalLGInfoDemoSlim').modal({backdrop: 'static', keyboard: false})
        $("#centralModalLGInfoDemoSlim").modal();
        $('#HeaderSlim').html("")
        $('#BodySlim').html('<div class="loading">Cargando ... <img src="'+rutaload+'/loader.gif" alt="loading" /></div>');
        debugger;
        var form = $('#CrearForm')[0];
        var Data = new FormData(form);
        $.ajax({
            type: 'POST',
            url: '@Url.Action("CrearUsuariosAsociados")', // we are calling json method
            dataType: 'json',
            enctype: 'multipart/form-data',
            processData: false,
            contentType: false,
            cache: false,
            timeout: 600000,
            data: Data,
            success: function (states) {
                debugger;
                $("#Id").val(states.Id);
                UsuariosAsociados();
                CierraPopup();
            },
            error: function (ex) {
                console.log(ex.responseText);
                CierraPopup();
            }
        });
        CierraPopup();
        return false;
    });

});

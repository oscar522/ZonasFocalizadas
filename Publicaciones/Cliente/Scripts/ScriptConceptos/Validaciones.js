$(document).ready(function () {

	rutaload  = $("#rutaload").val();
	var pathname = window.location.href;
	var sizeArchivo = 0;
	function Barra(id,valor,Msj) {
		$("#"+id).removeAttr('style');
		$("#"+id).text(Msj);
		$("#"+id).css("width",""+valor+"");
	}

	$( "#NombrePredio" ).prop( "disabled", true );
	$("#IdCausa").change(function () {
     	if ($(this).val() == "7" || $(this).val() == "8") {
			$( "#NombrePredio" ).prop( "disabled", false );
     	}else{
			$( "#NombrePredio" ).prop( "disabled", true );
     	}
    });


    ///////////////////////////////////////
    ////// VALIDACIONES
        function validar() {


            var msnList = "Ningún dato disponible en esta tabla";

            var estado = true;

            var checksinExp = 0;
            if ($('#key2').prop('checked')) {
                checksinExp = 1;
            }

            if ($("#IdCausa").val() == "")
            {
                $('span[data-valmsg-for="IdCausa"]').text("* Requerido");
                estado = false;
            }

            if ($("#TerminoDias").val() == "")
            {
                $('span[data-valmsg-for="TerminoDias"]').text("* Requerido");
                estado = false;
            }

            if ($("#Observacion").val() == "")
            {
                $('span[data-valmsg-for="Observacion"]').text("* Requerido");
                estado = false;
            }

            var IdOrfeo = $("#IdOrfeo").val() + "1";
			var ExpList = $("#table_Exp_Aso  td").text();

            if (IdOrfeo == "1"  && checksinExp == 0 )
            {
                $('span[data-valmsg-for="IdOrfeo"]').text("* Indique el numero del Orfeo o Expediente");
                estado = false;
            } else if (IdOrfeo == "1"  && checksinExp == 1 && ExpList == msnList)
            {
                    $('span[data-valmsg-for="IdExpediente"]').text("* Indique el numero del Orfeo o un Numero de Expediente");
                estado = false;
            }
            else if (IdOrfeo != "1"  && checksinExp == 0 && ExpList == msnList)
            {
                    $('span[data-valmsg-for="IdExpediente"]').text("* Indique el  Numero de Expediente ");
                estado = false;
            }
            else if (IdOrfeo != "1"  && checksinExp == 0 && ExpList == msnList)
            {
                    $('span[data-valmsg-for="IdExpediente"]').text("* Indique el  Numero de Expediente ");
                estado = false;
            }


            //if ($("#Id").val() <= 0) {

            var SoporteList = $("#table_Soporte  td").text();
            var AnexoList = $("#table_Anexo td").text();

            if (AnexoList == msnList && SoporteList == msnList) {
                $('span[data-valmsg-for="Anexo"]').text("* Cargue un Anexo o Soporte en Pdf");
                $('span[data-valmsg-for="Soporte"]').text("* Cargue un Anexo o Soporte en Pdf");

                estado = false;
            } 


            var AsociaList = $("#table_Asociados_  td").text();

			if (AsociaList == msnList ) {
                $('span[data-valmsg-for="UserAsociado"]').text("* Asocie un Usuario ");

                estado = false;
            } 

	     	if ($("#IdCausa").val() == "7" || $("#IdCausa").val() == "8") {

	     		if ($("#NombrePredio").val() == "") {
                $('span[data-valmsg-for="NombrePredio"]').text("* Indique el Nombre de Predio");
	     		}
	     	}

            return estado;
        }
    
	///////////////////////////////////////
	////// ENVIO FORMULARIO
	    $("#CrearForm").submit(function (event) {

	        var Validacion = validar();
	        if (Validacion == true) {
	            return true;
	        } else {
	        	return false;
	        }
	        return false;
	    });

	///////////////////////////////////////
	////// CREACION DE TABLAS

		///////////////////////////////////////
		////// CONCEPTOS

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
			////// creacion de la tabla table_Exp_Aso
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

		///////////////////////////////////////
		////// GESTION

			///////////////////////////////////////
			////// tabla gestion
			    var oTableGestion = $('#table_Gestion').dataTable({
			        dom: "B<'row'<'col-sm-6'l><'col-sm-6'f>><'row'<'col-sm-12'tr>><'row'<'col-sm-5'i><'col-sm-7'<'#colvis'>p>>",
	                buttons: [
	                   	{ "extend": 'pdf', "text":'Pdf',"className": 'btn-outline-success' },
	                    { "extend": 'excel', "text":'Exc',"className": ' btn-outline-success ' },
	                    { "extend": 'print', "text":'Imp',"className": ' btn-outline-success ' }
	                ],
	                 "order": [[ 0, 'desc' ]],
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
	////// AJAX PARA GUARDAR

		///////////////////////////////////////
		////// CONCEPTO

			///////////////////////////////////////
			////// Guardar Soporte
			    $("#Soporte").change(function () {

					var extSoporte = $("#Soporte").val().split('.').pop();
					if (extSoporte != 'Pdf' && extSoporte != 'PDF' && extSoporte && extSoporte != 'pdf' ) {

					    $('span[data-valmsg-for="Soporte"]').text("* debe ser un archivo Pdf");

					}else{

						Barra("BarSoporte","25%", "Cargando");
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
				            },
				            error: function (ex) {
				                console.log(ex.responseText);
				     			Barra("BarSoporte","0%", "Error .... ");

				            }
				        });
					}
			    });

			///////////////////////////////////////
			////// Guardar Anexo
			    $("#Anexo").change(function () {
			    	var extAnexo = $("#Anexo").val().split('.').pop();
					if ( extAnexo != 'Pdf' && extAnexo != 'PDF' && extAnexo != 'pdf')  {

					    $('span[data-valmsg-for="Anexo"]').text("* debe ser un archivo Pdf");

					}else{
						Barra("BarAnexo","25%", "Cargando");
				        var form = $('#CrearForm')[0];
				        var Data = new FormData(form);
				        $.ajax({
				            type: 'POST',
				            url: 'CrearAnexo', // we are calling json method
				            dataType: 'json',
				            enctype: 'multipart/form-data',
				            processData: false,
				            contentType: false,
				            cache: false,
				            timeout: 600000,
				            data: Data,
				            success: function(states) {
				                $("#Id").val(states.Id);
				                TablaAnexo();
				            },
				            error: function (ex) {
				                console.log(ex.responseText);
				     			Barra("BarAnexo","0%", "Error .... ");
				            }
				        });
				    }    
			    });

			///////////////////////////////////////
			////// Guardar Expediente Asociado
			    $("#GuardarExpAso").click(function () {
					Barra("BarExp","25%", "Cargando");
			        $("#IdExpediente").val($("#IdT").val());
			        var form = $('#CrearForm')[0];
			        var Data = new FormData(form);

			        var Listlength = $("#table_Exp_Aso  tr").length;
			        var ListTd = $("#table_Exp_Aso  td").text();
			        var msnList = "Ningún dato disponible en esta tabla";


			        if (msnList != ListTd && Listlength == 2) {

                    	$('span[data-valmsg-for="IdExpediente"]').text("* No puede asociar mas de un expediente");

			        } else {

			        	$.ajax({
				            type: 'POST',
				            url: 'CrearExpedientes', // we are calling json method
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
				            },
				            error: function (ex) {
				                console.log(ex.responseText);
				     			Barra("BarExp","0%", "Error .... ");
				            }
			        	});
			        }

			        
			    });

			///////////////////////////////////////
			////// Guardar usuario Asociado
			    $("#AsociarUser").click(function () {
					Barra("BarUser","25%", "Cargando");
			        var form = $('#CrearForm')[0];
			        var Data = new FormData(form);


			        var Listlength = $("#table_Asociados_  tr").length;
			        var ListTd = $("#table_Asociados_  td").text();
			        var msnList = "Ningún dato disponible en esta tabla";


			        if (msnList != ListTd && Listlength == 2) {

                    	$('span[data-valmsg-for="UserAsociado"]').text("* No puede asociar mas de un Usuario");

			        } else {

				        $.ajax({
				            type: 'POST',
				            url: 'CrearUsuariosAsociados', // we are calling json method
				            dataType: 'json',
				            enctype: 'multipart/form-data',
				            processData: false,
				            contentType: false,
				            cache: false,
				            timeout: 600000,
				            data: Data,
				            success: function (states) {
				                $("#Id").val(states.Id);
				                UsuariosAsociados();
				            },
				            error: function (ex) {
				                console.log(ex.responseText);
				     			Barra("BarUser","0%", "Error .... ");
				            }
				        });
				    }
			        return false;
			    });

		///////////////////////////////////////
		////// GESTION

			///////////////////////////////////////
			////// Guardar Gestion
				
				$("#IdSoporte").change(function () {
					$("#NombreIdSoporte" ).val($('#IdSoporte option:selected').text());
			    });			

				$('#Archivo').change(function (){
				     var sizeByte = this.files[0].size;
				     var siezekiloByte = parseInt(sizeByte / 1024);
				     if(siezekiloByte > "15000"){
				         alert('El tamaño supera el limite permitido');
				         $(this).val('');
				     }
				});

			    $("#GuardarGestion").click(function () {

					Barra("BarUser","25%", "Cargando");
			        var form = $('#CrearGestionForm')[0];
			        var Data = new FormData(form);

			        var validacion = false;

			        var IdSoporte = $("#IdSoporte").val();
			        var IdEstado = $("#IdEstado").val();
			        var Archivo = $("#Archivo").val()+"1";
			        var GestionObservacion = $("#GestionObservacion").val()+"1";

			        if (IdSoporte == "Seleccione") {
	                	$('span[data-valmsg-for="IdSoporte"]').text("* Requerido");
			        	validacion = true;
			        }

			         if (IdEstado == "Seleccione") {

	                	$('span[data-valmsg-for="IdEstado"]').text("* Requerido");
			        	validacion = true;
			        }

			        if ($('#RolGestion').val() != "Lider") {
			        	
			        	if (Archivo == null) {
	               	 		$('span[data-valmsg-for="Archivo"]').text("* Requerido");
			        		validacion = true;
			        	}

			        }

			        if (GestionObservacion == "1") {
	               	 	
	               	 	$('span[data-valmsg-for="GestionObservacion"]').text("* Requerido");
			        	validacion = true;
			        } 

			        if (validacion == false) {
				        $.ajax({
				            type: 'POST',
				            url: 'CrearGestion', // we are calling json method
				            dataType: 'json',
				            enctype: 'multipart/form-data',
				            processData: false,
				            contentType: false,
				            cache: false,
				            timeout: 600000,
				            data: Data,
				            success: function (states) {
				                TablaGestion();
				                form.reset();
				                alert("Guardado...");
						    	return false;
				            },
				            error: function (ex) {
				                console.log(ex.responseText);
				     			Barra("BarUser","0%", "Error .... ");
						    	return false;
				            }
				        });

				    }else{
				    	return false;
				    }
				    	return false;

			    });

	///////////////////////////////////////
	////// CONSULTA TABLAS

		///////////////////////////////////////
		////// CONCEPTOS

			///////////////////////////////////////
			////// tabla Soporte
			    function TablaSoporte() {
					Barra("BarSoporte","50%", "Cargando");
			        $.ajax({
			            type: 'POST',
			            url: 'ConsultaDocumentoSoporte',
			            dataType: 'json',
			            data: { key: $("#Id").val() },
			            success: function (s) {
			                oTableSoporte.fnClearTable();
			                var Ruta = $("#RutaCon").val();
			                $.each(s, function (i, obj) {

			                	var RutasSoporte = $("#RutasSoporte").text();
			                	$("#RutasSoporte").text(RutasSoporte+
			                		'<a target="_blank" href="'+ Ruta + obj.NOMBRE + '" >'+ obj.NOMBRE+' </a> <i class="fa fa-eye">  </i> <br> ');

			                	if (pathname.indexOf("Edit") > -1) {
				                    
				                    oTableSoporte.fnAddData([
			                        	obj.ID_CT_PAIS,
			                        	"",
			                        	'<a target="_blank" href="'+ Ruta + obj.NOMBRE + '" >'+ obj.NOMBRE+' </a>'
			                    	]);

				                } else {
				                    
				                    oTableSoporte.fnAddData([
			                        	obj.ID_CT_PAIS,
			                        	"<z1 title='Eliminar' class = 'zz'  Data='"+obj.ID_CT_PAIS+"' class='EliminaDoc' ><i class='fa fa-times'></i></z1>",
			                        	'<a target="_blank" href="'+ Ruta + obj.NOMBRE + '" >'+ obj.NOMBRE+' </a>'
			                    	]);
				                }

			                    
			                });
			     			Barra("BarSoporte","100%", "Archivo Guardado");
			            },
			            error: function(e){
			                oTableSoporte.fnClearTable();
			            }
			        });
			    };

			///////////////////////////////////////
			////// tabla Anexo
			    function TablaAnexo () {
					Barra("BarAnexo","50%", "Cargando");
			        $.ajax({
			            type: 'POST',
			            url: 'ConsultaDocumentoAnexo',
			            dataType: 'json',
			            data: { key: $("#Id").val() },
			            success: function (s) {
			                oTableAnexo.fnClearTable();
			                var Ruta = $("#RutaCon").val();
			                $.each(s, function (i, obj) {

			                	var RutasAnexo = $("#RutasAnexo").text();

			                	$("#RutasAnexo").text(RutasAnexo+
			                		'<a target="_blank" href="'+ Ruta + obj.NOMBRE + '" >'+ obj.NOMBRE+' </a> <i class="fa fa-eye">  </i> <br> ');


			                	if (pathname.indexOf("Edit") > -1) {
				                    
				                    oTableAnexo.fnAddData([
			                        	obj.ID_CT_PAIS,
			                        	"",
			                        	'<a target="_blank" href="'+ Ruta + obj.NOMBRE + '" >'+ obj.NOMBRE+' </a>'
			                    	]);

				                } else {
				                    
				                    oTableAnexo.fnAddData([
				                        obj.ID_CT_PAIS,
				                        "<z1 title='Eliminar' Data='"+obj.ID_CT_PAIS+"' class='EliminaDoc' ><i class='fa fa-times'></i></z1>",
				                        '<a target="_blank" href="'+ Ruta + obj.NOMBRE + '" >'+ obj.NOMBRE+' </a>'
				                    ]);
				                }

			                });
			     			Barra("BarAnexo","100%", "Archivo Guardado");
			            },
			            error: function(e){
			                oTableAnexo.fnClearTable();
			            }
			        });
			    };

			///////////////////////////////////////
			////// tabla Expedientes Asociados
			    function ExpedientesAsociados () {
					Barra("BarExp","50%", "Cargando");
			        $.ajax({
			            type: 'POST',
			            url: 'ConsultaExpedientesAsociados',
			            dataType: 'json',
			            data: { key: $("#Id").val() },
			            success: function (s) {
			                oTableExp_Aso.fnClearTable();
			                var Ruta = $("#RutaPdf").val();
			                $.each(s, function (i, obj) {
			                    var array = obj.NOMBRE.split("||");

			                    if (pathname.indexOf("Edit") > -1) {
				                    
				                   oTableExp_Aso.fnAddData([
			                        	obj.ID_CT_PAIS,
			                        	"",
			                        	'<a target="_blank" href="'+ Ruta + array[1] + '" >'+ array[0]+' </a>'
			                    	]);

				                } else {
				                    
				                    oTableExp_Aso.fnAddData([
			                        	obj.ID_CT_PAIS,
			                        	"<z1 title='Eliminar' Data='"+obj.ID_CT_PAIS+"' class='EliminaDoc' ><i class='fa fa-times'></i></z1>",
			                        	'<a target="_blank" href="'+ Ruta + array[1] + '" >'+ array[0]+' </a>'
			                    	]);
				                }
			                    
			                });
			     			Barra("BarExp","100%", " Guardado");
			            },
			            error: function(e){
			                oTableExp_Aso.fnClearTable();
			            }
			        });
			    };

			///////////////////////////////////////
			////// tabla  Asociados
			    function UsuariosAsociados () {
					Barra("BarUser","50%", "Cargando");
			        $.ajax({
			            type: 'POST',
			            url: 'ConsultaUsuariosAsociados',
			            dataType: 'json',
			            data: { key: $("#Id").val() },
			            success: function (s) {
			                oTableAsociados.fnClearTable();
                            $.each(s, function (i, obj) {


            					if ($("#IdAspNetUsers").val() == $("#IdAspNetUsersLogin").val()) {
                                    
                                } else
                                if ($("#RolGestion").val() == "Lider") {
                                    
                                } else 
                                if ($("#IdAspNetUserGestion").val() == obj.IdAspNetUsers) {
                                    
                                } else                            	
                                if ($("#IdAspNetUserGestion").val() != obj.IdAspNetUsers) {
                                    $("#CrearGestionForm input[type='submit'] ").hide();
                                    $("#CrearGestionForm input").prop("disabled", true);
                                    $("#CrearGestionForm a").hide();
                                    $("#CrearGestionForm select").prop("disabled", true);
                                    $("#CrearGestionForm textarea").prop("disabled", true);
                                }else
                                if ($("#RolGestion").val() != "Lider") {
                                    $("#CrearGestionForm input[type='submit'] ").hide();
                                    $("#CrearGestionForm input").prop("disabled", true);
                                    $("#CrearGestionForm a").hide();
                                    $("#CrearGestionForm select").prop("disabled", true);
                                    $("#CrearGestionForm textarea").prop("disabled", true);
                                } else
                                if ($("#IdAspNetUsers").val() != $("#IdAspNetUsersLogin").val()) {
                                    $("#CrearGestionForm input[type='submit'] ").hide();
                                    $("#CrearGestionForm input").prop("disabled", true);
                                    $("#CrearGestionForm a").hide();
                                    $("#CrearGestionForm select").prop("disabled", true);
                                    $("#CrearGestionForm textarea").prop("disabled", true);
                                } 


			                    if (pathname.indexOf("Edit") > -1) {
				                    
				                   oTableAsociados.fnAddData([
			                        	obj.Id,
			                        	"",
			                        	obj.Rol,
			                        	obj.NombreAspNetUsers,
			                    	]);

				                } else {
				                    
				                    oTableAsociados.fnAddData([
			                        	obj.Id,
			                        	"<z1 title='Eliminar' Data='"+obj.id+"' class='EliminaDoc' ><i class='fa fa-times'></i></z1>",
			                        	obj.Rol,
			                        	obj.NombreAspNetUsers,
			                    	]);
				                }


			                });
			     			Barra("BarUser","100%", "Guardado");
			            },
			            error: function(e){
			                oTableAsociados.fnClearTable();
			            }
			        });
			    };

			    $( "#BuscarExp" ).click(function() {
			        if ($("#IdExpediente").val() != "") {
			            $.ajax({
			                type: 'POST',
			                url: 'ConsultaExpediente',
			                dataType: 'json',
			                data: { key: $("#IdExpediente").val() },
			                success: function (s) {
			                    $("#NumeroExpedienteT").text(s.NumeroExpediente.toLowerCase());
			                    $("#IdT").val(s.id);
			                    $("#DepartamentoT").text(s.NombreIdDepto.toLowerCase());
			                    $("#MunicipioT").text(s.NombreIdCiudad.toLowerCase());
			                    $("#VeredaT").text(s.Vereda.toLowerCase());
			                    $("#PredioT").text(s.NombrePredio.toLowerCase());
			                    $("#NombreSolitanteT").text(s.NombreBeneficiario.toLowerCase());
			                    $("#IdentificaciónT").text( s.Identificacion.toLowerCase());
			                },
			                error: function (e) {
			                    oTableAnexo.fnClearTable();
			                }
			            });
			        } else {
			            $('span[data-valmsg-for="IdExpediente"]').text("* Num. Exp. Requerido para Buscar");
			        }
					return false	;
			    });

		///////////////////////////////////////
		////// GESTION

			///////////////////////////////////////
			////// tabla estado
			    function TablaGestion() {
			    	Barra("BarGestion","50%", "Cargando");
			        $.ajax({
			            type: 'POST',
			            url: 'ListGestion',
			            dataType: 'json',
			            data: { Id: $("#Id").val() },
			            success: function (s) {
			                oTableGestion.fnClearTable();
			                var Ruta = $("#RutaCon").val();

			                
			                $.each(s, function (i, obj) {
			                	var Archivo = "";
								if (obj.NombreIdEstado == "Solicitud") {
			              			if (obj.Archivo != "N_A") {
			                    	    Archivo = '<a target="_blank" href="'+ Ruta + "Gestion/"+ obj.Archivo + '" >'+ obj.NombreIdSoporte+' <i class="fa fa-eye">  </i></a>';
									}
								}else {
				              		if (obj.Archivo != "N_A") {
				                        Archivo = '<a target="_blank" href="'+ Ruta + "Gestion/"+ obj.Archivo + '" >'+ obj.NombreIdSoporte+' <i class="fa fa-eye">  </i></a>';
				                	}
			              		}
			              	
			                    oTableGestion.fnAddData([
			                        obj.Id,
			                        obj.FCreacion,
			                        obj.NombreIdEstado,
			                        Archivo,
			                        obj.RolUser,
			                        obj.NombreUser,
			                        obj.Observacion,
			                        ''
			                    ]);
			                });
			     			Barra("BarGestion","100%", "Archivos Cargandos");
			            },
			            error: function(e){
			                oTableGestion.fnClearTable();
			            }
			        });
			    };

	///////////////////////////////////////
	//////ELIMINAR EN TABLA

		/////////////////////////////////////
		//// tabla soporte
		    var tablaSoporteZ = $('#table_Soporte').DataTable();
		    $('#table_Soporte tbody').on('click', 'z1', function () {
		        var data = tablaSoporteZ.row($(this).parents('tr')).data();
		            $.ajax({
		            type: 'POST',
		            url: 'DeleteDocumentoSoporte',
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
		            url: 'DeleteDocumentoAnexo',
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
		            url: 'DeleteExpediente',
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
		            url: 'DeleteUsuariosAsociados',
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

	///////////////////////////////////////
	//////FUNCIONES INICIALES
        if ($("#Id").val() != 0) {
            TablaSoporte();
            TablaGestion();
            TablaAnexo();
            UsuariosAsociados();
            ExpedientesAsociados();
        }
});
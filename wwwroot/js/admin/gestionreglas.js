var isPostBack = false;
var listaArbolParaCombo = null;
var varIsAgregar = true;
var varIsEliminar = true;
var varIsEditar = true;

document.addEventListener('DOMContentLoaded', function () {
    // if (typeof (listaArbolParaComboLoad) != 'undefined') {
    //     listaArbolParaCombo = eval('(' + listaArbolParaComboLoad + ')');
    //     CargarCombo();
    // } else {
    //     PageMethods.CargarArbolCombo(OnCallBackCargarArbolCombo, OnFail);
    // }
    if (listaArbolParaCombo == null) {
        listaArbolParaCombo = eval('(' + document.querySelector('#hiddenListaTodasReglasPorNivel').value + ')');
        if (typeof listaArbolParaCombo == 'undefined') {
            listaArbolParaCombo = null;
        }
    }
    CargarCombo();
    isPostBack = true;

});
function clickCerrarMensajes() {
    alertGenericClose();
}
function LimpiarControlesSinComboReglaElegir() {
    document.getElementById('txtNombreReglaInput').value ='';
    document.getElementById('txtPalabraClaveInput').value ='';
    document.getElementById('txtPalabraClaveInput').disabled = false ;
    document.getElementById('CheckBoxSoportadasAgregar').checked = false;
    document.getElementById('CheckBoxSoportadasEditar').checked = false;
    document.getElementById('CheckBoxSoportadasEliminar').checked =  false;
    document.getElementById('comboReglasContenidas').selectedIndex =  0;
}
function CargarCombo() {
    var strHTMLcombo = '';
    var strHTMLcomboInicioContenida = '<select id="comboReglasContenidas"   class="form-control"  >';
    var strHTMLcomboInicioElegir = '<select id="comboReglasElegir"  class="form-control"  onchange="clickComboElegir()">';
    if (varIsAgregar) {
        strHTMLcomboInicioElegir += "<option value=\'" + "0" + "\'>";
        strHTMLcomboInicioElegir += "<div >" + "<<( Nueva Regla )>>" + "</div>";
        strHTMLcomboInicioElegir += "</option>";
    }
    if (listaArbolParaCombo.length > 0) {
        for (var i = 0; i < listaArbolParaCombo.length; i++) {

            if (!listaArbolParaCombo[i].isGraficada) {
                strHTMLcombo += "<option value=\'" + listaArbolParaCombo[i].id + "\'>";
                strHTMLcombo += "<div >" + listaArbolParaCombo[i].descripcion + "</div>";
                strHTMLcombo += "</option>";
                listaArbolParaCombo[i].isGraficada = true;
                strHTMLcombo += RecuperarHTMLNodosHijosCombo(listaArbolParaCombo[i].listaIdHijas);
            }
        }
    }
    strHTMLcombo += '</select>';
    if (varIsAgregar) {
        document.getElementById('divCombo').innerHTML = strHTMLcomboInicioContenida + strHTMLcombo;
        document.getElementById('btnEliminar').disabled = true;//btnEliminar").prop( "disabled", true );
    } else {
        document.getElementById('divCombo').innerHTML = "<select id=/'comboReglasContenidas/' class=/'form-control/'  >" + obtenerRaizOptiom() + "</select>";
        RecuperarReglaRaiz();
        document.getElementById('btnGuardar').disabled = true;//  $("#btnGuardar").prop( "disabled", true );
        document.getElementById('btnEliminar').disabled = true;// $("#btnEliminar").prop( "disabled", true );
    }
    document.getElementById('divComboRegla').innerHTML = strHTMLcomboInicioElegir + strHTMLcombo;

}
function clickComboElegir() {
    
    LimpiarControlesSinComboReglaElegir();
    var idReglaSeleccionada = document.getElementById('comboReglasElegir').value;
    var CodigoPadreReglaSeleccionada = cargarComboContenidoModificar(idReglaSeleccionada);
    for (var i = 0; i < document.getElementById('comboReglasContenidas').length; i++) {
        if (document.getElementById('comboReglasContenidas')[i].value == CodigoPadreReglaSeleccionada) {
            document.getElementById('comboReglasContenidas')[i].selected = true;
            break;
        }
    }
    if (idReglaSeleccionada > 0) {
        RecuperarReglaPorId(idReglaSeleccionada);
    } else {
        //        $('#txtPalabraClaveInput').removeAttr('disabled');
        document.getElementById('btnEliminar').disabled = true; //  $("#btnEliminar").prop( "disabled", true );
    }
}
function OnCallBackRecuperarReglaPorId(args) {
    //    var fgg = args;
    if (args != null) {
      
      
        document.getElementById('txtNombreReglaInput').value =args.descripcion;//  $("#txtNombreReglaInput").val(args.descripcion);
        document.getElementById('txtPalabraClaveInput').value =args.palabra;//$("#txtPalabraClaveInput").val(args.palabra);
        document.getElementById('txtPalabraClaveInput').disabled = true; //$('#txtPalabraClaveInput').prop( "disabled", true );
        if (args.checkAgregar == 0) {
            document.getElementById('CheckBoxSoportadasAgregar').checked = false;// $("#CheckBoxSoportadasAgregar").prop('checked', false);
        } else {
            document.getElementById('CheckBoxSoportadasAgregar').checked = true;//$("#CheckBoxSoportadasAgregar").prop('checked', true);
        }
        if (args.checkEditar == 0) {
            document.getElementById('CheckBoxSoportadasEditar').checked = false;//  $("#CheckBoxSoportadasEditar").prop('checked', false);
        } else {
            document.getElementById('CheckBoxSoportadasEditar').checked = true;// $("#CheckBoxSoportadasEditar").prop('checked', true);
        }
        if (args.checkEliminar == 0) {
            document.getElementById('CheckBoxSoportadasEliminar').checked = false;//  $("#CheckBoxSoportadasEliminar").prop('checked', false);
        } else {
            document.getElementById('CheckBoxSoportadasEliminar').checked = true;// $("#CheckBoxSoportadasEliminar").prop('checked', true);
        }
        if (varIsEliminar) {
            if (args.listaIdHijas.length > 0) {
                document.getElementById('btnEliminar').disabled = true;//    $("#btnEliminar").prop( "disabled", true );
            } else {
                document.getElementById('btnEliminar').disabled = false;//     $("#btnEliminar").prop( "disabled", false );
            }
        } else {
            document.getElementById('btnEliminar').disabled = true;//  $("#btnEliminar").prop( "disabled", true );
        }
        if (varIsEditar) {
            document.getElementById('btnGuardar').disabled = false;//    $("#btnGuardar").prop( "disabled", false );
        } else {
            document.getElementById('btnGuardar').disabled = true;//    $("#btnGuardar").prop( "disabled", true );
        }
    }
}
function cargarComboContenidoModificar(pIdRegla) {
    var isRaiz = false;
    var CodigoPadre = 0;
    for (var i = 0; i < listaArbolParaCombo.length; i++) {
        if (pIdRegla == listaArbolParaCombo[i].id) {
            if (listaArbolParaCombo[i].idPadreRegla == null) {
                isRaiz = true;
                break;
            }
        }
    }

    var strHTMLcombo = '';
    var strHTMLcomboInicioContenida = '<select id="comboReglasContenidas"  class="form-control" >';
    if (!isRaiz) {
        for (var i = 0; i < listaArbolParaCombo.length; i++) {
            listaArbolParaCombo[i].isGraficada = false;
            if (listaArbolParaCombo[i].id == pIdRegla) {
                CodigoPadre = listaArbolParaCombo[i].idPadreRegla;
            }

        }
        if (listaArbolParaCombo.length > 0) {
            for (var i = 0; i < listaArbolParaCombo.length; i++) {
                if (!listaArbolParaCombo[i].isGraficada) {
                    if (listaArbolParaCombo[i].id != pIdRegla) {
                        strHTMLcombo += "<option value=\'" + listaArbolParaCombo[i].id + "\'>";
                        strHTMLcombo += "<div >" + listaArbolParaCombo[i].descripcion + "</div>";
                        strHTMLcombo += "</option>";
                        listaArbolParaCombo[i].isGraficada = true;
                        strHTMLcombo += RecuperarHTMLNodosHijosComboModificar(listaArbolParaCombo[i].listaIdHijas, pIdRegla);
                    } else {
                        listaArbolParaCombo[i].isGraficada = true;
                        MarcarComoGraficadas(listaArbolParaCombo[i].listaIdHijas);
                    }
                }
            }
        }
    } else {
        strHTMLcombo += obtenerRaizOptiom();
    }
    strHTMLcombo += '</select>';
    document.getElementById('divCombo').innerHTML = strHTMLcomboInicioContenida + strHTMLcombo;

    return CodigoPadre;
}

function obtenerRaizOptiom() {
    var strHTMLcombo = "";
    strHTMLcombo += "<option  value=\'" + "0" + "\'>";
    strHTMLcombo += "<div >" + "--- Root Node ---" + "</div>";
    strHTMLcombo += "</option>";
    return strHTMLcombo;
}


function MarcarComoGraficadas(pListaHijas) {
    for (var i = 0; i < pListaHijas.length; i++) {
        for (var x = 0; x < listaArbolParaCombo.length; x++) {
            if (!listaArbolParaCombo[x].isGraficada) {
                if (pListaHijas[i] == listaArbolParaCombo[x].id) {
                    listaArbolParaCombo[x].isGraficada = true;
                    MarcarComoGraficadas(listaArbolParaCombo[x].listaIdHijas);
                }
            }
        }
    }
}

function RecuperarHTMLNodosHijosComboModificar(pListaHijas, pIdRegla) {
    var strTextoCompleto = '';
    for (var i = 0; i < pListaHijas.length; i++) {
        for (var x = 0; x < listaArbolParaCombo.length; x++) {
            if (!listaArbolParaCombo[x].isGraficada) {

                if (pListaHijas[i] == listaArbolParaCombo[x].id) {
                    if (pIdRegla != pListaHijas[i]) {
                        strTextoCompleto += "<option value=\'" + listaArbolParaCombo[x].id + "\'";
                        strTextoCompleto += "<div>";
                        for (var xy = 0; xy < listaArbolParaCombo[x].Nivel; xy++) {
                            strTextoCompleto += "&nbsp; &nbsp;"
                        }
                        strTextoCompleto += listaArbolParaCombo[x].descripcion + "</div>";
                        strTextoCompleto += "</option>";
                        listaArbolParaCombo[x].isGraficada = true;
                        strTextoCompleto += RecuperarHTMLNodosHijosComboModificar(listaArbolParaCombo[x].listaIdHijas, pIdRegla);
                    } else {
                        listaArbolParaCombo[x].isGraficada = true;
                        MarcarComoGraficadas(listaArbolParaCombo[x].listaIdHijas);
                    }
                }

            }
        }
    }
    return strTextoCompleto;
}

function RecuperarHTMLNodosHijosCombo(pListaHijas) {
    var strTextoCompleto = '';
    for (var i = 0; i < pListaHijas.length; i++) {
        for (var x = 0; x < listaArbolParaCombo.length; x++) {
            if (!listaArbolParaCombo[x].isGraficada) {
                if (pListaHijas[i] == listaArbolParaCombo[x].id) {
                    strTextoCompleto += "<option value=\'" + listaArbolParaCombo[x].id + "\'";
                    strTextoCompleto += "<div >";
                    for (var xy = 0; xy < listaArbolParaCombo[x].Nivel; xy++) {
                        strTextoCompleto += " &nbsp; &nbsp;"
                    }
                    strTextoCompleto += listaArbolParaCombo[x].descripcion + "</div>";
                    strTextoCompleto += "</option>";
                    listaArbolParaCombo[x].isGraficada = true;
                    strTextoCompleto += RecuperarHTMLNodosHijosCombo(listaArbolParaCombo[x].listaIdHijas);
                }
            }
        }
    }
    return strTextoCompleto;
}

function clikGuardar() {
    var idReglaSeleccionada = document.getElementById('comboReglasElegir').value;
    if (idReglaSeleccionada == 0) {
        // Es nueva la regla
        ValidarRegla();
    } else {
        // Es una regla existente
        if (varIsEditar) {
            ValidarReglaParaModificar(idReglaSeleccionada);
        } else {
            alertDanger('No tiene permiso para modificar');
        }
    }
    return false;
}
function ValidarReglaParaModificar(pIdRegla) {
    var strHtmlMensaje = '';
    var NombreRegla = document.getElementById('txtNombreReglaInput').value;
    if (NombreRegla == '') {
        strHtmlMensaje += "<p>" + "Descripción es campo requerido" + "</p>";
    }
    if (document.getElementById('comboReglasContenidas').value == null) {
        strHtmlMensaje += "<p>" + "No hay regla raiz" + "</p>";
    }
    if (strHtmlMensaje != '') {
        alertDanger(strHtmlMensaje);
    } else {
        IsNombreOPalabraNoSeRepite(pIdRegla, String(document.getElementById('txtNombreReglaInput').value), String(document.getElementById('txtPalabraClaveInput').value));
    }
}
function OnCallBackIsNombreOPalabraNoSeRepiteModificar(args) {
    var strHtmlMensaje = '';
    if (!args[0]) {
        strHtmlMensaje += "<p>" + "Descripción no puede repetirse" + "</p>";
    }
    if (strHtmlMensaje != '') {
        alertDanger(strHtmlMensaje);
    } else {
        alertGenericClose();
        ActualizarRegla(document.getElementById('comboReglasElegir').value, document.getElementById('txtNombreReglaInput').value, String(document.getElementById('txtPalabraClaveInput').value),
        document.getElementById('CheckBoxSoportadasAgregar').checked,
        document.getElementById('CheckBoxSoportadasEditar').checked,
        document.getElementById('CheckBoxSoportadasEliminar').checked,
          document.getElementById('comboReglasContenidas').value);
          //$("#CheckBoxSoportadasAgregar").is(':checked')
          //$("#CheckBoxSoportadasEditar").is(':checked')
          //    $("#CheckBoxSoportadasEliminar").is(':checked')
    }

}
function OnCallBackActualizarRegla(args) {
    if (args) {
        LimpiarControlesSinComboReglaElegir();
        CargarArbolCombo();
    }
    else {
        var strHtmlMensaje = '';
        strHtmlMensaje += "<p>" + "No se pudo actualizar la regla en el sistema" + "</p>";
        alertDanger(strHtmlMensaje);
    }
}
function OnFailActualizarRegla(ex) {
    //document.getElementById('txtPalabraClaveInput').removeAttr('disabled');
    //document.getElementById("div1").removeAttribute("align");
    document.getElementById('txtPalabraClaveInput').removeAttribute("disabled");
    alertDanger(String(ex));
}
function ValidarRegla() {
    var strHtmlMensaje = '';
    var er = new RegExp(/\s/);
    var palaClave = document.getElementById('txtPalabraClaveInput').value;
    if (palaClave != '') {
        if (er.test(palaClave)) {
            strHtmlMensaje += "<p>" + "Palabra clave no tiene que tener espacio en blanco" + "</p>";
        }
    } else {
        strHtmlMensaje += "<p>" + "Palabra clave es campo requerido" + "</p>";
    }
    var NombreRegla = document.getElementById('txtNombreReglaInput').value;
    if (NombreRegla == '') {
        strHtmlMensaje += "<p>" + "Descripción es campo requerido" + "</p>";
    }
    if (document.getElementById('comboReglasContenidas').value == null) {
        strHtmlMensaje += "<p>" + "No hay regla raiz" + "</p>";
    }

    if (strHtmlMensaje != '') {
        alertDanger(strHtmlMensaje);
    } else {
        IsNombreOPalabraNoSeRepite(0, String(document.getElementById('txtNombreReglaInput').value), String(document.getElementById('txtPalabraClaveInput').value));
    }
}

function OnCallBackIsNombreOPalabraNoSeRepite(args) {
    var strHtmlMensaje = '';
    if (!args[0]) {
        strHtmlMensaje += "<p>" + "Descripción no puede repetirse" + "</p>";
    }
    if (!args[1]) {
        strHtmlMensaje += "<p>" + "Palabra clave no puede repetirse" + "</p>";
    }
    if (strHtmlMensaje != '') {
        alertDanger(strHtmlMensaje);
    } else {
        alertGenericClose();
        InsertarRegla(document.getElementById('txtNombreReglaInput').value, document.getElementById('txtPalabraClaveInput"').value, $("#CheckBoxSoportadasAgregar").is(':checked'), $("#CheckBoxSoportadasEditar").is(':checked'), $("#CheckBoxSoportadasEliminar").is(':checked'), document.getElementById('comboReglasContenidas').value);
    }
}
function OnCallBackInsertarRegla(args) {
    if (args) {
        LimpiarControlesSinComboReglaElegir();
        CargarArbolCombo();
    }
    else {
        var strHtmlMensaje = '';
        strHtmlMensaje += "<p>" + "No se pudo grabar en el sistema" + "</p>";
        alertDanger(strHtmlMensaje);
    }
}
function OnCallBackCargarArbolCombo(args) {
    listaArbolParaCombo = args;// eval('(' + args + ')');
    CargarCombo();
}
function clikEliminar() {
    mensaje_confirmar('Información', '<p>¿Desea eliminar la regla?</p>', 'Eliminar','Cancelar' , 'return onclickEliminarRegla();', 'return false;');
    return false;
}
function onclickEliminarRegla() {
    EliminarRegla(document.getElementById('comboReglasElegir').value);
    
    return false;
}
function OnCallBackEliminarRegla(args) {
    if (args) {
        LimpiarControlesSinComboReglaElegir();
        CargarArbolCombo();
    } else {
        alertDanger('No se pudo eliminar');
    }
}

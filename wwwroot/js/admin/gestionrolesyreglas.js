var listaReglasRol = null;
var listaRoles = null;
var listaReglasRolSelecciondo = [];

function ReglaAGrabar() {
    this.idRelacionReglaRol = 0;
    this.idRegla = 0;
    this.isActivo = false;
    this.isAgregado = false;
    this.isEditado = false;
    this.isEliminado = false;
    this.isAgregar= function () {
        return isAgregado;
      };
    this.isEditar= function () {
        return isEditado;
      };
    this.isEliminar= function () {
        return isEliminado;
      };
}

document.addEventListener('DOMContentLoaded', function () {

    if (listaReglasRol == null) {
        listaReglasRol = eval('(' + document.getElementById('hiddenListaTodasReglasPorNivel').value + ')');
        
        if (typeof listaReglasRol == 'undefined') {
            listaReglasRol = null;
        }
    }
    if (listaRoles == null) {
        listaRoles = eval('(' +document.getElementById('hiddenListaTodosRoles').value + ')');
        if (typeof listaRoles == 'undefined') {
            listaRoles = null;
        }
    }
    CargarArbolEnInicio();
    CargarComboRoles();
    ChangeIndexComboRol();
});

function CargarComboRoles() {
    if (listaRoles != null) {
        OnCallBack_getRoles_Combo(listaRoles);
    }
}

function CargarArbolEnInicio() {

    if (listaReglasRol != null && listaReglasRol.length > 0) {
        var strTexto = '<table class=\'table table-striped\'><thead><tr>';
        strTexto += '<th>Reglas</th> <th><div class=\'texto-vertical\'>Activa</div></th>';
        strTexto += '<th><div class="texto-vertical">Agregar</div></th>';
        strTexto += '<th><div class="texto-vertical">Editar</div></th>';
        strTexto += '<th><div class="texto-vertical">Eliminar</div></th>';
        strTexto += '<th> Clave</th></tr></thead>';
        strTexto += '<tbody>';
        for (var xRaiz = 0; xRaiz < listaReglasRol.length; xRaiz++) {
            if (listaReglasRol[xRaiz].idPadreRegla == null) {
                var l_raiz = [];
                l_raiz.push(listaReglasRol[xRaiz].id);
                strTexto += GraficarNodosHijos(l_raiz);
            }
        }
        strTexto += '</tbody>';
        strTexto += "</table>";
        document.getElementById('divSectorArbol').innerHTML = strTexto;
    }
    else {
        // hacer algo cuando no se encuetra reglas para el rol
        var strTexto = '<table class=\'table table-striped\'><thead><tr>';
        strTexto += '<th>Reglas</th> <th><div class=\'texto-vertical\'>Activa</div></th>';
        strTexto += '<th><div class="texto-vertical">Agregar</div></th>';
        strTexto += '<th><div class="texto-vertical">Editar</div></th>';
        strTexto += '<th><div class="texto-vertical">Eliminar</div></th>';
        strTexto += '<th> Clave</th></tr></thead>';
        strTexto += "</table>";
        document.getElementById('divSectorArbol').innerHTML = strTexto;
    }
}

function GraficarNodosHijos(pListaHijas) {

    var strTextoCompleto = '';
    for (var i = 0; i < pListaHijas.length; i++) {

        for (var x = 0; x < listaReglasRol.length; x++) {

            if (String(pListaHijas[i]) == String(listaReglasRol[x].id)) {
                if (!listaReglasRol[x].isGraficada) {

                    var NivelCss = listaReglasRol[x].Nivel;
                    var strFila = "<tr id=\'fila_" + String(listaReglasRol[x].id) + "\'><td>";
                    strFila += "<span style=\'margin-left: " + String(NivelCss) + "em\'></span>";
                    if (listaReglasRol[x].listaIdHijas.length > 0) {
                        // strFila += "<div id=\'divImgBoton_" + String(listaReglasRol[x].id) + "\' style=\'margin-left: " + String(NivelCss) + "px\' class=\'cssDivImagenContraer\'  onclick=\'ExpandirOContraerNodo(this)\'> </div>";
                        // NivelCss = NivelCss + 12;
                        strFila += '<span id=\'divImgBoton_' + String(listaReglasRol[x].id) + '\' class="oi oi-minus oi-reglarol" title="icon name" aria-hidden="true"  onclick=\'ExpandirOContraerNodo(this)\'></span>';
                    }
                    strFila += "<span id=\'divImg_" + String(listaReglasRol[x].id) + "\'>" + listaReglasRol[x].descripcion + "</span></td>";

                    strFila += "<td ><input id=\'chkActivar_" + String(listaReglasRol[x].id) + "\' type=\'checkbox\' onClick=\'checkAll(this)\' /></td>";

                    if (listaReglasRol[x].checkAgregar == -1) {
                        strFila += "<td > </td>";
                    } else if (listaReglasRol[x].checkAgregar == 0) {
                        strFila += "<td ><input id=\'chkAgregar_" + String(listaReglasRol[x].id) + "\' type='checkbox\' onClick=\'checkAll(this)\' /></td>";
                    }

                    if (listaReglasRol[x].checkEditar == -1) {
                        strFila += "<td ></td>";
                    } else if (listaReglasRol[x].checkEditar == 0) {
                        strFila += "<td ><input id=\'chkEditar_" + String(listaReglasRol[x].id) + "\' type='checkbox\' onClick=\'checkAll(this)\' /></td>";
                    }
                    if (listaReglasRol[x].checkEliminar == -1) {
                        strFila += "<td ></td>";
                    } else if (listaReglasRol[x].checkEliminar == 0) {
                        strFila += "<td ><input id=\'chkEliminar_" + String(listaReglasRol[x].id) + "\' type='checkbox\' onClick=\'checkAll(this)\' /> </td>";
                    }
                    strFila += "<td >" + listaReglasRol[x].palabra + "</td>";
                    strFila += "</tr>";

                    strTextoCompleto += strFila;
                    listaReglasRol[x].isGraficada = true;
                    strTextoCompleto += GraficarNodosHijos(listaReglasRol[x].listaIdHijas);
                }
                break;
            }
        }

    }
    return strTextoCompleto;
}
function ExpandirOContraerNodo(pObj) {
    var lis = pObj.id.split('_');
    var listaRecorrido = [];

    listaRecorrido = BuscarHijos(parseInt(lis[1]));

    // var strCss = '';
    var strCssModificar = '';

    // strCss = document.getElementById("divImgBoton_" + String(lis[1])).classList.contains("oi-plus"); // = 'cssDivImagenContraer';

    var strDisplay = '';
    if (document.getElementById("divImgBoton_" + String(lis[1])).classList.contains("oi-plus")) {//$("#divImgBoton_" + String(lis[1])).hasClass("oi-plus")
        strDisplay = '';
        document.getElementById("divImgBoton_" + String(lis[1])).classList.remove("oi-plus");// $("#divImgBoton_" + String(lis[1])).removeClass("oi-plus");
        document.getElementById("divImgBoton_" + String(lis[1])).classList.add("oi-minus");// $("#divImgBoton_" + String(lis[1])).addClass("oi-minus");
        strCssModificar = 'oi-minus';
    }
    else {
        strDisplay = 'none';
        document.getElementById("divImgBoton_" + String(lis[1])).classList.remove("oi-minus");//$("#divImgBoton_" + String(lis[1])).removeClass("oi-minus");
        document.getElementById("divImgBoton_" + String(lis[1])).classList.add("oi-plus");// $("#divImgBoton_" + String(lis[1])).addClass("oi-plus");
        strCssModificar = 'oi-plus';
    }

    for (var i = 0; i < listaRecorrido.length; i++) {
        document.getElementById("fila_" + String(listaRecorrido[i])).style.display = strDisplay;
        ExpandirOContraerNodoPorIdPadre(listaRecorrido[i], strDisplay, strCssModificar);
    }
}
function ExpandirOContraerNodoPorIdPadre(pIdReglaPadre, pStrDisplay, pStrCssModificar) {

    var listaRecorrido = BuscarHijos(pIdReglaPadre);
    for (var i = 0; i < listaRecorrido.length; i++) {

        document.getElementById("fila_" + String(listaRecorrido[i])).style.display = pStrDisplay;
        document.getElementById("divImgBoton_" + String(pIdReglaPadre)).classList.remove("oi-plus");//
        document.getElementById("divImgBoton_" + String(pIdReglaPadre)).classList.remove("oi-minus");//
        document.getElementById("divImgBoton_" + String(pIdReglaPadre)).classList.add(pStrCssModificar);//
        ExpandirOContraerNodoPorIdPadre(listaRecorrido[i], pStrDisplay, pStrCssModificar);
    }
}
function BuscarHijos(pIdRegla) {
    var resultado = [];

    for (var i = 0; i < listaReglasRol.length; i++) {
        if (listaReglasRol[i].idPadreRegla == pIdRegla) {
            resultado.push(listaReglasRol[i].id);
        }
    }
    return resultado;
}
//
function ClickGuardar() {
    var listaReglaModificadas = [];
    for (var i = 0; i < listaReglasRol.length; i++) {
        var isEncontrado = false;
        for (var xy = 0; xy < listaReglasRolSelecciondo.length; xy++) {
            if (listaReglasRol[i].id == listaReglasRolSelecciondo[xy].idRegla) {
                var isReglaSeModifico = false;
                var re = new ReglaAGrabar();
                re.idRelacionReglaRol = listaReglasRolSelecciondo[xy].idRelacionReglaRol;
                re.idRegla = listaReglasRol[i].id;
                var ckActivar = document.getElementById("chkActivar_" + String(listaReglasRol[i].id));
                if (ckActivar != null) {
                    re.isActivo = ckActivar.checked;
                    if (ckActivar.checked != listaReglasRolSelecciondo[xy].isActivo) {
                        isReglaSeModifico = true;
                    }
                }
                //
                var ckAgregar = document.getElementById("chkAgregar_" + String(listaReglasRol[i].id));
                if (ckAgregar != null) {
                    re.isAgregado = ckAgregar.checked;
                    if (ckAgregar.checked != listaReglasRolSelecciondo[xy].isAgregar) {
                        isReglaSeModifico = true;
                    }
                }
                else {
                    re.isAgregado = null;
                }
                var ckEditar = document.getElementById("chkEditar_" + String(listaReglasRol[i].id));
                if (ckEditar != null) {
                    re.isEditado = ckEditar.checked;
                    if (ckEditar.checked != listaReglasRolSelecciondo[xy].isEditar) {
                        isReglaSeModifico = true;
                    }
                } else {
                    re.isEditado = null;
                }
                var ckEliminar = document.getElementById("chkEliminar_" + String(listaReglasRol[i].id));
                if (ckEliminar != null) {
                    re.isEliminado = ckEliminar.checked;
                    if (ckEliminar.checked != listaReglasRolSelecciondo[xy].isEliminar) {
                        isReglaSeModifico = true;
                    }
                } else {
                    re.isEliminado = null;
                }
                if (isReglaSeModifico) {
                    listaReglaModificadas.push(re);
                }
                isEncontrado = true;
                break;
            } // fin if (listaReglasRol[i].id == listaReglasRolSelecciondo[xy].idRegla) 
        } // fin for (var xy = 0; xy < listaReglasRolSelecciondo.length; xy++)

        if (!isEncontrado) {
            var isValeLaPenaGrabar = false;
            var reNueva = new ReglaAGrabar();
            reNueva.idRelacionReglaRol = -1;
            reNueva.idRegla = listaReglasRol[i].id;
            var ckActivar = document.getElementById("chkActivar_" + String(listaReglasRol[i].id));
            if (ckActivar != null) {
                reNueva.isActivo = ckActivar.checked;
                if (ckActivar.checked) {
                    isValeLaPenaGrabar = true;
                }
            }
            //
            var ckAgregar = document.getElementById("chkAgregar_" + String(listaReglasRol[i].id));
            if (ckAgregar != null) {
                reNueva.isAgregado = ckAgregar.checked;
                if (ckAgregar.checked) {
                    isValeLaPenaGrabar = true;
                }
            } else {
                reNueva.isAgregado = null;
            }
            var ckEditar = document.getElementById("chkEditar_" + String(listaReglasRol[i].id));
            if (ckEditar != null) {
                reNueva.isEditado = ckEditar.checked;
                if (ckEditar.checked) {
                    isValeLaPenaGrabar = true;
                }
            } else {
                reNueva.isEditado = null;
            }
            var ckEliminar = document.getElementById("chkEliminar_" + String(listaReglasRol[i].id));
            if (ckEliminar != null) {
                reNueva.isEliminado = ckEliminar.checked;
                if (ckEliminar.checked) {
                    isValeLaPenaGrabar = true;
                }
            } else {
                reNueva.isEliminado = null;
            }
            if (isValeLaPenaGrabar) {
                listaReglaModificadas.push(reNueva);
            }

        }
    } // fin for (var i = 0; i < listaReglasRol.length; i++)
    // var lal = listaReglaModificadas;
    if (document.getElementById("cmbRoles").selectedIndex >= 0) {
        var sValue = document.getElementById("cmbRoles").options[document.getElementById("cmbRoles").selectedIndex].value;
        //PageMethods.IsGrabarReglaRol(sValue, listaReglaModificadas, OnCallBackIsGrabarReglaRol, OnFail);
        IsGrabarReglaRol(sValue, listaReglaModificadas);
    }
    return false;
}
function IsGrabarReglaRol(idRol, listaReglaRol) {
    putReglasrol(idRol,listaReglaRol);

}
function OnCallBackIsGrabarReglaRol(args) {
    //    alert(String(args));
}
function LimpiarReglas() {
    for (var i = 0; i < listaReglasRol.length; i++) {
        var ckActivar = document.getElementById("chkActivar_" + String(listaReglasRol[i].id));
        if (ckActivar != null) {
            ckActivar.checked = false;
        }
        var ckAgregar = document.getElementById("chkAgregar_" + String(listaReglasRol[i].id));
        if (ckAgregar != null) {
            ckAgregar.checked = false;
        }
        var ckEditar = document.getElementById("chkEditar_" + String(listaReglasRol[i].id));
        if (ckEditar != null) {
            ckEditar.checked = false;
        }
        var ckEliminar = document.getElementById("chkEliminar_" + String(listaReglasRol[i].id));
        if (ckEliminar != null) {
            ckEliminar.checked = false;
        }
    }
}
function ChangeIndexComboRol() {
    alertGenericClose();
    var sValue = document.getElementById("cmbRoles").options[document.getElementById("cmbRoles").selectedIndex].value;
    LimpiarReglas();
    listaReglasRolSelecciondo = [];
    RecuperarReglasPorRol(sValue);
}

function RecuperarReglasPorRol(sValue) {
    getReglasrol(sValue, 'onCallBackRecuperarReglasPorRol');
}
function onCallBackRecuperarReglasPorRol(args) {
    // var listaResultado = eval('(' + args + ')');
    // listaReglasRolSelecciondo = listaResultado;
    listaReglasRolSelecciondo = args;
    if (listaReglasRolSelecciondo.length > 0) {
        for (var i = 0; i < listaReglasRolSelecciondo.length; i++) {

            var ckActivar = document.getElementById("chkActivar_" + String(listaReglasRolSelecciondo[i].idRegla));
            if (ckActivar != null) {
                listaReglasRolSelecciondo[i].isActivoModificado = listaReglasRolSelecciondo[i].isActivo;
                ckActivar.checked = listaReglasRolSelecciondo[i].isActivo;
            }
            var ckAgregar = document.getElementById("chkAgregar_" + String(listaReglasRolSelecciondo[i].idRegla));
            if (ckAgregar != null) {
                if (listaReglasRolSelecciondo[i].isAgregar != null) {
                    listaReglasRolSelecciondo[i].isAgregarModificado = listaReglasRolSelecciondo[i].isAgregar;
                    ckAgregar.checked = listaReglasRolSelecciondo[i].isAgregar;
                }
            }
            var ckEditar = document.getElementById("chkEditar_" + String(listaReglasRolSelecciondo[i].idRegla));
            if (ckEditar != null) {
                if (listaReglasRolSelecciondo[i].isEditar != null) {
                    listaReglasRolSelecciondo[i].isEditarModificado = listaReglasRolSelecciondo[i].isEditar;
                    ckEditar.checked = listaReglasRolSelecciondo[i].isEditar;
                }
            }
            var ckEliminar = document.getElementById("chkEliminar_" + String(listaReglasRolSelecciondo[i].idRegla));
            if (ckEliminar != null) {
                if (listaReglasRolSelecciondo[i].isEliminar != null) {
                    listaReglasRolSelecciondo[i].isEliminarModificado = listaReglasRolSelecciondo[i].isEliminar;
                    ckEliminar.checked = listaReglasRolSelecciondo[i].isEliminar;
                }
            }
        }
    }
    // if (varIsEditar) {
    //     $("#divSectorArbol").removeAttr('disabled');
    //     $("#btnGuardar").removeAttr('disabled');
    // }
}
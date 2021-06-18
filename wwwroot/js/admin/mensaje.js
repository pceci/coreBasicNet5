function alertGeneric(pValue, pTipo){//alertGeneric
    var html = '<div className="alert alert-warning alert-dismissible fade show " role="alert">';
    html += '<div>';
    html += '<svg xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 16 16" height="24" width="24"><path d="M8.982 1.566a1.13 1.13 0 0 0-1.96 0L.165 13.233c-.457.778.091 1.767.98 1.767h13.713c.889 0 1.438-.99.98-1.767L8.982 1.566zM8 5c.535 0 .954.462.9.995l-.35 3.507a.552.552 0 0 1-1.1 0L7.1 5.995A.905.905 0 0 1 8 5zm.002 6a1 1 0 1 1 0 2 1 1 0 0 1 0-2z" />';
    html += '</svg>';
    html += '&nbsp; &nbsp;' +pValue;
    html += '</div>';
    html += '<button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close" onClick="alertGeneric_close()"></button>';//onclick="' + clickbutton_aceptar + '" 
    html += '</div>';
    document.getElementById('ContentModal').innerHTML = html;
}
function alertGeneric_close(){
    document.getElementById('ContentModal').innerHTML = '';
}
function alertGenericClose() {
    alertGeneric_close();
}
function cerrar_mensaje_confirmar() {
    alertGeneric_close();
}
//    mensaje_confirmar('Información', '<p>¿Desea eliminar la regla?</p>', 'Eliminar','Cancelar' , 'return onclickEliminarRegla();', 'return false;');
function mensaje_confirmar(pTitulo, pMensaje, pNombre_button_aceptar, pNombre_button_cancelar, clickbutton_aceptar, clickbutton_cancelar){//alertGeneric
    var html = '<div className="alert alert-warning alert-dismissible fade show " role="alert">';
    html += '<div>';
    html += '<svg xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 16 16" height="24" width="24"><path d="M8.982 1.566a1.13 1.13 0 0 0-1.96 0L.165 13.233c-.457.778.091 1.767.98 1.767h13.713c.889 0 1.438-.99.98-1.767L8.982 1.566zM8 5c.535 0 .954.462.9.995l-.35 3.507a.552.552 0 0 1-1.1 0L7.1 5.995A.905.905 0 0 1 8 5zm.002 6a1 1 0 1 1 0 2 1 1 0 0 1 0-2z" />';
    html += '</svg>';
    html += '&nbsp; &nbsp;' +pMensaje;
    html += '</div>';
    html += '<button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close" onClick="alertGeneric_close()"></button>';//onclick="' + clickbutton_aceptar + '" 
    html += '<button type="button" class="btn btn-primary" onclick="' + clickbutton_aceptar + '" >' + pNombre_button_aceptar + '</button>';
    document.getElementById('ContentModal').innerHTML = html;
}

function alertSuccess(pValue) {
    alertGeneric(pValue, 'success');
}
function alertDanger(pValue) {
    alertGeneric(pValue, 'danger');
}
function alertInfo(pValue) {
    alertGeneric(pValue, 'info');
}
/*
function alertGeneric_ee(pValue, pTipo) {
    // $('#alertGeneric').removeClass('alert-success');
    // $('#alertGeneric').removeClass('alert-danger');
    // $('#alertGeneric').removeClass('alert-info');
    var cssTipo = '';
    switch (pTipo) {
        case 'success':
            // $('#alertGeneric').addClass('alert-success');
            cssTipo = 'alert-success';
            break;
        case 'danger':
            // $('#alertGeneric').addClass('alert-danger');
            cssTipo = 'alert-danger';
            break;
        case 'info':
            // $('#alertGeneric').addClass('alert-info');
            cssTipo = 'alert-info';
            break;
        default:
            cssTipo = 'alert-info';
            break;
    }
    // $('#alertGenericContent').html(pValue);
    document.getElementById('ContentAlert').innerHTML = getHtmlAlert(pValue, cssTipo);// $('#ContentAlert').html(getHtmlAlert(pValue, cssTipo));
    $('#alertGeneric').alert();
}
function alertGenericClose() {
    //$('#alertGeneric').alert('close');
    var element_alertGeneric = document.getElementById('alertGeneric');
    if (element_alertGeneric != null) {
        element_alertGeneric.classList.add('close');
    }
}

function getHtmlAlert(pValue, pTipo) {
    var result = '';
    result += '<div id="alertGeneric" class="alert ' + pTipo + ' alert-dismissible fade show" role="alert">';
    result += '<button type="button" class="close" data-dismiss="alert" aria-label="Close">';
    result += '<span aria-hidden="true">&times;</span>';
    result += '</button>';
    result += '<div id="alertGenericContent">' + pValue + '</div>';
    result += '</div>';
    return result;
}
function getHtmlModal(pTitulo, pMensaje, pNombre_button_aceptar, pNombre_button_cancelar, clickbutton_aceptar, clickbutton_cancelar) {
    var result = '';
    result += '<div id="modalGeneric" class="modal" tabindex="-1" role="dialog">';
    result += '<div class="modal-dialog" role="document">';
    result += '<div class="modal-content">';
    result += '<div class="modal-header">';
    result += '<h5 class="modal-title">' + pTitulo + '</h5>';
    result += '<button type="button" class="close" data-dismiss="modal" aria-label="Close">';
    result += '<span aria-hidden="true">&times;</span>';
    result += '</button>';
    result += '</div>';
    result += '<div class="modal-body">';
    result += pMensaje;
    result += '</div>';
    result += '<div class="modal-footer">';
    result += '<button type="button" class="btn btn-secondary" data-dismiss="modal" onclick="' + clickbutton_cancelar + '">' + pNombre_button_cancelar + '</button>';
    result += '<button type="button" class="btn btn-primary" onclick="' + clickbutton_aceptar + '" >' + pNombre_button_aceptar + '</button>';
    result += '</div>';
    result += '</div>';
    result += '</div>';
    result += '</div>';
    return result;
}
function mensaje_confirmar_viejo(pTitulo, pMensaje, pNombre_button_aceptar, pNombre_button_cancelar, clickbutton_aceptar, clickbutton_cancelar) {
    var html = getHtmlModal(pTitulo, pMensaje, pNombre_button_aceptar, pNombre_button_cancelar, clickbutton_aceptar, clickbutton_cancelar);
    document.getElementById('ContentModal').innerHTML = html;// $("#ContentModal").html(html);
    $("#modalGeneric").modal();
}
function cerrar_mensaje_confirmar() {
    //$('#modalGeneric').modal('hide');
    var element_modalGeneric = document.getElementById('modalGeneric');
    if (element_modalGeneric != null) {
        element_modalGeneric.classList.add('hide');
    }
}*/

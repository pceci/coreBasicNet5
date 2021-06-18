function CargarArbolCombo() {

    fetch("/admin/CargarArbolCombo")
    .then((response) => {
        return response.json()
    }).then((pResult) => {
        OnCallBackCargarArbolCombo(pResult);
        })
        .catch(error => {
            OnFail(error);
        });

/*
    $.ajax({
        type: "POST",
        url: "/admin/CargarArbolCombo",
        //data: { pIdRegla: pIdRegla, pNombre: pNombre, pPalabra: pPalabra},
        success:
            function (response) {
                OnCallBackCargarArbolCombo(response);
            },
        failure: function (response) {
            OnFail(response);
        },
        error: function (response) {
            OnFail(response);
        }
    });*/
}
function IsNombreOPalabraNoSeRepite(pIdRegla, pNombre, pPalabra) {
    var url = '/admin/IsNombreOPalabraNoSeRepite?';
    fetch(url + new URLSearchParams({
        pIdRegla: pIdRegla,
        pNombre: pNombre,
        pPalabra: pPalabra
    })).then((response) => {
        return response.json()
    })
        .then((pResult) => {
            OnCallBackIsNombreOPalabraNoSeRepiteModificar(pResult);
        })
        .catch(error => {
            OnFail(error);
        });
    /* $.ajax({
         type: "POST",
         url: "/admin/IsNombreOPalabraNoSeRepite",
         data: { pIdRegla: pIdRegla, pNombre: pNombre, pPalabra: pPalabra },
         success:
             function (response) {
                 OnCallBackIsNombreOPalabraNoSeRepiteModificar(response);
             },
         failure: function (response) {
             OnFail(response);
         },
         error: function (response) {
             OnFail(response);
         }
     });*/
}
function ActualizarRegla(pIdRegla, pDescripcion, pPalabra, pAgregar, pEditar, pEliminar, pIdReglaPadre) {
    fetch("/admin/ActualizarRegla?" + new URLSearchParams({
        pIdRegla: pIdRegla, pDescripcion: pDescripcion, pPalabra: pPalabra, pAgregar: pAgregar, pEditar: pEditar, pEliminar: pEliminar, pIdReglaPadre: pIdReglaPadre
    })).then((response) => {
        return response.text() 
    }).then((pResult) => {
        OnCallBackActualizarRegla(pResult);
    }).catch(error => {
        OnFailActualizarRegla(error);
    });

    /*
    .then((response) => {
        return response.json()
    })
    */
    /*
    $.ajax({
        type: "POST",
        url: "/admin/ActualizarRegla",
        data: { pIdRegla: pIdRegla, pDescripcion: pDescripcion, pPalabra: pPalabra, pAgregar: pAgregar, pEditar: pEditar, pEliminar: pEliminar, pIdReglaPadre: pIdReglaPadre },
        success:
            function (response) {
                OnCallBackActualizarRegla(response);
            },
        failure: function (response) {
            OnFailActualizarRegla(response);
        },
        error: function (response) {
            OnFailActualizarRegla(response);
        }
    });*/
}
//InsertarRegla($("#txtNombreReglaInput").val(), $("#txtPalabraClaveInput").val(), $("#CheckBoxSoportadasAgregar").is(':checked'), $("#CheckBoxSoportadasEditar").is(':checked'), $("#CheckBoxSoportadasEliminar").is(':checked'), $("#comboReglasContenidas").val(), OnCallBackInsertarRegla, OnFail);
function InsertarRegla(pDescripcion, pPalabra, pAgregar, pEditar, pEliminar, pIdReglaPadre) {
    fetch("/admin/InsertarRegla?" + new URLSearchParams({
        pDescripcion: pDescripcion, pPalabra: pPalabra, pAgregar: pAgregar, pEditar: pEditar, pEliminar: pEliminar, pIdReglaPadre: pIdReglaPadre
    })).then((response) => {
        return response.text() 
    }).then((pResult) => {
        OnCallBackInsertarRegla(pResult);
    }).catch(error => {
        OnFail(error);
    });
    /*
    $.ajax({
        type: "POST",
        url: "/admin/InsertarRegla",
        data: { pDescripcion: pDescripcion, pPalabra: pPalabra, pAgregar: pAgregar, pEditar: pEditar, pEliminar: pEliminar, pIdReglaPadre: pIdReglaPadre },
        success:
            function (response) {
                OnCallBackInsertarRegla(response);
            },
        failure: function (response) {
            OnFail(response);
        },
        error: function (response) {
            OnFail(response);
        }
    });*/
}
function EliminarRegla(pIdRegla) {
    fetch("/admin/EliminarRegla?" + new URLSearchParams({
        pIdRegla: pIdRegla
    })).then((response) => {
        return response.text() 
    }).then((pResult) => {
        cerrar_mensaje_confirmar();
        OnCallBackEliminarRegla(pResult);
    }).catch(error => {
        cerrar_mensaje_confirmar();
        OnFail(error);
    });
/*
    $.ajax({
        type: "POST",
        url: "/admin/EliminarRegla",
        data: { pIdRegla: pIdRegla },
        success:
            function (response) {
                cerrar_mensaje_confirmar();
                OnCallBackEliminarRegla(response);
            },
        failure: function (response) {
            cerrar_mensaje_confirmar();
            OnFail(response);
        },
        error: function (response) {
            cerrar_mensaje_confirmar();
            OnFail(response);
        }
    });
    */
}
//RecuperarReglaPorId(idReglaSeleccionada, OnCallBackRecuperarReglaPorId, OnFail);
function RecuperarReglaPorId(pIdRegla) {
    fetch("/admin/RecuperarReglaPorId?" + new URLSearchParams({
        pIdRegla: pIdRegla 
    })).then((response) => {
        return response.json() 
    }).then((pResult) => {
        OnCallBackRecuperarReglaPorId(pResult);
    }).catch(error => {
        OnFail(error);
    });
    /*
    $.ajax({
        type: "POST",
        url: "/admin/RecuperarReglaPorId",
        data: { pIdRegla: pIdRegla },
        success:
            function (response) {
                OnCallBackRecuperarReglaPorId(response);
            },
        failure: function (response) {
            OnFail(response);
        },
        error: function (response) {
            OnFail(response);
        }
    });
    */
}
function RecuperarReglaRaiz() {
    fetch("/admin/RecuperarReglaRaiz").then((response) => {
        return response.text() 
    }).then((pResult) => {
        OnCallBackRecuperarReglaPorId(pResult);
    }).catch(error => {
        OnFail(error);
    });
/*
    $.ajax({
        type: "POST",
        url: "/admin/RecuperarReglaRaiz",
        success:
            function (response) {
                OnCallBackRecuperarReglaPorId(response);
            },
        failure: function (response) {
            OnFail(response);
        },
        error: function (response) {
            OnFail(response);
        }
    });
    */
}
function getRoles(pOnCallBack) {
    fetch("/api/roles").then((response) => {
        return response.text() 
    }).then((pResult) => {
        eval(pOnCallBack + '(pResult)');
    }).catch(error => {
        OnFail(error);
    });
    /*
    $.ajax({
        type: "GET",
        url: "/api/roles",
        success: function (response) {
            eval(pOnCallBack + '(response)');
        },
        failure: function (response) {
            OnFail(response);
        },
        error: function (response) {
            OnFail(response);
        }
    });
    */
}
function getReglasrol(id, pOnCallBack) {
    fetch("/api/reglasrol/" + id).then((response) => {
        return response.json() 
    }).then((pResult) => {
        eval(pOnCallBack + '(pResult)'); 
    }).catch(error => {
        OnFailActualizarRegla(error);
    });

    /*
    $.ajax({
        type: "GET",
        url: "/api/reglasrol/" + id,
        success: function (response) {
            eval(pOnCallBack + '(response)');
        },
        failure: function (response) {
            OnFail(response);
        },
        error: function (response) {
            OnFail(response);
        }
    });*/
}
/*function getReglasrol(id, pOnCallBack) {
    $.ajax({
        type: "GET",
        url: "/api/reglasrol/" + id,
        success: function (response) {
            eval(pOnCallBack + '(response)');
        },
        failure: function (response) {
            OnFail(response);
        },
        error: function (response) {
            OnFail(response);
        }
    });
}*/
function putReglasrol(id, listReglasRol) {
    var url = '/api/reglasrol/' + id;

    // Set up our HTTP request
    var xhr = new XMLHttpRequest();
    xhr.open("PUT", url, true);
    xhr.setRequestHeader('Content-type', 'application/json; charset=utf-8');

    // var data = {};
    // data.firstname = "John2";
    // data.lastname  = "Snow2";
    var json = JSON.stringify(listReglasRol);

    // Setup our listener to process completed requests
    xhr.onload = function () {

        // Process our return data
        if (xhr.status >= 200 && xhr.status < 300) {
            // What do when the request is successful
            // alert('success!', xhr);
            alertSuccess('Se grabo correctamente.');
        } else {
            // What do when the request fails
            // alert('The request failed!');
            OnFail(xhr);
        }

        // Code that should run regardless of the request status
        // alert('This always runs...');
    };

    // Create and send a GET request
    // The first argument is the post type (GET, POST, PUT, DELETE, etc.)
    // The second argument is the endpoint URL
    // xhr.open('PUT', '/api/reglasrol/' + id);
    xhr.send(json);

}
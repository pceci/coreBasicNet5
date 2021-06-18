function OnCallBack_getRoles_Combo(args) {
    args.forEach(x => {
        //alert(x.rol_Nombre);
        document.getElementById("cmbRoles").appendChild(new Option(x.nombre, x.id));
    });
}
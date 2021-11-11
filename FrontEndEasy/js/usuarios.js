document.addEventListener("DOMContentLoaded", function(event) { 
    let objetoCliente = localStorage.getItem("Cliente");
    console.log(JSON.parse(objetoCliente));
    sendDataAjax();


    let divUsuario = document.getElementById('divUsuario');
    let divReporte = document.getElementById('divReporte');
    let divCliente = document.getElementById('divClientes');
    let divProducto = document.getElementById('divProductos');
    let divRegistroCliente = document.getElementById('divRegistroCliente');
    let divListadoCliente = document.getElementById('divListadoCliente');
    let divRegistroProducto = document.getElementById('divRegistroProducto');
    let divListadoProducto = document.getElementById('divListadoProducto');
    let divModificarCliente = document.getElementById('divModificarCliente');
    let divSalir = document.getElementById('divSalir');
    let divSalirText = document.getElementById('divSalirText');

    let ingreso = document.getElementById('ingreso');  
    let bienvenido = document.getElementById('bienvenido');

    if (objetoCliente !== null) {
        // if (JSON.parse(objetoCliente).nombreUsuario !== null && JSON.parse(objetoCliente).nombreUsuario !== undefined) {
        //     divUsuario.style.display = "none";
        //     divReporte.style.display = "none";
        //     divModificarCliente.style.display = "none";
        //     divListadoCliente.style.display = "none";
        //     divListadoProducto.style.display = "none";
        //     divRegistroProducto.style.display = "none";
        //     divSalir.style.display = "none";
        //     divSalirText.style.display = "none";
        // }
        if (JSON.parse(objetoCliente).rol === 'cliente') {
            divUsuario.style.display = "none";
            divReporte.style.display = "none";
            divRegistroCliente.style.display = "none";
            divListadoCliente.style.display = "none";
            divListadoProducto.style.display = "none";
            divRegistroProducto.style.display = "none";
            ingreso.style.display = "none";
            console.log(bienvenido.value);
            bienvenido.innerText = 'Bienvenido/a ' + JSON.parse(objetoCliente).nombreCliente;
        }else if(JSON.parse(objetoCliente).rol === 'admin'){
            ingreso.style.display = "none";
            bienvenido.innerText = 'Bienvenido/a ' + JSON.parse(objetoCliente).nombreCliente;
        }else if (JSON.parse(objetoCliente).rol === 'encargado') {
            divUsuario.style.display = "none";
            divReporte.style.display = "none";
            divCliente.style.display = "none";
            ingreso.style.display = "none";
            bienvenido.innerText = 'Bienvenido/a ' + JSON.parse(objetoCliente).nombreCliente;
        }
        else if (JSON.parse(objetoCliente).rol === 'gerente') {
            divUsuario.style.display = "none";
            divProducto.style.display = "none";
            divCliente.style.display = "none";
            ingreso.style.display = "none";
            bienvenido.innerText = 'Bienvenido/a ' + JSON.parse(objetoCliente).nombreCliente;
        }
    }else{
            divUsuario.style.display = "none";
            divReporte.style.display = "none";
            divModificarCliente.style.display = "none";
            divListadoCliente.style.display = "none";
            divListadoProducto.style.display = "none";
            divRegistroProducto.style.display = "none";
            divSalir.style.display = "none";
            divSalirText.style.display = "none";
    }

    
});

var tabla, data;




function addRowDT(data) {
    tabla = $("#tblUsuarios").dataTable({
        language: {
            "search": "Buscar: ",
            "emptyTable": "No hay información",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        }
    });

    //tabla.fnClearTable();
    console.log(data);
    for (var i = 0; i <= data.length; i++) {
        tabla.fnAddData([
            data[i].nombreCompleto,
            data[i].nombreUsuario,
            data[i].tipoDocumento,
            data[i].documento,
            data[i].telefono,
            data[i].rol,
            '<button type="button" value="Actualizar" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal" id="btnAbrirModalEdit" onclick="abrirModal();"><i class="fa fa-pencil" aria-hidden="true"></i></button><button type="button" id="eliminar" value="Eliminar" class="btn btn-danger ml-1" data-bs-toggle="modal" data-bs-target="#staticBackdrop2" onclick="abrirModalEliminar()"><i class="fa fa-trash" aria-hidden="true"></i></button>'
            
        ])
    }
}



function sendDataAjax() {
    $.ajax({
        type: "GET",
        url: "https://localhost:44375/Usuarios/listado",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            addRowDT(data);
        },
        error: function (response) {
            swal(response);
        }
    })
}



//OBTENER DATOS DE UNA FILA
// $(document).on('click', '#btnAbrirModalEdit', function (e) {
//     e.preventDefault();
//     let row = $(this).parent().parent();
//     data = tabla.fnGetData(row);
//     fillModalData();

// });

//CAGAR DATOS EN EL MODAL ACTUALIZAR
// function fillModalData() {
//     $("#txtIdCliente").val(data[0]);
//     $("#txtNombreAct>").val(data[1]);
//     $("#txtApellidoAct").val(data[2]);
//     $("#cboTipoDocAct").val(data[3]);
//     $("#txtDocumentoAct").val(data[4]);
//     $("#txtTelefonoAct").val(data[5]);
//     $("#txtComisionAct").val(data[6]);

// }

//Cerrar Modal Actualizar
// function cerrarModalActualizar() {
//     $("#modalActualizar").modal("hide");
// }

//Abrir Modal Actualizar
// function abrirModalActualizar() {
//     $('#modalActualizar').modal('show');
// }


// $(document).on('click', '#btnAbrirModalEdit', function (e) {
//     e.preventDefault();
//     let row = $(this).parent().parent();
//     data = tabla.fnGetData(row);
//     fillModalData();

// });

// //CAGAR DATOS EN EL MODAL ACTUALIZAR
// function fillModalData() {
//     $("#txtIdAct").val(data[0]);
//     $("#txtNombreAct").val(data[1]);
//     $("txtApellidoAct").val(data[2]);
//     $("#txtPasswordAct").val(data[3]);
//     $("#txtEmailAct").val(data[5]);
//     $("#txtTelefonoAct").val(data[6]);
//     $("#txtDocumentoAct").val(data[7]);
//     $("#txtDireccionAct").val(data[8]);
//     $("#cboRolAct").val(data[9]);
    

// }




function abrirModal(){
    // Swal.fire('hola');
    document.getElementById('modalActualizar').style.backgroundColor  = "rgba(0,0,0,0.5)";
    document.getElementById('modalActualizar').style.display   = "block";
    setTimeout(() => { document.getElementById('modalActualizar').style.opacity = 2; }, 200);
    // $('#modalActualizar').modal();
    
}



function cerrarModal(){
    document.getElementById('modalActualizar').style.display   = "none";
    document.getElementById('modalActualizar').style.opacity   = 0;
}

salir.addEventListener('click', cerrarSesion);

    function cerrarSesion(){
        localStorage.removeItem('Cliente');
    }
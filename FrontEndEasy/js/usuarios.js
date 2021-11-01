document.addEventListener("DOMContentLoaded", function(event) { 
    sendDataAjax();
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
            '<button type="button" value="Actualizar" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#staticBackdrop2" onclick="abrirModalActualizar()" id="btnAbrirModalEdit"><i class="fa fa-pencil" aria-hidden="true"></i></button><button type="button" id="eliminar" value="Eliminar" class="btn btn-danger ml-1" data-bs-toggle="modal" data-bs-target="#staticBackdrop2" onclick="abrirModalEliminar()"><i class="fa fa-trash" aria-hidden="true"></i></button>'
            
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
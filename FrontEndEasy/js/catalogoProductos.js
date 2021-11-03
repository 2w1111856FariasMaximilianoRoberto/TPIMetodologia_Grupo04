document.addEventListener("DOMContentLoaded", function(event) { 
    
    let objetoCliente = localStorage.getItem("objetoCliente");
    console.log(JSON.parse(objetoCliente));


    let divUsuario = document.getElementById('divUsuario');
    let divReporte = document.getElementById('divReporte');
    let divRegistroCliente = document.getElementById('divRegistroCliente');
    let divListadoCliente = document.getElementById('divListadoCliente');
    let divRegistroProducto = document.getElementById('divRegistroProducto');
    let divListadoProducto = document.getElementById('divListadoProducto');
    let divModificarCliente = document.getElementById('divModificarCliente');
    let divSalir = document.getElementById('divSalir');
    let divSalirText = document.getElementById('divSalirText');

    let ingreso = document.getElementById('ingreso');  
    let bienvenido = document.getElementById('bienvenido');

    if (JSON.parse(objetoCliente) === null || JSON.parse(objetoCliente) === undefined) {
        divUsuario.style.display = "none";
        divReporte.style.display = "none";
        divModificarCliente.style.display = "none";
        divListadoCliente.style.display = "none";
        divListadoProducto.style.display = "none";
        divRegistroProducto.style.display = "none";
        divSalir.style.display = "none";
        divSalirText.style.display = "none";
    }
    else if (JSON.parse(objetoCliente).rol === 'Cliente') {
        divUsuario.style.display = "none";
        divReporte.style.display = "none";
        divRegistroCliente.style.display = "none";
        divListadoCliente.style.display = "none";
        divListadoProducto.style.display = "none";
        divRegistroProducto.style.display = "none";
        ingreso.style.display = "none";
        console.log(bienvenido.value);
        bienvenido.innerText = 'Bienvenido/a ' + JSON.parse(objetoCliente).nombreCliente;
    }
    
    $.ajax({
        url: "https://localhost:44375/Produtos",
        type: "GET",
        success: function (data){ 
            cargarCard(data);
        },
        error: function(error){
            console.log(error);
        }
    });
         



});



salir.addEventListener('click', cerrarSesion);

function cerrarSesion(){
    localStorage.removeItem('objetoCliente');
}







          




function cargarCard(data) {
    console.log(data);
    console.log(imagenes);
    // for (let i = 0; i < imagenes.length; i++) {
        for (let j = 0; j < data.length; j++) {
            const imagen = imagenes.find(o => o.idProducto === data[j].idProducto);
            if (imagen) {
                let html = "<div class='col-3 mt-2' >";
                html += "<div class='card'  style='width: 16rem;'>";
                html += "<img src="+imagen.png+" class='card-img-top'>";
                html += "<div class='card-body'>";
                html += "<h5 class='card-title'>"+data[j].descripcion+"</h5>";
                html += "<strong class='mr-4' style='font-size: larger;'>"+data[j].precioVenta+"</strong>";
                html += `<a href=masDetalle.html?idProducto=${data[j].idProducto} class='btn btn-primary'>Mas detalles...</a>`;
                html += "</div>";
                html += "</div>";
                html += "</div>";

                $("#cardProductos").append(html);
            }
            
        }
    // }
    
    console.log(imagenes);
}
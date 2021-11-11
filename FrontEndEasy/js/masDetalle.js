let productoSeleccionado = {};
let idProducto = 0;
let cantidadArticulos;

document.addEventListener("DOMContentLoaded", function(event) { 
    
    let objetoCliente = localStorage.getItem("Cliente");
    console.log(JSON.parse(objetoCliente));


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


    //aca va el btnAgregarCarro
    
    

    const params = new URLSearchParams(window.location.search);
    if (params.has('idProducto')) {
        idProducto = params.get('idProducto');
        
        $.ajax({
            url: "https://localhost:44375/Produtos/"+idProducto,
            type: "GET",
            success: function (data){ 
                productoSeleccionado = data;
                const imagen = imagenes.find(o => o.idProducto === data.idProducto);
                const html = `<div class="card" >
                <img src="${imagen.png}" class="card-img-top" alt="...">
                <div class="card-body">
                  <h5 class="card-title">${data.descripcion}</h5>
                  <p class="card-text">${data.descripcion}</p>
                </div>
                <ul class="list-group list-group-flush">
                  <li class="list-group-item">Tipo: Parrilla a Gas</li>
                  <li class="list-group-item">Color: ${data.color}</li>
                  <li class="list-group-item">Marca: ${data.idMarca}</li>
                  <li class="list-group-item">Dimenciones: ${data.dimenciones}</li>
                  <li class="list-group-item">Uso: 10 a 12 comensales</li>
                  <li class="list-group-item">Modelo: ${data.modelo}</li>
                  <li class="list-group-item">Stock: ${data.stock}</li>
                </ul>
            </div>`;
            $('#cardDetalle').html(html);

            $('#tituloProducto').append(data.descripcion);
            $('#precioProducto').append(data.precioVenta);
            },
            error: function(error){
                console.log(error);
            }
        });



    }





});

$('#btnAgregarCarro').click(function(){
    let productosSeleccionados = JSON.parse(localStorage.getItem('productosSeleccionados'));
    if (!productosSeleccionados) {
        productosSeleccionados =[];
    }
    productosSeleccionados.push(productoSeleccionado);
    
    //Validar que el producto no exista en la lista
    localStorage.setItem('productosSeleccionados',JSON.stringify(productosSeleccionados));
    
    cantidadArticulos = document.getElementById('txtCantidad').value;
    localStorage.setItem(`cantidadArticulo${idProducto}`,JSON.stringify(cantidadArticulos));
});



salir.addEventListener('click', cerrarSesion);

function cerrarSesion(){
    localStorage.removeItem('Cliente');
}
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
    

});



salir.addEventListener('click', cerrarSesion);

function cerrarSesion(){
    localStorage.removeItem('objetoCliente');
}
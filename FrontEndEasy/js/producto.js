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
});


let btnRegistrar = document.getElementById('btnRegistrar');

let descripcion;
let color;
let dimensiones;
let modelo;
let precioCompra;
let precioVenta;
let marca;
let rubro;
let stock;


// VALIDACION




//VALIDAR INICIO DE SESION


//METODO PARA HACER EL REGISTRO

btnRegistrar.addEventListener('click', registrar);

function registrar(){
    descripcion = document.getElementById('txtDescripcion').value;
    color = document.getElementById('txtColor').value;
    dimensiones = document.getElementById('txtDimension').value;
    modelo = document.getElementById('txtModelo').value;
    rubro = document.getElementById('cboRubro').value;
    marca = document.getElementById('cboMarca').value;
    precioCompra = document.getElementById('txtPrecioCompra').value;
    precioVenta = document.getElementById('txtPrecioVenta').value;
    stock = document.getElementById('txtStock').value;
    

    comando  = {
        "descripcion": descripcion,
        "color": color,
        "dimenciones": dimensiones,
        "modelo": modelo,
        "precioCompra": precioCompra,
        "precioVenta": precioVenta,
        "idMarca": 1,
        "idRubro": 1,
        "stock": stock
    };


    $.ajax({
        url: "https://localhost:44375/Produtos",
        type: "POST",
        dataType: 'json',
        contentType: "application/json",
        data: JSON.stringify(comando), 
        success: function (response){ 
            console.log(response);
            alert('registro exitos')
            console.log(comando);
            
        },
        error: function(error){
            console.log(error.responseJSON.errors);
            console.log("Error");
        }
    });

    
}

imgInp.onchange = evt => {
    const [file] = imgInp.files
    if (file) {
      blah.src = URL.createObjectURL(file)
    }
  }


salir.addEventListener('click', cerrarSesion);

    function cerrarSesion(){
        localStorage.removeItem('Cliente');
    }
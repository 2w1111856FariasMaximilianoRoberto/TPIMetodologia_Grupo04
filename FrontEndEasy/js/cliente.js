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

salir.addEventListener('click', cerrarSesion);

function cerrarSesion(){
    localStorage.removeItem('Cliente');
}


let btnRegistrar = document.getElementById('btnRegistrar');

let nombre;
let apellido;
let email;
let telefono;
let select;
let documento;
let userName;
let direccion;
let password;
let confPassword;
let sexo = document.querySelector('input[name="genero"]:checked').value;


// VALIDACION




//VALIDAR INICIO DE SESION


//METODO PARA HACER EL REGISTRO

btnRegistrar.addEventListener('click', registrar);

function registrar(){
    nombre = document.getElementById('txtNombre').value;
    apellido = document.getElementById('txtApellido').value;
    email = document.getElementById('txtEmail').value;
    telefono = document.getElementById('txtTelefono').value;
    select = document.getElementById('cboTipoDocumento').value;
    documento = document.getElementById('txtDocumento').value;
    userName = document.getElementById('txtNombreUsuario').value;
    direccion = document.getElementById('txtDireccion').value;
    password = document.getElementById('txtPassword').value;
    confPassword = document.getElementById('txtConfirmarPassword').value;
    // sexo = document.querySelector('input[name="genero"]:checked').value;

    comando  = {
        "nombreCliente": nombre,
        "nombreUsuario": userName,
        "apellidoCliente": apellido,
        "sexo" : "Femenino",
        "contraseña": password,
        "email": email,
        "telefono": telefono,
        "documento": documento,
        "direccion": direccion,
        "idTipoDocumento": 1,
        "idBarrio": 1
    };


    $.ajax({
        url: "https://localhost:44375/Clientes",
        type: "POST",
        dataType: 'json',
        contentType: "application/json",
        data: JSON.stringify(comando), 
        success: function (response){ 
            console.log(response);
            // alert('registro exitos')
            window.location.replace('login2.html');
            
        },
        error: function(error){
            console.log(error.responseJSON.errors);
        }
    });
}



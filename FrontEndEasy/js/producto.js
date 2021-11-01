document.addEventListener("DOMContentLoaded", function(event) { 
    
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
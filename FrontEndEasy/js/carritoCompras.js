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
    

    let productosSeleccionados = localStorage.getItem('productosSeleccionados');
    if (productosSeleccionados) {
        productosSeleccionados = JSON.parse(productosSeleccionados);
    }
    const cabecera= [];
    const detalle= [];

    productosSeleccionados.forEach(element => {
        
        const imagen = imagenes.find(o => o.idProducto === element.idProducto);
        let cantidadArticulo = localStorage.getItem(`cantidadArticulo${element.idProducto}`);
        
        let cantidad = JSON.parse(cantidadArticulo)
        let subTotal = cantidad * element.precioVenta;
        detalle.push(`<tr id="${element.idProducto}">
        <!-- <th scope="row">${element.idProducto}</th> -->
        <td>
          <img
            src="${imagen.png}"
            alt=""
            style="width: 75px; height: 75px"
          />
        </td>
        <td>$${element.precioVenta}</td>
        <td>
          <p>
            <input
              type="number"
              name="cantidadPoductos"
              min="1"
              max="100"
              step="1"
              value =${cantidadArticulo}
            />
          </p>
        </td>
        <th scope="row">$${subTotal}</th>
        <th>
          <button  class="btn btn-danger" id="btnEliminar" onclick="eliminar(${element.idProducto});"
            ><i class="fa fa-trash" aria-hidden="true">
              Eliminar
            </i>
          </button>
        </th>
      </tr>`);
    });

    

    const html = `<table class="table table-hover">
    <thead>
      <tr>
        <!-- <th scope="col">#</th> -->
        <th scope="col">Producto</th>
        <th scope="col">Precio</th>
        <th scope="col">Cantidad</th>
        <th scope="col">Subtotal</th>
        <th scope="col"></th>
      </tr>
    </thead>
    <tbody>
      
      ${detalle.join('')}
    </tbody>
  </table>`;
  $('#tblCarrito').html(html);


    obtenerTotal();


});

$('#btnEliminar').click(function(){
  
});

// function removeLocalStorageValues(target) {
//   let i = localStorage.length;
//   while (i-- > 0) {
//       let key = localStorage.key(i);
//       if (localStorage.getItem(key) === target) {
//           localStorage.removeItem(key);
//       }
//   }
// }


//Eliminar fila y objeto del array Json
function eliminar(idRow) { 
  $(`#${idRow}`).remove();
  let productos = JSON.parse(localStorage.getItem('productosSeleccionados'));
  let p = productos.find(element => element.idProducto === idRow);
  productos.splice(p,1);
  let productosJSON = JSON.stringify(productos);
  localStorage.setItem('productosSeleccionados', productosJSON);
}


function obtenerTotal(){
  let productos = JSON.parse(localStorage.getItem('productosSeleccionados'));
  let total = 0;
  let totalH5 = document.getElementById('total');
  let subtotalP = document.getElementById('subTotal');
  productos.forEach(element => {
    let cantidadArticulo = localStorage.getItem(`cantidadArticulo${element.idProducto}`);
    let cantidad = JSON.parse(cantidadArticulo)
    total = total + element.precioVenta * cantidad;
  });
  console.log(total);
  subtotalP.innerHTML = "$" + total.toString(); // Subtotal deberia ser - descuento
  totalH5.innerHTML = "$" + total.toString();
  // totalH5.value = total;
}



salir.addEventListener('click', cerrarSesion);

function cerrarSesion(){
    localStorage.removeItem('Cliente');
}

pagar.addEventListener('click', pagoExitoso);
function pagoExitoso(){
  let Cliente = localStorage.getItem("Cliente");
  if (Cliente === null) {
    window.location.replace('login2.html');
  }else{
    Swal.fire({
      icon: 'success',
      title: 'Listo...',
      text: 'Pedido realizado con exito!!',
      showConfirmButton: false,
      footer: '<a href="index.html">Cerrar</a>'
    })
  }
 
  // localStorage.removeItem('Cliente');
}

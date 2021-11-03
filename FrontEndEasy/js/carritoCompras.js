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
    

    let productosSeleccionados = localStorage.getItem('productosSeleccionados');
    if (productosSeleccionados) {
        productosSeleccionados = JSON.parse(productosSeleccionados);
    }
    const cabecera= [];
    const detalle= [];

    productosSeleccionados.forEach(element => {
        
        const imagen = imagenes.find(o => o.idProducto === element.idProducto);
        detalle.push(`<tr>
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
            />
          </p>
        </td>
        <th scope="row">$170.000</th>
        <th>
          <a href="" class="adelete"
            ><i class="fa fa-trash" aria-hidden="true">
              Eliminar</i
            ></a
          >
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





});



salir.addEventListener('click', cerrarSesion);

function cerrarSesion(){
    localStorage.removeItem('objetoCliente');
}
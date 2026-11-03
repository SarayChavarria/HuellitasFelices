
document.addEventListener("DOMContentLoaded", function () {

    // Recuperar el carrito guardado en el navegador
    let carrito = JSON.parse(localStorage.getItem("carrito")) || [];

    // Guardar los cambios del carrito
    function guardarCarrito() {
        localStorage.setItem("carrito", JSON.stringify(carrito));
    }

    // Agregar productos al carrito
    const botonesAgregar = document.querySelectorAll(".btn-agregar-carrito");

    botonesAgregar.forEach(function (boton) {

        boton.addEventListener("click", function () {

            const id = parseInt(boton.dataset.id);
            const nombre = boton.dataset.nombre;
            const precio = parseFloat(boton.dataset.precio);
            const stock = parseInt(boton.dataset.stock);

            // Buscar si el producto ya está en el carrito
            const productoExistente = carrito.find(function (producto) {
                return producto.id === id;
            });

            if (productoExistente) {

                if (productoExistente.cantidad < stock) {
                    productoExistente.cantidad++;
                } else {
                    alert("No hay más unidades disponibles de este producto.");
                    return;
                }

            } else {

                carrito.push({
                    id: id,
                    nombre: nombre,
                    precio: precio,
                    cantidad: 1,
                    stock: stock
                });

            }

            guardarCarrito();

            alert(nombre + " se agregó al carrito 🛒");

        });

    });

});

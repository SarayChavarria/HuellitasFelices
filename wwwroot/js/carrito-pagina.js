
document.addEventListener("DOMContentLoaded", function () {

    // Recuperar el carrito guardado
    let carrito = JSON.parse(localStorage.getItem("carrito")) || [];

    const tablaCarrito = document.getElementById("tabla-carrito");
    const carritoVacio = document.getElementById("carrito-vacio");
    const contenidoCarrito = document.getElementById("contenido-carrito");
    const totalCarrito = document.getElementById("total-carrito");
    const botonVaciar = document.getElementById("vaciar-carrito");

    // Formatear valores como pesos colombianos
    function formatoCOP(valor) {
        return valor.toLocaleString("es-CO");
    }

    // Guardar el carrito en localStorage
    function guardarCarrito() {
        localStorage.setItem("carrito", JSON.stringify(carrito));
    }

    // Mostrar los productos del carrito
    function mostrarCarrito() {

        tablaCarrito.innerHTML = "";

        if (carrito.length === 0) {
            carritoVacio.style.display = "block";
            contenidoCarrito.style.display = "none";
            return;
        }

        carritoVacio.style.display = "none";
        contenidoCarrito.style.display = "block";

        let total = 0;

        carrito.forEach(function (producto) {

            const subtotal = producto.precio * producto.cantidad;

            total += subtotal;

            const fila = document.createElement("tr");

            fila.innerHTML = `
                <td>${producto.nombre}</td>

                <td>$${formatoCOP(producto.precio)}</td>

                <td>
                    <div class="d-flex align-items-center gap-2">

                        <button class="btn btn-sm btn-outline-success"
                                data-accion="disminuir"
                                data-id="${producto.id}">
                            -
                        </button>

                        <span>${producto.cantidad}</span>

                        <button class="btn btn-sm btn-outline-success"
                                data-accion="aumentar"
                                data-id="${producto.id}">
                            +
                        </button>

                    </div>
                </td>

                <td>$${formatoCOP(subtotal)}</td>

                <td>
                    <button class="btn btn-sm btn-outline-danger"
                            data-accion="eliminar"
                            data-id="${producto.id}">
                        Eliminar
                    </button>
                </td>
            `;

            tablaCarrito.appendChild(fila);

        });

        totalCarrito.textContent = formatoCOP(total);
    }

    // Gestionar los botones de la tabla
    tablaCarrito.addEventListener("click", function (evento) {

        const boton = evento.target.closest("button");

        if (!boton) {
            return;
        }

        const id = parseInt(boton.dataset.id);
        const accion = boton.dataset.accion;

        const producto = carrito.find(function (p) {
            return p.id === id;
        });

        if (!producto) {
            return;
        }

        if (accion === "aumentar") {

            if (producto.cantidad < producto.stock) {
                producto.cantidad++;
            } else {
                alert("No hay más unidades disponibles.");
            }

        }

        if (accion === "disminuir") {

            if (producto.cantidad > 1) {
                producto.cantidad--;
            } else {
                carrito = carrito.filter(function (p) {
                    return p.id !== id;
                });
            }

        }

        if (accion === "eliminar") {

            carrito = carrito.filter(function (p) {
                return p.id !== id;
            });

        }

        guardarCarrito();
        mostrarCarrito();

    });

    // Vaciar todo el carrito
    botonVaciar.addEventListener("click", function () {

        const confirmar = confirm(
            "¿Estás segura de que deseas vaciar el carrito?"
        );

        if (confirmar) {
            carrito = [];
            guardarCarrito();
            mostrarCarrito();
        }

    });

    // Mostrar el carrito al abrir la página
    mostrarCarrito();

});

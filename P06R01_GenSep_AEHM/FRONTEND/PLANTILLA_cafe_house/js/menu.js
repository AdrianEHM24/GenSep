// js/menu.js

async function cargarProductosMenu() {
    const contenedor = document.getElementById('productos-container');
    const molde = document.getElementById('producto-molde');
    const menuLateral = document.getElementById('menu-lateral');

    if (!contenedor || !molde) return;

    // Limpia productos previos (deja el molde)
    contenedor.querySelectorAll('.tm-product:not(#producto-molde)').forEach(el => el.remove());
    if (menuLateral) menuLateral.innerHTML = '';

    try {
        const productos = await apiFetch(API_CONFIG.ENDPOINTS.productos);
        renderProductos(productos, contenedor, molde);
        renderMenuLateral(productos, menuLateral);
    } catch (error) {
        console.error('Error al cargar productos:', error);
        contenedor.insertAdjacentHTML('beforeend',
            `<p class="text-danger">No se pudieron cargar los productos.</p>`);
    }
}

function renderProductos(productos, contenedor, molde) {
    if (!productos || productos.length === 0) {
        contenedor.insertAdjacentHTML('beforeend',
            `<p class="gray-text">No hay productos disponibles por el momento.</p>`);
        return;
    }

    productos.forEach((p) => {
        const clon = molde.cloneNode(true);
        clon.id = `producto-${p.productoID}`;
        clon.style.display = '';

        // Nombre
        clon.querySelector('.tm-product-title').textContent = p.nombre ?? 'Sin nombre';

        // Descripción = Categoría · Stock
        clon.querySelector('.tm-product-description').innerHTML =
            `<span class="producto-categoria">${p.categoria ?? ''}</span> · ` +
            `<span class="producto-stock">Stock: ${p.stock ?? 0}</span>`;

        // Precio formateado
        clon.querySelector('.tm-product-price-amount').textContent =
            Number(p.precio).toLocaleString('es-MX', {
                minimumFractionDigits: 2,
                maximumFractionDigits: 2
            });

        contenedor.appendChild(clon);
    });
}

function renderMenuLateral(productos, menuLateral) {
    if (!menuLateral || !productos) return;

    productos.forEach((p, index) => {
        const li = document.createElement('li');
        const a = document.createElement('a');
        a.href = `#producto-${p.productoID}`;
        a.textContent = p.nombre ?? '';
        if (index === 0) a.classList.add('active');
        li.appendChild(a);
        menuLateral.appendChild(li);
    });
}

document.addEventListener('DOMContentLoaded', () => {
    if (document.getElementById('productos-container')) {
        cargarProductosMenu();
    }
});
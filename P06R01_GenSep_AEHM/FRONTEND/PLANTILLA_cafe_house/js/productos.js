// js/productos.js

async function cargarProductos() {
    const tbody = document.getElementById('tabla-productos-body');
    const alertError = document.getElementById('alert-error');
    const loading = document.getElementById('loading');

    if (!tbody) return;

    // Reset visual
    alertError.style.display = 'none';
    loading.style.display = 'block';
    tbody.innerHTML = '';

    try {
        const productos = await apiFetch(API_CONFIG.ENDPOINTS.productos);
        renderProductos(productos, tbody);
    } catch (error) {
        console.error('Error al cargar productos:', error);
        alertError.textContent = `No se pudieron cargar los productos: ${error.message}`;
        alertError.style.display = 'block';
    } finally {
        loading.style.display = 'none';
    }
}

function renderProductos(productos, tbody) {
    if (!productos || productos.length === 0) {
        tbody.innerHTML = `
            <tr>
                <td colspan="6" class="tm-pedidos-empty">
                    No hay productos registrados por el momento.
                </td>
            </tr>`;
        return;
    }

    tbody.innerHTML = productos.map(p => `
        <tr>
            <td class="tm-pedido-id">#${p.productoID}</td>
            <td>${p.nombre ?? ''}</td>
            <td>
                <span class="tm-pedido-estado estado-default">
                    ${p.categoria ?? ''}
                </span>
            </td>
            <td class="tm-pedido-total">$${formatearMoneda(p.precio)}</td>
            <td>
                ${p.stock > 0
                    ? `<span class="tm-pedido-estado estado-completado">${p.stock}</span>`
                    : `<span class="tm-pedido-estado estado-pendiente">Agotado</span>`}
            </td>
            <td>${formatearFecha(p.fechaCreacion)}</td>
        </tr>
    `).join('');
}

function formatearMoneda(valor) {
    return Number(valor || 0).toLocaleString('es-MX', {
        minimumFractionDigits: 2,
        maximumFractionDigits: 2
    });
}

function formatearFecha(fechaISO) {
    if (!fechaISO) return '-';
    const fecha = new Date(fechaISO);
    return fecha.toLocaleDateString('es-MX', {
        day: '2-digit',
        month: '2-digit',
        year: 'numeric'
    });
}

document.addEventListener('DOMContentLoaded', () => {
    if (document.getElementById('tabla-productos-body')) {
        cargarProductos();
    }

    const btnRefrescar = document.getElementById('btn-refrescar');
    if (btnRefrescar) {
        btnRefrescar.addEventListener('click', cargarProductos);
    }
});
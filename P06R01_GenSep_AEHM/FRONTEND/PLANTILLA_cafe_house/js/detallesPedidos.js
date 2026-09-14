// js/detallesPedidos.js

async function cargarDetallesPedidos() {
    const tbody = document.getElementById('detalles-tbody');
    const alertError = document.getElementById('alert-error');
    const loading = document.getElementById('loading');

    if (!tbody) return;

    // Reset visual
    alertError.style.display = 'none';
    loading.style.display = 'block';
    tbody.innerHTML = '';

    try {
        const detalles = await apiFetch(API_CONFIG.ENDPOINTS.detallesPedidos);
        renderDetalles(detalles, tbody);
    } catch (error) {
        console.error('Error al cargar detalles de pedidos:', error);
        alertError.textContent = `No se pudieron cargar los detalles: ${error.message}`;
        alertError.style.display = 'block';
    } finally {
        loading.style.display = 'none';
    }
}

function renderDetalles(detalles, tbody) {
    if (!detalles || detalles.length === 0) {
        tbody.innerHTML = `
            <tr>
                <td colspan="6" class="tm-pedidos-empty">
                    No hay detalles de pedidos registrados por el momento.
                </td>
            </tr>`;
        return;
    }

    tbody.innerHTML = detalles.map(d => {
        const subtotal = Number(d.cantidad) * Number(d.precioUnitario);
        return `
            <tr>
                <td class="tm-pedido-id">#${d.detalleID}</td>
                <td>#${d.pedidoID ?? '-'}</td>
                <td>#${d.productoID ?? '-'}</td>
                <td>${d.cantidad ?? 0}</td>
                <td class="tm-pedido-total">$${formatearMoneda(d.precioUnitario)}</td>
                <td class="tm-pedido-total">$${formatearMoneda(subtotal)}</td>
            </tr>
        `;
    }).join('');
}

function formatearMoneda(valor) {
    return Number(valor || 0).toLocaleString('es-MX', {
        minimumFractionDigits: 2,
        maximumFractionDigits: 2
    });
}

document.addEventListener('DOMContentLoaded', () => {
    if (document.getElementById('detalles-tbody')) {
        cargarDetallesPedidos();
    }
});
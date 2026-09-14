// js/pedidos.js

async function cargarPedidos() {
    const tbody = document.getElementById('pedidos-tbody');
    const alertError = document.getElementById('alert-error');
    const loading = document.getElementById('loading');

    if (!tbody) return;

    // Reset visual
    alertError.style.display = 'none';
    loading.style.display = 'block';
    tbody.innerHTML = '';

    try {
        const pedidos = await apiFetch(API_CONFIG.ENDPOINTS.pedidos);
        renderPedidos(pedidos, tbody);
    } catch (error) {
        console.error('Error al cargar pedidos:', error);
        alertError.textContent = `No se pudieron cargar los pedidos: ${error.message}`;
        alertError.style.display = 'block';
    } finally {
        loading.style.display = 'none';
    }
}

function renderPedidos(pedidos, tbody) {
    if (!pedidos || pedidos.length === 0) {
        tbody.innerHTML = `
            <tr>
                <td colspan="5" class="tm-pedidos-empty">
                    No hay pedidos registrados por el momento.
                </td>
            </tr>`;
        return;
    }

    tbody.innerHTML = pedidos.map(p => {
        const estadoClase = obtenerClaseEstado(p.estado);
        return `
            <tr>
                <td class="tm-pedido-id">#${p.pedidoID}</td>
                <td>${p.clienteID ?? '-'}</td>
                <td>${formatearFechaHora(p.fecha)}</td>
                <td class="tm-pedido-total">$${Number(p.total).toLocaleString('es-MX', {
                    minimumFractionDigits: 2,
                    maximumFractionDigits: 2
                })}</td>
                <td>
                    <span class="tm-pedido-estado ${estadoClase}">
                        ${p.estado ?? 'Sin estado'}
                    </span>
                </td>
            </tr>
        `;
    }).join('');
}

function obtenerClaseEstado(estado) {
    if (!estado) return 'estado-default';
    const e = estado.toLowerCase();
    if (e.includes('pendiente'))  return 'estado-pendiente';
    if (e.includes('proceso') || e.includes('prepar')) return 'estado-proceso';
    if (e.includes('complet') || e.includes('entreg') || e.includes('listo')) return 'estado-completado';
    if (e.includes('cancel'))     return 'estado-cancelado';
    return 'estado-default';
}

function formatearFechaHora(fechaISO) {
    if (!fechaISO) return '-';
    const fecha = new Date(fechaISO);
    return fecha.toLocaleString('es-MX', {
        day: '2-digit',
        month: '2-digit',
        year: 'numeric',
        hour: '2-digit',
        minute: '2-digit'
    });
}

document.addEventListener('DOMContentLoaded', () => {
    if (document.getElementById('pedidos-tbody')) {
        cargarPedidos();
    }
});
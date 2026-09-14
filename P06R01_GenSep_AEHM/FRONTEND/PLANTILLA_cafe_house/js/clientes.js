// js/clientes.js

async function cargarClientes() {
    const tbody = document.getElementById('tabla-clientes-body');
    const alertError = document.getElementById('alert-error');
    const loading = document.getElementById('loading');

    if (!tbody) return;

    // Reset visual
    alertError.style.display = 'none';
    loading.style.display = 'block';
    tbody.innerHTML = '';

    try {
        const clientes = await apiFetch(API_CONFIG.ENDPOINTS.clientesPedidos);
        renderClientes(clientes, tbody);
    } catch (error) {
        console.error('Error al cargar clientes:', error);
        alertError.textContent = `No se pudieron cargar los clientes: ${error.message}`;
        alertError.style.display = 'block';
    } finally {
        loading.style.display = 'none';
    }
}

function renderClientes(clientes, tbody) {
    if (!clientes || clientes.length === 0) {
        tbody.innerHTML = `
            <tr>
                <td colspan="5" class="tm-pedidos-empty">
                    No hay clientes registrados por el momento.
                </td>
            </tr>`;
        return;
    }

    tbody.innerHTML = clientes.map(c => {
        // Detectar el ID del cliente (por si viene con camelCase o PascalCase)
        const id = c.clienteID ?? c.ClienteID ?? '-';

        // Detectar el nombre (algunos endpoints devuelven "nombre", otros "cliente")
        const nombre = c.nombre ?? c.Nombre ?? c.cliente ?? c.Cliente ?? '';

        // Detectar el email y teléfono
        const email = c.email ?? c.Email ?? '';
        const telefono = c.telefono ?? c.Telefono ?? '';

        // Detectar el conteo de pedidos con varias estrategias posibles
        const cantidadPedidos = obtenerConteoPedidos(c);

        return `
            <tr>
                <td class="tm-pedido-id">#${id}</td>
                <td>${nombre}</td>
                <td>${email}</td>
                <td>${telefono}</td>
                <td>
                    ${cantidadPedidos > 0
                        ? `<span class="tm-pedido-estado estado-completado">${cantidadPedidos}</span>`
                        : `<span class="tm-pedido-estado estado-default">0</span>`}
                </td>
            </tr>
        `;
    }).join('');
}

/**
 * Intenta obtener la cantidad de pedidos del cliente
 * probando varias propiedades comunes que puede devolver el endpoint
 */
function obtenerConteoPedidos(cliente) {
    // 1. Si viene un conteo explícito
    if (typeof cliente.cantidadPedidos === 'number') return cliente.cantidadPedidos;
    if (typeof cliente.CantidadPedidos === 'number') return cliente.CantidadPedidos;
    if (typeof cliente.pedidosCount === 'number') return cliente.pedidosCount;
    if (typeof cliente.PedidosCount === 'number') return cliente.PedidosCount;
    if (typeof cliente.totalPedidos === 'number') return cliente.totalPedidos;
    if (typeof cliente.TotalPedidos === 'number') return cliente.TotalPedidos;

    // 2. Si viene un array de pedidos
    if (Array.isArray(cliente.pedidos)) return cliente.pedidos.length;
    if (Array.isArray(cliente.Pedidos)) return cliente.Pedidos.length;

    // 3. Si no, devolver 0
    return 0;
}

document.addEventListener('DOMContentLoaded', () => {
    if (document.getElementById('tabla-clientes-body')) {
        cargarClientes();
    }

    // Botón Refrescar
    const btnRefrescar = document.getElementById('btn-refrescar');
    if (btnRefrescar) {
        btnRefrescar.addEventListener('click', cargarClientes);
    }
});
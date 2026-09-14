// const API_CONFIG = {
//     BASE_URL: 'http://localhost:5200/api',   // URL de tu API en Visual Studio
//     ENDPOINTS: {
//         productos: '/Productos',
//         clientes: '/Clientes',
//         // ... otros endpoints
//     }
// };

// // Helper para construir URLs
// function apiUrl(endpoint) {
//     return `${API_CONFIG.BASE_URL}${endpoint}`;
// }

// js/config.js
const API_CONFIG = {
    BASE_URL: 'http://localhost:5200/api',  
    ENDPOINTS: {
        productos: '/Productos',
        pedidos:   '/Pedidos',
        clientes: '/Clientes',
        detallesPedidos: '/DetallesPedidos',
        clientesPedidos: '/Clientes/ClientesPedidos'
    }
};

function apiUrl(endpoint) {
    return `${API_CONFIG.BASE_URL}${endpoint}`;
}

// Helper centralizado para todas las peticiones
async function apiFetch(endpoint, options = {}) {
    const response = await fetch(apiUrl(endpoint), {
        headers: {
            'Content-Type': 'application/json',
            ...(options.headers || {})
        },
        ...options
    });

    if (!response.ok) {
        const errorText = await response.text();
        throw new Error(`API ${response.status}: ${errorText}`);
    }

    if (response.status === 204) return null; // típico en DELETE

    return response.json();
}
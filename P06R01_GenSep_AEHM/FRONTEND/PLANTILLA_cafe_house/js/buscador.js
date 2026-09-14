// js/buscador.js
$(document).ready(function () {
    // Crea el input automáticamente arriba de cada tabla con .tm-pedidos-table
    $('.tm-pedidos-table').each(function () {
        const $tabla = $(this);
        const $wrapper = $tabla.closest('.tm-pedidos-table-wrapper');

        if ($wrapper.find('.tm-buscador').length === 0) {
            $wrapper.prepend(`
                <div class="tm-buscador" style="margin-bottom:15px; text-align:right;">
                    <input type="text" class="form-control tm-buscador-input"
                           placeholder="🔍 Buscar..." style="max-width:280px; display:inline-block;">
                </div>
            `);
        }

        $wrapper.on('input', '.tm-buscador-input', function () {
            const termino = $(this).val().toLowerCase().trim();
            $tabla.find('tbody tr').each(function () {
                const textoFila = $(this).text().toLowerCase();
                $(this).toggle(textoFila.includes(termino));
            });
        });
    });
});
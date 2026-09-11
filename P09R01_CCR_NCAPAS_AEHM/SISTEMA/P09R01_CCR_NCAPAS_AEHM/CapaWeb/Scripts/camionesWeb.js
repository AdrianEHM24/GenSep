document.addEventListener("DOMContentLoaded", function () {
    // Obtenemos la ruta actual
    var currentPath = window.location.pathname;

    // Seleccionamos todos los enlaces dentro de .sidebar-nav
    var navLinks = document.querySelectorAll('.sidebar-nav .nav-link');

    navLinks.forEach(function (link) {
        // Obtenemos el atributo href del enlace
        var href = link.getAttribute('href');

        // Limpiamos el href para comparar (quitamos el '~')
        // Esto asume que tus href son "~/Rutas" y la URL es "/Rutas"
        var cleanHref = href.replace('~', '');

        // Si la ruta actual coincide con el href, agregamos la clase
        if (currentPath === cleanHref || (currentPath === '/' && cleanHref === '/')) {
            link.classList.add('nav-link-active');
        }
    });
});


/**
 * * @param {boolean} visible Controla la visibilidad del modal
 */
function mostrarModalFormulario(visible) {
    const element = document.getElementById('modalFormulario');
    let instance = bootstrap.Modal.getInstance(element);
    if (!instance) {
        instance = new bootstrap.Modal(element);
    }
    if (visible) {
        instance.show();
    }
    else {
        instance.hide();
        // Limpieza forzada para eliminar rastros que el UpdatePanel deja huérfanos
        document.body.classList.remove('modal-open');
        document.body.style.overflow = '';
        document.body.style.paddingRight = '';

        // Buscar y destruir todos los fondos oscuros sobrantes en el body
        var backdrops = document.querySelectorAll('.modal-backdrop');
        backdrops.forEach(function (backdrop) {
            backdrop.remove();
        });
    }
}


/**
 * * @param {boolean} visible Controla la visibilidad del modal
 */
function mostrarModalEliminar(visible) {
    debugger
    const element = document.getElementById('modalEliminar');
    let instance = bootstrap.Modal.getInstance(element);
    if (!instance) {
        instance = new bootstrap.Modal(element);
    }
    console.log(instance);
    if (visible) {
        instance.show();
    }
    else {
        instance.hide();
        // Limpieza forzada para eliminar rastros que el UpdatePanel deja huérfanos
        document.body.classList.remove('modal-open');
        document.body.style.overflow = '';
        document.body.style.paddingRight = '';

        // Buscar y destruir todos los fondos oscuros sobrantes en el body
        var backdrops = document.querySelectorAll('.modal-backdrop');
        backdrops.forEach(function (backdrop) {
            backdrop.remove();
        });
    }
}
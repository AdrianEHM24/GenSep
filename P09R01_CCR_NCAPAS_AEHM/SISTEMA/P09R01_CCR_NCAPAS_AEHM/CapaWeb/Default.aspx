<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CapaWeb._Default" %>

<%--<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">ASP.NET</h1>
            <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
            <p><a href="http://www.asp.net" class="btn btn-primary btn-md">Learn more &raquo;</a></p>
        </section>

        <div class="row">
            <section class="col-md-4" aria-labelledby="gettingStartedTitle">
                <h2 id="gettingStartedTitle">Getting started</h2>
                <p>
                    ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
                A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
                </p>
                <p>
                    <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="librariesTitle">
                <h2 id="librariesTitle">Get more libraries</h2>
                <p>
                    NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
                </p>
                <p>
                    <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="hostingTitle">
                <h2 id="hostingTitle">Web Hosting</h2>
                <p>
                    You can easily find a web hosting company that offers the right mix of features and price for your applications.
                </p>
                <p>
                    <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
                </p>
            </section>
        </div>
    </main>

</asp:Content>--%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Estilos SOLO para los elementos de esta página (Tarjetas y Hero) -->
    <style>
        .hover-card {
            background-color: #152238; 
            border: 1px solid #1f3050;
            transition: transform 0.3s ease, box-shadow 0.3s ease, border-color 0.3s ease;
            border-radius: 12px;
        }
        
        .hover-card:hover {
            transform: translateY(-8px);
            box-shadow: 0 12px 24px rgba(0,0,0,0.4) !important;
            border-color: #3b82f6; 
        }
        
        .hero-section {
            background: linear-gradient(135deg, #1e3a8a 0%, #112240 100%);
            border: 1px solid #233863;
            border-radius: 16px;
        }

        .text-light-gray {
            color: #a8b2d1;
        }
    </style>

    <!-- Ya no usamos div.dark-dashboard porque la MasterPage ya es oscura -->
    <main class="container">
        
        <!-- Sección Principal (Hero) -->
        <section class="hero-section text-white p-5 mb-5 shadow-lg text-center" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle" class="display-4 fw-bold">Sistema de Gestión Logística</h1>
            <p class="lead mt-3 text-light-gray">
                Bienvenido al panel de control central. Selecciona el módulo al que deseas acceder para administrar los recursos de tu flotilla.
            </p>
        </section>

        <!-- Sección de Módulos (Tarjetas) -->
        <div class="row g-4">
            
            <!-- Tarjeta Camiones -->
            <section class="col-md-4" aria-labelledby="camionesTitle">
                <div class="card h-100 shadow text-center hover-card p-3">
                    <div class="card-body">
                        <h2 id="camionesTitle" class="display-6 mb-3">🚚</h2>
                        <h3 class="fw-bold text-white">Camiones</h3>
                        <p class="card-text text-light-gray">
                            Gestiona el inventario de la flotilla, registra nuevas unidades, revisa el estado mecánico y el mantenimiento.
                        </p>
                    </div>
                    <div class="card-footer bg-transparent border-0 pb-4">
                        <a class="btn btn-outline-info btn-lg w-100 rounded-pill" href="Camiones.aspx">Ver Camiones &raquo;</a>
                    </div>
                </div>
            </section>

            <!-- Tarjeta Choferes -->
            <section class="col-md-4" aria-labelledby="choferesTitle">
                <div class="card h-100 shadow text-center hover-card p-3">
                    <div class="card-body">
                        <h2 id="choferesTitle" class="display-6 mb-3">🧑‍✈️</h2>
                        <h3 class="fw-bold text-white">Choferes</h3>
                        <p class="card-text text-light-gray">
                            Administra la información de tu personal, vigencia de licencias, turnos de trabajo y desempeño operativo.
                        </p>
                    </div>
                    <div class="card-footer bg-transparent border-0 pb-4">
                        <a class="btn btn-outline-success btn-lg w-100 rounded-pill" href="Choferes.aspx">Ver Choferes &raquo;</a>
                    </div>
                </div>
            </section>

            <!-- Tarjeta Rutas -->
            <section class="col-md-4" aria-labelledby="rutasTitle">
                <div class="card h-100 shadow text-center hover-card p-3">
                    <div class="card-body">
                        <h2 id="rutasTitle" class="display-6 mb-3">🗺️</h2>
                        <h3 class="fw-bold text-white">Rutas</h3>
                        <p class="card-text text-light-gray">
                            Planifica trayectos, optimiza tiempos de entrega, asigna destinos y monitorea los recorridos activos.
                        </p>
                    </div>
                    <div class="card-footer bg-transparent border-0 pb-4">
                        <a class="btn btn-outline-warning btn-lg w-100 rounded-pill" href="Rutas.aspx">Ver Rutas &raquo;</a>
                    </div>
                </div>
            </section>

        </div>
    </main>
    
</asp:Content>
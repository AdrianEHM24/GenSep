<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="CapaWeb.About" %>

<%--<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <h3>Your application description page.</h3>
        <p>Use this area to provide additional information.</p>
    </main>
</asp:Content>--%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Estilos específicos para la página Sobre Nosotros -->
    <style>
        /* Reutilizamos el estilo de tarjeta oscura */
        .dark-card {
            background-color: #152238; 
            border: 1px solid #1f3050;
            border-radius: 12px;
            transition: transform 0.3s ease, box-shadow 0.3s ease;
        }
        
        /* Pequeño efecto hover para darle dinamismo */
        .dark-card:hover {
            transform: translateY(-5px);
            box-shadow: 0 10px 20px rgba(0,0,0,0.3) !important;
        }

        /* Color de texto para los párrafos */
        .text-light-gray {
            color: #a8b2d1;
        }

        /* Resaltado para las letras en negrita */
        .text-highlight {
            color: #ffffff;
            font-weight: 600;
        }
    </style>

    <!-- Usamos container-fluid para mantener la alineación con tu inicio -->
    <main aria-labelledby="title" class="container">
        
        <!-- Título principal en blanco -->
        <h2 id="title" class="fw-bold text-center mb-5 text-white" style="font-size:2.5rem;">
            Sobre Nosotros
        </h2>

        <!-- Sección de Descripción -->
        <div class="dark-card p-4 shadow mb-5">
            <h3 class="text-info fw-bold mb-3" style="font-size:1.75rem;">Descripción</h3>
            <p class="text-light-gray mb-0" style="font-size:1.2rem; line-height:1.8;">
                Nuestro sistema de gestión de <span class="text-highlight">Choferes, Camiones y Rutas</span> 
                está diseñado para optimizar la administración del transporte, 
                facilitando el control de unidades, la asignación de choferes y 
                la planificación de rutas de manera eficiente y segura.
            </p>
        </div>

        <!-- Fila de Visión y Misión -->
        <div class="row g-4">
            
            <!-- Tarjeta Visión -->
            <div class="col-md-6">
                <div class="dark-card p-4 shadow h-100">
                    <h3 class="text-success fw-bold mb-3" style="font-size:1.75rem;">Visión</h3>
                    <p class="text-light-gray mb-0" style="font-size:1.2rem; line-height:1.8;">
                        Ser la plataforma líder en soluciones de transporte, 
                        brindando herramientas innovadoras que permitan a las 
                        empresas mejorar su logística y garantizar un servicio 
                        confiable y de calidad.
                    </p>
                </div>
            </div>
            
            <!-- Tarjeta Misión -->
            <div class="col-md-6">
                <div class="dark-card p-4 shadow h-100">
                    <h3 class="text-warning fw-bold mb-3" style="font-size:1.75rem;">Misión</h3>
                    <p class="text-light-gray mb-0" style="font-size:1.2rem; line-height:1.8;">
                        Proporcionar un sistema integral que simplifique la 
                        administración de choferes, camiones y rutas, 
                        fomentando la eficiencia operativa, la seguridad en el 
                        transporte y la satisfacción de nuestros clientes.
                    </p>
                </div>
            </div>

        </div>
    </main>
    
</asp:Content>
<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="CapaWeb.Contact" %>

<%--<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <h3>Your contact page.</h3>
        <address>
            One Microsoft Way<br />
            Redmond, WA 98052-6399<br />
            <abbr title="Phone">P:</abbr>
            425.555.0100
        </address>

        <address>
            <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
            <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
        </address>
    </main>
</asp:Content>--%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Estilos específicos para la página de Contacto -->
    <style>
        .dark-card {
            background-color: #152238; 
            border: 1px solid #1f3050;
            border-radius: 12px;
            transition: transform 0.3s ease, box-shadow 0.3s ease;
        }
        
        .dark-card:hover {
            transform: translateY(-5px);
            box-shadow: 0 10px 20px rgba(0,0,0,0.3) !important;
        }

        .text-light-gray {
            color: #a8b2d1;
        }

        /* Efecto sutil al pasar el cursor sobre los enlaces */
        .contact-link {
            transition: opacity 0.3s ease;
        }
        .contact-link:hover {
            opacity: 0.7;
        }
    </style>

    <!-- Usamos 'container' estándar para evitar que se desborde debajo del navbar -->
    <main aria-labelledby="title" class="container py-4">
        
        <h2 id="title" class="fw-bold mb-2 text-white" style="font-size:2.5rem;"><%: Title %>.</h2>
        <h3 class="mb-4 text-info" style="font-size:1.4rem;">Página de contacto</h3>

        <!-- Envolvemos la dirección en una tarjeta para que se vea elegante -->
        <div class="dark-card p-4 shadow mb-5" style="max-width: 600px;">
            <address class="mb-0" style="font-size:1.2rem; line-height:2.2;">
                
                <span class="text-light-gray"><strong>Correo personal:</strong></span> <br/>
                <a href="mailto:adrianeleuterio247518@gmail.com" 
                   class="text-decoration-none contact-link text-info fw-semibold mb-3 d-inline-block">
                    <i class="bi bi-envelope-fill me-2"></i> adrianeleuterio247518@gmail.com
                </a><br />

                <span class="text-light-gray"><strong>WhatsApp:</strong></span> <br/>
                <a href="https://wa.me/5210000000000" target="_blank" 
                   class="text-decoration-none contact-link fw-semibold mb-3 d-inline-block" style="color:#25D366;">
                    <i class="bi bi-whatsapp me-2"></i> Enviar mensaje por WhatsApp
                </a><br />

                <span class="text-light-gray"><strong>Facebook:</strong></span> <br/>
                <!-- Usamos un azul ligeramente más claro para contrastar mejor en fondo oscuro -->
                <a href="https://www.facebook.com/" target="_blank" 
                   class="text-decoration-none contact-link fw-semibold mb-3 d-inline-block" style="color:#4dabf7;">
                    <i class="bi bi-facebook me-2"></i> Perfil en Facebook
                </a><br />

                <span class="text-light-gray"><strong>YouTube:</strong></span> <br/>
                <!-- Usamos un rojo un poco más brillante por el contraste -->
                <a href="https://www.youtube.com/" target="_blank" 
                   class="text-decoration-none contact-link fw-semibold d-inline-block" style="color:#ff4d4d;">
                    <i class="bi bi-youtube me-2"></i> Canal en YouTube
                </a>
                
            </address>
        </div>

    </main>
    
</asp:Content>


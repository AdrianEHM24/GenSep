<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rutas.aspx.cs" Inherits="CapaWeb.Rutas" MasterPageFile="~/Site.Master"%>

<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>--%>
<asp:Content ID="ContentStyles" ContentPlaceHolderID="PageStyles" runat="server">
    <style>
        .row-card-image {
            object-fit: contain;
        }

        /* Asegura que el componente de Google flote sobre el resto */
        #autocomplete-container {
            position: relative;
            z-index: 1050;
        }

        /* Ajusta el diseño del componente */
        gmp-place-autocomplete {
            width: 100%;
            position: absolute;
            top: 0;
            left: 0;
        }
    </style>
</asp:Content>

<asp:Content ID="ContentScripts" ContentPlaceHolderID="PageScripts" runat="server">
    <script>
function validarFechasHorasCliente(source, args) {
    // Obtenemos el ID dinámico del campo de salida
    const idSalida = '<%=txtFechaSalida.ClientID%>';
            const txtSalida = document.getElementById(idSalida);

            // Si alguno de los dos campos está vacío, dejamos que actúen los RequiredFieldValidator
            if (!txtSalida.value || !args.Value) {
                args.IsValid = true;
                return;
            }

            // Convertimos ambos strings de fecha y hora a objetos Date
            const fechaSalida = new Date(txtSalida.value);
            const fechaLlegada = new Date(args.Value);

            // Validamos que Llegada sea ESTRICTAMENTE MAYOR que Salida
            if (fechaLlegada > fechaSalida) {
                args.IsValid = true;
            } else {
                args.IsValid = false;
            }
        }
    </script>
</asp:Content>

<asp:Content ID="ContentRutas" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        /* Adaptación de la sección de Rutas a Modo Oscuro */
.menu-page-container {
    background-color: #0b1426 !important;
    color: #ffffff !important;
}

.menu-main-title {
    color: #ffffff !important;
}

/* Tarjetas de rutas en modo oscuro */
.row-card {
    background-color: #152238 !important;
    border: 1px solid #1f3050 !important;
    box-shadow: 0 10px 30px rgba(0, 0, 0, 0.3) !important;
}

.row-card:hover {
    box-shadow: 0 20px 40px rgba(0, 0, 0, 0.5) !important;
    border-color: #3b82f6 !important;
}

.row-card-title {
    color: #ffffff !important;
}

.row-card-description, .row-card-subtext {
    color: #a8b2d1 !important;
}

/* Modales y formularios emergentes en modo oscuro */
.modal-content {
    background-color: #152238 !important;
    color: #ffffff !important;
    border: 1px solid #1f3050 !important;
}

.modal-header, .modal-footer {
    border-color: #1f3050 !important;
}

.form-control, .form-select {
    background-color: #0b1426 !important;
    border: 1px solid #1f3050 !important;
    color: #ffffff !important;
}

.form-control:focus, .form-select:focus {
    background-color: #0b1426 !important;
    color: #ffffff !important;
    border-color: #3b82f6 !important;
}
    </style>
    <asp:UpdatePanel ID="upRutas" runat="server">
        <ContentTemplate>
            <div class="menu-page-container">
                <div class="container">
                    
                    <!-- Título de la Sección -->
                    <div id="view-title" class="sticky-top d-flex align-items-center border-bottom border-danger border-3 pb-3 mb-4" style="background-color: #0b1426; z-index: 1020;">
                        <div class="bg-danger text-white rounded-3 d-flex align-items-center justify-content-center shadow-sm" style="width: 50px; height: 50px;">
                            <i class="bi bi-signpost-2 fs-3"></i>
                        </div>
                        <h2 class="display-6 fw-bold text-white ms-3 mb-0">Rutas</h2>
                    </div>

                    <!-- MODAL DE FORMULARIO -->
                    <div class="modal fade" id="modalFormulario" tabindex="-1" aria-labelledby="modalFormularioLabel" aria-hidden="true">
                        <div class="modal-dialog modal-dialog-centered modal-lg">
                            <div class="modal-content border-0 shadow">

                                <div class="modal-header border-bottom-0 pt-4 px-4">
                                    <h5 class="modal-title fw-bold" id="modalFormularioLabel">Datos de la ruta</h5>
                                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>

                                <div class="modal-body px-4 pb-4">
                                    <p class="small mb-4" style="color: #a8b2d1;">Complete los campos obligatorios para dar de alta la ruta en el sistema.</p>

                                    <div>
                                        <asp:HiddenField ID="hfIdRuta" runat="server" Value='<%# Eval("IdRuta") %>' />
                                    </div>

                                    <div class="mb-3">
                                        <label for="<%=ddlIdChofer.ClientID%>" class="form-label small fw-bold">Chofer</label>
                                        <asp:DropDownList ID="ddlIdChofer" runat="server" AutoPostBack="false" CssClass="form-select rounded-3 w-100 mw-100">
                                        </asp:DropDownList>
                                    </div>

                                    <div class="mb-3">
                                        <label for="<%=ddlIdCamion.ClientID%>" class="form-label small fw-bold">Camión</label>
                                        <asp:DropDownList ID="ddlIdCamion" runat="server" AutoPostBack="false" CssClass="form-select rounded-3 w-100 mw-100">
                                        </asp:DropDownList>
                                    </div>

                                    <div class="row g-3 mb-3">
                                        <div class="col-6">
                                            <label for="<%=txtOrigen.ClientID%>" class="form-label small fw-bold">Origen</label>
                                            <asp:TextBox ID="txtOrigen" runat="server" CssClass="form-control rounded-3 w-100 mw-100" placeholder="Ej. Monterrey"></asp:TextBox>
                                            <asp:RequiredFieldValidator
                                                ID="rfvOrigen" runat="server" ControlToValidate="txtOrigen"
                                                ErrorMessage="Este campo es obligatorio" ForeColor="#ff4d4d" Display="Dynamic" />
                                        </div>

                                        <div class="col-6">
                                            <label for="<%=txtDestino.ClientID%>" class="form-label small fw-bold">Destino</label>
                                            <asp:TextBox ID="txtDestino" runat="server" CssClass="form-control rounded-3 w-100 mw-100" placeholder="Ej. Veracruz"></asp:TextBox>
                                            <asp:RequiredFieldValidator
                                                ID="rfvDestino" runat="server" ControlToValidate="txtDestino"
                                                ErrorMessage="Este campo es obligatorio" ForeColor="#ff4d4d" Display="Dynamic" />
                                        </div>
                                    </div>

                                    <div class="row g-3 mb-3">
                                        <div class="col-6">
                                            <label for="<%=txtFechaSalida.ClientID%>" class="form-label small fw-bold">Fecha de Salida</label>
                                            <asp:TextBox ID="txtFechaSalida" runat="server" CssClass="form-control rounded-3 w-100 mw-100" TextMode="DateTimeLocal"></asp:TextBox>
                                            <asp:RequiredFieldValidator
                                                ID="rfvFechaSalida" runat="server" ControlToValidate="txtFechaSalida"
                                                ErrorMessage="Este campo es obligatorio" ForeColor="#ff4d4d" Display="Dynamic" />
                                        </div>
                                        <div class="col-6">
                                            <label for="<%=txtFechaLlegada.ClientID%>" class="form-label small fw-bold">Fecha de Llegada</label>
                                            <asp:TextBox ID="txtFechaLlegada" runat="server" CssClass="form-control rounded-3 w-100 mw-100" TextMode="DateTimeLocal"></asp:TextBox>
                                            <asp:RequiredFieldValidator
                                                ID="rfvFechaLlegada" runat="server" ControlToValidate="txtFechaLlegada"
                                                ErrorMessage="Este campo es obligatorio" ForeColor="#ff4d4d" Display="Dynamic" />
                                            <asp:CustomValidator
                                                ID="cvCompararFechas" runat="server" ControlToValidate="txtFechaLlegada"
                                                ClientValidationFunction="validarFechasHorasCliente" OnServerValidate="cvCompararFechas_ServerValidate"
                                                ErrorMessage="La fecha de llegada debe ser posterior a la de salida"
                                                ForeColor="#ff4d4d" Display="Dynamic" />
                                        </div>
                                    </div>

                                    <div class="mb-3">
                                        <label for="<%=txtDistancia.ClientID%>" class="form-label small fw-bold">Distancia (km)</label>
                                        <asp:TextBox ID="txtDistancia" runat="server" CssClass="form-control rounded-3 w-100 mw-100" placeholder="Ej. 280"></asp:TextBox>
                                        <asp:RequiredFieldValidator
                                            ID="rfvDistancia" runat="server" ControlToValidate="txtDistancia"
                                            ErrorMessage="Este campo es obligatorio" ForeColor="#ff4d4d" Display="Dynamic" />
                                    </div>

                                    <div class="form-check form-switch mb-2">
                                        <label for="<%=chkATiempo.ClientID%>" class="form-check-label small fw-semibold text-white">A tiempo</label>
                                        <asp:CheckBox ID="chkATiempo" runat="server" Checked="true" />
                                    </div>
                                </div>

                                <div class="modal-footer border-top-0 d-flex gap-2 justify-content-end px-4 pb-4 pt-0">
                                    <button type="button" class="btn btn-outline-secondary rounded-pill px-4" data-bs-dismiss="modal">Cancelar</button>
                                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar Ruta" OnClick="btnGuardar_Click" CssClass="btn btn-primary rounded-pill px-4" />
                                </div>

                            </div>
                        </div>
                    </div>

                    <!-- MODAL ELIMINAR -->
                    <div class="modal fade" id="modalEliminar" tabindex="-1" aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content rounded-4">
                                <div class="modal-header border-bottom-0">
                                    <h5 class="modal-title">Confirmar eliminación</h5>
                                    <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                                </div>
                                <div class="modal-body" style="color: #a8b2d1;">
                                    ¿Estás seguro de que deseas eliminar este elemento? Esta acción no se puede deshacer.
                                </div>
                                <div class="modal-footer border-top-0">
                                    <button type="button" class="btn btn-outline-secondary rounded-pill px-4" data-bs-dismiss="modal">Cancelar</button>
                                    <asp:Button ID="btnConfirmarEliminar" runat="server" Text="Eliminar"
                                        CssClass="btn btn-danger rounded-pill px-4" OnClick="btnConfirmarEliminar_Click" 
                                        CausesValidation="false"/>
                                </div>
                            </div>
                        </div>
                    </div>

                    <!-- FILTROS -->
                    <div class="filtros">
                        <label>Filtrar por:</label>
                        <asp:DropDownList ID="ddlFiltro" runat="server" AutoPostBack="false" CssClass="form-select w-auto d-inline-block">
                            <asp:ListItem Value="0" Selected="True">Todos</asp:ListItem>
                            <asp:ListItem Value="1">A tiempo</asp:ListItem>
                            <asp:ListItem Value="2">No a tiempo</asp:ListItem>
                        </asp:DropDownList>
                        <asp:LinkButton ID="btnFiltrar" runat="server"
                            CssClass="btn btn-danger rounded-pill shadow-lg" OnClick="btnFiltrar_Click" CausesValidation="false">
                            <i class="bi bi-search"></i> Filtrar
                        </asp:LinkButton>
                        <asp:LinkButton ID="btnActualizar" runat="server"
                            CssClass="btn btn-warning rounded-pill shadow-lg text-dark" OnClick="btnActualizar_Click" CausesValidation="false">
                            <i class="bi bi-arrow-clockwise"></i> Actualizar
                        </asp:LinkButton>
                        <asp:LinkButton ID="btnAgregar" runat="server"
                            CssClass="btn btn-success rounded-pill shadow-lg"
                            OnClick="btnAgregar_Click" CausesValidation="false">
                            <i class="bi bi-plus-lg"></i> Agregar
                        </asp:LinkButton>
                    </div>

                    <asp:Panel ID="pnlMensaje" runat="server" Visible="false" CssClass="alert">
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                        <asp:LinkButton ID="btnCerrar" runat="server" OnClick="btnCerrar_Click" CssClass="btn-close"></asp:LinkButton>
                    </asp:Panel>

                    <!-- GRIDVIEW DE RUTAS -->
                    <div class="gridview-container-menu">
                        <asp:GridView ID="gvChoferes" runat="server"
                            AutoGenerateColumns="False"
                            EmptyDataText="No se encontraron rutas registradas"
                            GridLines="None"
                            ShowHeader="false">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <div class="row-card-image-wrapper d-flex justify-content-between align-items-center w-100 p-3">
    <!-- Icono de maps más grande -->
    <img
        src="map.img"
        onerror="this.onerror=null; this.src='https://images.seeklogo.com/logo-png/26/1/new-google-maps-icon-logo-png_seeklogo-268336.png';"
        class="row-card-image"
        alt="Ruta" style="width: 150px; height: 150px; object-fit: contain;" />
    
    <!-- Botón con estilo oscuro/celeste de alta visibilidad -->
    <asp:HyperLink ID="lnkMapa" runat="server"
        NavigateUrl='<%# String.Format("https://www.google.com/maps/dir/?api=1&origin={0}&destination={1}", HttpUtility.UrlEncode(Eval("Origen").ToString()), HttpUtility.UrlEncode(Eval("Destino").ToString())) %>'
        Target="_blank"
        CssClass="btn btn-info text-dark fw-bold btn-sm rounded-pill px-3 py-2 shadow-sm">
        <i class="bi bi-map-fill me-1"></i> Ver ruta en Google Maps 
    </asp:HyperLink>

    <span class='badge-floating <%# (bool)Eval("ATiempo") ? "badge-status-disponible" : "badge-status-no-disponible" %>'>
        <%# (bool)Eval("ATiempo") ? "★ A tiempo" : "✕ No a tiempo" %>
    </span>
</div>
                                            <div class="row-card-body">
                                                <div class="row-card-category"><%# Eval("FechaSalida", "{0:dd/MM/yyyy hh:mm tt}") %> - <%# Eval("FechaLlegada", "{0:dd/MM/yyyy hh:mm tt}") %></div>
                                                <h3 class="row-card-title"><%# Eval("Origen") %> ➔ <%# Eval("Destino") %></h3>

                                                <div class="row-card-footer">
                                                    <div class="row-card-price-area">
                                                        <div class="row-card-price">
                                                            <%# Eval("Distancia") %> <span>km</span>
                                                        </div>
                                                    </div>
                                                    <div class="button-group d-flex gap-2">
                                                        <asp:LinkButton
                                                            ID="btnEditar"
                                                            runat="server"
                                                            CssClass="btn btn-outline-primary btn-sm rounded-circle d-flex align-items-center justify-content-center" style="width: 40px; height: 40px;"
                                                            OnClick="btnEditar_Click"
                                                            CausesValidation="false"
                                                            CommandArgument='<%# Eval("IdRuta") %>'>
                                                            <i class="bi bi-pencil"></i>
                                                        </asp:LinkButton>
                                                        <asp:LinkButton
                                                            ID="btnEliminar"
                                                            runat="server"
                                                            CssClass="btn btn-outline-danger btn-sm rounded-circle d-flex align-items-center justify-content-center" style="width: 40px; height: 40px;"
                                                            OnClick="btnEliminar_Click"
                                                            CausesValidation="false"
                                                            CommandArgument='<%# Eval("IdRuta")%>'>
                                                            <i class="bi bi-trash"></i>
                                                        </asp:LinkButton>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>

                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
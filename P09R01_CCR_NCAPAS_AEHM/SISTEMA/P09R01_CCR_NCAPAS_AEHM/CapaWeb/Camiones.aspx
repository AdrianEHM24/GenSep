<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Camiones.aspx.cs" Inherits="CapaWeb.Camiones" MasterPageFile="~/Site.Master"%>

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
    <style></style>
</asp:Content>

<asp:Content ID="ContentScripts" ContentPlaceHolderID="PageScripts" runat="server">
    <script></script>
</asp:Content>
<asp:Content ID="ContentCamiones" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        /* Adaptación de la sección de Camiones a Modo Oscuro */
.menu-page-container {
    background-color: #0b1426 !important;
    color: #ffffff !important;
}

.menu-main-title {
    color: #ffffff !important;
}

/* Tarjetas de camiones en modo oscuro */
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
    <asp:UpdatePanel ID="upCamiones" runat="server">
        <ContentTemplate>
            <div class="menu-page-container">
                <div class="container">
                    
                    <!-- Título de la Sección -->
                    <div class="text-center mb-5">
                        <h2 class="menu-main-title">Módulo de <span>Camiones</span></h2>
                    </div>

                    <!-- MODAL DE FORMULARIO -->
                    <div class="modal fade" id="modalFormulario" tabindex="-1" aria-labelledby="modalFormularioLabel" aria-hidden="true">
                        <div class="modal-dialog modal-dialog-centered">
                            <div class="modal-content border-0 shadow">

                                <div class="modal-header border-bottom-0 pt-4 px-4">
                                    <h5 class="modal-title fw-bold text-dark" id="modalFormularioLabel">Datos de la Unidad</h5>
                                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>

                                <div class="modal-body px-4 pb-4">
                                    <p class="text-muted small mb-4">Complete los campos obligatorios para dar de alta el vehículo en el sistema.</p>

                                    <div>
                                        <asp:HiddenField ID="hfIdCamion" runat="server" Value='<%# Eval("IdCamion") %>' />
                                    </div>

                                    <div class="mb-3">
                                        <label for="<%=txtMatricula.ClientID%>" class="form-label small fw-bold text-secondary">Matrícula / Placas</label>
                                        <asp:TextBox ID="txtMatricula" runat="server" CssClass="form-control rounded-3 w-100 mw-100" placeholder="Ej. ABC-123-A"></asp:TextBox>
                                        <asp:RequiredFieldValidator
                                            ID="rfvMatricula" runat="server" ControlToValidate="txtMatricula"
                                            ErrorMessage="Este campo es obligatorio" ForeColor="Red" Display="Dynamic" />
                                    </div>

                                    <div class="mb-3">
                                        <label for="<%=ddlTipoCamion.ClientID%>" class="form-label small fw-bold text-secondary">Tipo de Unidad</label>
                                        <asp:DropDownList ID="ddlTipoCamion" runat="server" CssClass="form-select rounded-3 w-100 mw-100">
                                            <asp:ListItem Value="Caja Cerrada 48ft">Caja Cerrada 48ft</asp:ListItem>
                                            <asp:ListItem Value="Caja Cerrada 53ft">Caja Cerrada 53ft</asp:ListItem>
                                            <asp:ListItem Value="Plataforma">Plataforma</asp:ListItem>
                                            <asp:ListItem Value="Refrigerado">Refrigerado</asp:ListItem>
                                            <asp:ListItem Value="Torton">Torton</asp:ListItem>
                                            <asp:ListItem Value="Tractocamión">Tractocamión</asp:ListItem>
                                            <asp:ListItem Value="Tributo/Rabón">Tributo/Rabón</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator
                                            ID="rfvTipoCamion" runat="server" ControlToValidate="ddlTipoCamion"
                                            ErrorMessage="Este campo es obligatorio" ForeColor="Red" Display="Dynamic" />
                                    </div>

                                    <div class="row g-3 mb-3">
                                        <div class="col-6">
                                            <label for="<%=txtMarca.ClientID%>" class="form-label small fw-bold text-secondary">Marca</label>
                                            <asp:TextBox ID="txtMarca" runat="server" CssClass="form-control rounded-3" placeholder="Ej. Kenworth"></asp:TextBox>
                                            <asp:RequiredFieldValidator
                                                ID="rfvMarca" runat="server" ControlToValidate="txtMarca"
                                                ErrorMessage="Este campo es obligatorio" ForeColor="Red" Display="Dynamic" />
                                        </div>
                                        <div class="col-6">
                                            <label for="<%=txtModelo.ClientID%>" class="form-label small fw-bold text-secondary">Modelo (Año)</label>
                                            <asp:TextBox ID="txtModelo" runat="server" CssClass="form-control rounded-3" placeholder="Ej. 2024" TextMode="Number"></asp:TextBox>
                                            <asp:RequiredFieldValidator
                                                ID="rfvModelo" runat="server" ControlToValidate="txtModelo"
                                                ErrorMessage="Este campo es obligatorio" ForeColor="Red" Display="Dynamic" />
                                            <asp:RangeValidator
                                                ID="rvModelo" runat="server" ControlToValidate="txtModelo"
                                                MinimumValue="1900" Type="Integer" ForeColor="Red" Display="Dynamic" />
                                        </div>
                                    </div>

                                    <div class="row g-3 mb-4">
                                        <div class="col-6">
                                            <label for="<%=txtCapacidad.ClientID%>" class="form-label small fw-bold text-secondary">Capacidad (kg)</label>
                                            <asp:TextBox ID="txtCapacidad" runat="server" CssClass="form-control rounded-3" placeholder="Ej. 15000" TextMode="Number"></asp:TextBox>
                                            <asp:RequiredFieldValidator
                                                ID="rfvCapacidad" runat="server" ControlToValidate="txtCapacidad"
                                                ErrorMessage="Este campo es obligatorio" ForeColor="Red" Display="Dynamic" />
                                            <asp:CompareValidator
                                                ID="cvCapacidad" runat="server" ControlToValidate="txtCapacidad"
                                                ErrorMessage="Este campo es obligatorio" Operator="GreaterThan"
                                                ValueToCompare="0" Type="Integer" ForeColor="Red" Display="Dynamic" />
                                        </div>
                                        <div class="col-6">
                                            <label for="<%=txtKilometraje.ClientID%>" class="form-label small fw-bold text-secondary">Kilometraje Inicial</label>
                                            <asp:TextBox ID="txtKilometraje" runat="server" CssClass="form-control rounded-3" placeholder="Ej. 0.00" TextMode="Number"></asp:TextBox>
                                            <asp:RequiredFieldValidator
                                                ID="rfvKilometraje" runat="server" ControlToValidate="txtKilometraje"
                                                ErrorMessage="Este campo es obligatorio" ForeColor="Red" Display="Dynamic" />
                                            <asp:CompareValidator
                                                ID="cvKilometraje" runat="server" ControlToValidate="txtKilometraje"
                                                ErrorMessage="Este campo es obligatorio" Operator="GreaterThan"
                                                ValueToCompare="0" Type="Integer" ForeColor="Red" Display="Dynamic" />
                                        </div>
                                    </div>

                                    <div class="mb-3">
                                        <label for="<%=txtUrlFoto.ClientID%>" class="form-label small fw-bold text-secondary">Url de la foto</label>
                                        <asp:TextBox ID="txtUrlFoto" runat="server" CssClass="form-control rounded-3 w-100 mw-100" placeholder="http://example.com/fotos/camion.jpg"></asp:TextBox>
                                        <asp:RequiredFieldValidator
                                            ID="rfvUrlFoto" runat="server" ControlToValidate="txtUrlFoto"
                                            ErrorMessage="Este campo es obligatorio" ForeColor="Red" Display="Dynamic" />
                                    </div>

                                    <div class="form-check form-switch mb-2">
                                        <label for="<%=chkDisponible.ClientID%>" class="form-check-label small fw-semibold text-dark">Disponible para asignación inmediata</label>
                                        <asp:CheckBox ID="chkDisponible" runat="server" Checked="true" />
                                    </div>
                                </div>

                                <div class="modal-footer border-top-0 d-flex gap-2 justify-content-end px-4 pb-4 pt-0">
                                    <button type="button" class="btn btn-light rounded-pill px-4 text-secondary border" data-bs-dismiss="modal">Cancelar</button>
                                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar Unidad" OnClick="btnGuardar_Click" CssClass="btn btn-primary rounded-pill px-4" />
                                </div>

                            </div>
                        </div>
                    </div>

                    <!-- MODAL ELIMINAR -->
                    <div class="modal fade" id="modalEliminar" tabindex="-1" aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <h5 class="modal-title">Confirmar eliminación</h5>
                                    <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                                </div>
                                <div class="modal-body">
                                    ¿Estás seguro de que deseas eliminar este elemento? Esta acción no se puede deshacer.
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                                    <asp:Button ID="btnConfirmarEliminar" runat="server" Text="Eliminar"
                                        CssClass="btn btn-danger" OnClick="btnConfirmarEliminar_Click"
                                        CausesValidation="false"/>
                                </div>
                            </div>
                        </div>
                    </div>
                        
                    <!-- BARRA DE FILTROS -->
                    <div class="filtros">
                        <asp:DropDownList ID="ddlFiltro" runat="server" AutoPostBack="false">
                            <asp:ListItem Value="0" Selected="True">Todos</asp:ListItem>
                            <asp:ListItem Value="1">Disponibles</asp:ListItem>
                            <asp:ListItem Value="2">No Disponibles</asp:ListItem>
                        </asp:DropDownList>

                        <asp:LinkButton ID="btnFiltrar" runat="server"
                            CssClass="btn btn-danger rounded-pill shadow-sm px-4" OnClick="btnFiltrar_Click" CausesValidation="false">
                            <i class="bi bi-search"></i> Filtrar
                        </asp:LinkButton>

                        <asp:LinkButton ID="btnActualizar" runat="server"
                            CssClass="btn btn-warning rounded-pill shadow-sm px-4 text-dark" OnClick="btnActualizar_Click" CausesValidation="false">
                            <i class="bi bi-arrow-clockwise"></i> Actualizar
                        </asp:LinkButton>

                        <asp:LinkButton ID="btnAgregar" runat="server"
                            CssClass="btn btn-success rounded-pill shadow-sm px-4"
                            OnClick="btnAgregar_Click"
                            CausesValidation="false">
                            <i class="bi bi-plus-lg"></i> Agregar
                        </asp:LinkButton>
                    </div>

                    <!-- MENSAJES DE ALERTA -->
                    <asp:Panel ID="pnlMensaje" runat="server" Visible="false" CssClass="alert alert-info">
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                        <asp:LinkButton ID="btnCerrar" runat="server" OnClick="btnCerrar_Click" CssClass="btn-close float-end"></asp:LinkButton>
                    </asp:Panel>

                    <!-- GRIDVIEW ADAPTADO A TARJETAS CON EL CSS -->
                    <div class="gridview-container-menu">
                        <asp:GridView ID="gvCamiones" runat="server"
                            AutoGenerateColumns="False"
                            EmptyDataText="No se encontraron camiones registrados"
                            GridLines="None"
                            ShowHeader="false">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <div class="row-card">

                                            <div class="row-card-image-wrapper">
                                                <img
                                                    src="<%# Eval("UrlFoto") %>"
                                                    onerror="this.onerror=null; this.src='https://images.unsplash.com/photo-1601584115197-04ecc0da31d7?q=80&w=600&auto=format&fit=crop';"
                                                    class="row-card-image"
                                                    alt="Camión" />
                                                <span class='badge-floating <%# (bool)Eval("Disponibilidad") ? "badge-status-disponible" : "badge-status-no-disponible" %>'>
                                                    <%# (bool)Eval("Disponibilidad") ? "★ Disponible" : "✕ Ocupado" %>
                                                </span>
                                            </div>

                                            <div class="row-card-body">
                                                <div class="row-card-category"><%# Eval("TipoCamion") %></div>
                                                <h3 class="row-card-title"><%# Eval("Marca") %> <%# Eval("Modelo") %></h3>

                                                <div class="row-card-footer">
                                                    <div class="row-card-price-area">
                                                        <div class="row-card-price">
                                                            <%# String.Format("{0:N0}", Eval("Capacidad")) %> <span>kg</span>
                                                        </div>
                                                        <div class="row-card-subtext">
                                                            <span>⏱ <%# String.Format("{0:N2}", Eval("Kilometraje")) %> km</span>
                                                        </div>
                                                    </div>
                                                    <div class="button-group d-flex gap-2">
                                                        <asp:LinkButton
                                                            ID="btnEditar"
                                                            runat="server"
                                                            CssClass="btn btn-outline-primary btn-sm rounded-circle"
                                                            OnClick="btnEditar_Click"
                                                            CausesValidation="false"
                                                            CommandArgument='<%# Eval("IdCamion") %>'>
                                                            <i class="bi bi-pencil"></i>
                                                        </asp:LinkButton>
                                                        <asp:LinkButton
                                                            ID="btnEliminar"
                                                            runat="server"
                                                            CssClass="btn btn-outline-danger btn-sm rounded-circle"
                                                            OnClick="btnEliminar_Click"
                                                            CausesValidation="false"
                                                            CommandArgument='<%# Eval("IdCamion")%>'>
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

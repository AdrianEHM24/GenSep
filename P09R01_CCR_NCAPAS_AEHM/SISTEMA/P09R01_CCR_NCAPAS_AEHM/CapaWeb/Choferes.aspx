<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Choferes.aspx.cs" Inherits="CapaWeb.Choferes" MasterPageFile="~/Site.Master"%>

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
    </style>
</asp:Content>

<asp:Content ID="ContentScripts" ContentPlaceHolderID="PageScripts" runat="server">
    <script>
function validarMayorEdadCliente(source, args) {
    if (!args.Value) {
        args.IsValid = true; // El RequiredFieldValidator se encarga de si está vacío
        return;
    }

    // Convertir el valor del input a objeto Date
    var fechaNacimiento = new Date(args.Value);
    var hoy = new Date();

    // Calcular la fecha exacta en la que cumpliría 18 años
    var fechaMinima = new Date(fechaNacimiento.getFullYear() + 18, fechaNacimiento.getMonth(), fechaNacimiento.getDate());

    // Si la fecha mínima para tener 18 años es menor o igual a hoy, es mayor de edad
    if (fechaMinima <= hoy) {
        args.IsValid = true;
    } else {
        args.IsValid = false;
    }
}
</script>
</asp:Content>
<asp:Content ID="ContentChoferes" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        /* Adaptación de la sección de Choferes a Modo Oscuro */
.menu-page-container {
    background-color: #0b1426 !important;
    color: #ffffff !important;
}

.menu-main-title {
    color: #ffffff !important;
}

/* Tarjetas de choferes en modo oscuro */
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
    <asp:UpdatePanel ID="upChoferes" runat="server">
        <ContentTemplate>
            <div class="menu-page-container">
                <div class="container">
                    
                    <!-- Título de la Sección -->
                    <div class="text-center mb-5">
                        <span class="menu-subtitle">Administración de Personal</span>
                        <h2 class="menu-main-title">Módulo de <span>Choferes</span></h2>
                    </div>

                    <!-- MODAL DE FORMULARIO -->
                    <div class="modal fade" id="modalFormulario" tabindex="-1" aria-labelledby="modalFormularioLabel" aria-hidden="true">
                        <div class="modal-dialog modal-dialog-centered">
                            <div class="modal-content border-0 shadow">

                                <div class="modal-header border-bottom-0 pt-4 px-4">
                                    <h5 class="modal-title fw-bold text-dark" id="modalFormularioLabel">Datos del Chofer</h5>
                                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>

                                <div class="modal-body px-4 pb-4">
                                    <p class="text-muted small mb-4">Complete los campos obligatorios para dar de alta al chofer en el sistema.</p>

                                    <div>
                                        <asp:HiddenField ID="hfIdChofer" runat="server" Value='<%# Eval("IdChofer") %>' />
                                    </div>

                                    <div class="mb-3">
                                        <label for="<%=txtNombre.ClientID%>" class="form-label small fw-bold text-secondary">Nombre</label>
                                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control rounded-3 w-100 mw-100" placeholder="Ej. Carlos"></asp:TextBox>
                                        <asp:RequiredFieldValidator
                                            ID="rfvNombre" runat="server" ControlToValidate="txtNombre"
                                            ErrorMessage="Este campo es obligatorio" ForeColor="Red" Display="Dynamic" />
                                    </div>

                                    <div class="mb-3">
                                        <label for="<%=txtApPaterno.ClientID%>" class="form-label small fw-bold text-secondary">Apellido Paterno</label>
                                        <asp:TextBox ID="txtApPaterno" runat="server" CssClass="form-control rounded-3 w-100 mw-100" placeholder="Ej. Jiménez"></asp:TextBox>
                                        <asp:RequiredFieldValidator
                                            ID="rfvApPaterno" runat="server" ControlToValidate="txtApPaterno"
                                            ErrorMessage="Este campo es obligatorio" ForeColor="Red" Display="Dynamic" />
                                    </div>

                                    <div class="mb-3">
                                        <label for="<%=txtApMaterno.ClientID%>" class="form-label small fw-bold text-secondary">Apellido Materno</label>
                                        <asp:TextBox ID="txtApMaterno" runat="server" CssClass="form-control rounded-3 w-100 mw-100" placeholder="Ej. Pérez"></asp:TextBox>
                                        <asp:RequiredFieldValidator
                                            ID="rfvApMaterno" runat="server" ControlToValidate="txtApMaterno"
                                            ErrorMessage="Este campo es obligatorio" ForeColor="Red" Display="Dynamic" />
                                    </div>

                                    <div class="row g-3 mb-3">
                                        <div class="col-6">
                                            <label for="<%=txtTelefono.ClientID%>" class="form-label small fw-bold text-secondary">Teléfono</label>
                                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control rounded-3" placeholder="Ej. 2221194568" TextMode="Phone" MaxLength="10"></asp:TextBox>
                                            <asp:RequiredFieldValidator
                                                ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono"
                                                ErrorMessage="Este campo es obligatorio" ForeColor="Red" Display="Dynamic" />
                                            <asp:RegularExpressionValidator
                                                ID="revTelefono" runat="server" ControlToValidate="txtTelefono"
                                                ValidationExpression="^.{0,10}$" ErrorMessage="Máximo 10 caracteres"
                                                ForeColor="Red" Display="Dynamic" />
                                        </div>
                                        <div class="col-6">
                                            <label for="<%=txtFechaNacimiento.ClientID%>" class="form-label small fw-bold text-secondary">Fecha de Nacimiento</label>
                                            <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control rounded-3" TextMode="Date"></asp:TextBox>
                                            <asp:RequiredFieldValidator
                                                ID="rfvFechaNacimiento" runat="server" ControlToValidate="txtFechaNacimiento"
                                                ErrorMessage="Este campo es obligatorio" ForeColor="Red" Display="Dynamic" />
                                            <asp:CustomValidator
                                                ID="cvFechaNacimiento" runat="server" ControlToValidate="txtFechaNacimiento"
                                                ClientValidationFunction="validarMayorEdadCliente" OnServerValidate="cvMayorEdad_ServerValidate"
                                                ErrorMessage="Debe ser mayor de 18 años" ForeColor="Red" Display="Dynamic" />
                                        </div>
                                    </div>

                                    <div class="mb-3">
                                        <label for="<%=txtLicencia.ClientID%>" class="form-label small fw-bold text-secondary">Licencia</label>
                                        <asp:TextBox ID="txtLicencia" runat="server" CssClass="form-control rounded-3 w-100 mw-100" placeholder="Ej. LIC-A-12345"></asp:TextBox>
                                        <asp:RequiredFieldValidator
                                            ID="rfvLicencia" runat="server" ControlToValidate="txtLicencia"
                                            ErrorMessage="Este campo es obligatorio" ForeColor="Red" Display="Dynamic" />
                                    </div>

                                    <div class="mb-3">
                                        <label for="<%=txtUrlFoto.ClientID%>" class="form-label small fw-bold text-secondary">Url de la foto</label>
                                        <asp:TextBox ID="txtUrlFoto" runat="server" CssClass="form-control rounded-3 w-100 mw-100" placeholder="http://example.com/fotos/chofer.jpg"></asp:TextBox>
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
                                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar Chofer" OnClick="btnGuardar_Click" CssClass="btn btn-primary rounded-pill px-4" />
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

                    <!-- GRIDVIEW ADAPTADO A TARJETAS PARA CHOFERES -->
                    <div class="gridview-container-menu">
                        <asp:GridView ID="gvChoferes" runat="server"
                            AutoGenerateColumns="False"
                            EmptyDataText="No se encontraron choferes registrados"
                            GridLines="None"
                            ShowHeader="false">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <div class="row-card">

                                            <div class="row-card-image-wrapper">
                                                <img
                                                    src="<%# Eval("UrlFoto") %>"
                                                    onerror="this.onerror=null; this.src='https://cdn-icons-png.flaticon.com/512/149/149071.png';"
                                                    class="row-card-image"
                                                    alt="Chofer" />
                                                <span class='badge-floating <%# (bool)Eval("Disponibilidad") ? "badge-status-disponible" : "badge-status-no-disponible" %>'>
                                                    <%# (bool)Eval("Disponibilidad") ? "★ Disponible" : "✕ Ocupado" %>
                                                </span>
                                            </div>

                                            <div class="row-card-body">
                                                <div class="row-card-category"><%# Eval("NombreCompleto") %></div>
                                                <h3 class="row-card-title">Nacimiento: <%# String.Format("{0:dd/MM/yyyy}", Eval("FechaNacimiento")) %></h3>

                                                <div class="row-card-footer">
                                                    <div class="row-card-price-area">
                                                        <div class="row-card-price" style="font-size: 1.1rem;">
                                                            Lic: <%# Eval("Licencia") %>
                                                        </div>
                                                    </div>
                                                    <div class="button-group d-flex gap-2">
                                                        <asp:LinkButton
                                                            ID="btnEditar"
                                                            runat="server"
                                                            CssClass="btn btn-outline-primary btn-sm rounded-circle"
                                                            OnClick="btnEditar_Click"
                                                            CausesValidation="false"
                                                            CommandArgument='<%# Eval("IdChofer") %>'>
                                                            <i class="bi bi-pencil"></i>
                                                        </asp:LinkButton>
                                                        <asp:LinkButton
                                                            ID="btnEliminar"
                                                            runat="server"
                                                            CssClass="btn btn-outline-danger btn-sm rounded-circle"
                                                            OnClick="btnEliminar_Click"
                                                            CausesValidation="false"
                                                            CommandArgument='<%# Eval("IdChofer")%>'>
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

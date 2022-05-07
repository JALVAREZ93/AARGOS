<%@ Page Title="AARGOS" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AARGOSWEB._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-left: 250px; margin-right: 250px">
        <%-- #########################vehiculo###################--%>
        <h1 class="text-center titleStyle">Vehiculo</h1>
        <div style="text-align: center">

            <div class="contentForm">
                <div>
                    <p>MARCA:</p>
                </div>
                <div>
                    <asp:DropDownList   Style="margin-left: 100px" Width="300px"   runat="server"   ID="lstMarca" 
                        AutoPostBack="true"  OnSelectedIndexChanged="lstMarca_SelectedIndexChanged"  />
                    
                </div>
            </div>
            <div>
             <label id="msjMarca" runat="server" AutoPostBack="true"   Style="color:red">Debe seleccionar una Marca</label>
              </div>
            <br />
            <div class="contentForm">
                <div>
                    <p>SUBMARCA:</p>
                </div>
                <div>
                      <asp:DropDownList Style="margin-left: 100px" Width="300px" runat="server"  ID="lstSub" AutoPostBack="true" OnTextChanged="lstSub_SelectedIndexChanged"  />
                </div>
            </div>
            <div>
             <label id="msjSubMarca" runat="server" AutoPostBack="true"   Style="color:red">Debe seleccionar una submarca</label>
              </div>

            <div class="contentForm">
                <div>
                    <p>MÓDELO:</p>
                </div>
                <div>
                    <asp:DropDownList Style="margin-left: 100px" Width="300px" runat="server"  ID="lstModelo"  AutoPostBack="true" OnSelectedIndexChanged="lstModelo_SelectedIndexChanged"   />
                </div>
            </div>
            <div>
             <label id="msjModelo" runat="server" AutoPostBack="true"   Style="color:red">Debe seleccionar un modelo</label>
              </div>



            <div class="contentForm">
                <div>
                    <p>DESCRIPCIÓN:</p>
                </div>
                <div>
                    <asp:DropDownList Style="margin-left: 100px" Width="300px" runat="server" ID="lstDescription"  AutoPostBack="true" OnSelectedIndexChanged="lstDescription_SelectedIndexChanged" />
                </div>
            </div>
            <div>
             <label id="msjDescripcion" runat="server" AutoPostBack="true"   Style="color:red">Debe seleccionar una descripcion</label>
              </div>

        </div>
    </div>

   <%-- #########################Domicilio###################--%>
    <div style="margin-left: 250px; margin-right: 250px" id="DivDomicilio" runat="server" >
        <h1 class="text-center titleStyle">Domicilio</h1>

        <div class="text-center">
            <div class="contentForm">
                <div>
                    <p>CÓDIGO POSTAL:</p>
                </div>
                <div>
                    <asp:TextBox  placeholder="Código Postal" maxlength="5" runat="server"
                        ID="CP" OnTextChanged="CP_TextChanged" AutoPostBack="true"></asp:TextBox>
                      

                </div>
               
            </div>
        </div>
         <div>
             <label id="msjCp" runat="server" AutoPostBack="true"   Style="color:red">Ingrese un codigo postal</label>
              </div>
        <div class="contentForm">
            <div>
                <p>ESTADO:</p>
            </div>
            <div>
                <asp:TextBox placeholder="Estado" readonly runat="server"
                        ID="InpEstado" ></asp:TextBox>
            </div>
        </div>
        <div class="contentForm">
            <div>
                <p>MUNICIPIO:</p>
            </div>
            <div>
                <asp:TextBox placeholder="Municipio" readonly  runat="server"
                        ID="IntMunicipio" ></asp:TextBox>
            </div>
        </div>
        <div class="contentForm">
            <div>
                <p>COLONIA:</p>
            </div>
            <div>
                <asp:TextBox placeholder="Colonia" readonly  runat="server" ID="InpCol" ></asp:TextBox>
            </div>
        </div>

    </div>
    <%-- #########################Personas###################--%>
    <div style="margin-left: 250px; margin-right: 250px" id="DivPerson" runat="server">
        <h1 class="text-center titleStyle">Personas</h1>
        <div class="contentForm">
            <div>
                <p>FECHA NACIMIENTO:</p>
            </div>
            <div>
                <input type="date" runat="server" AutoPostBack="true" id="Fecha"/>
            </div>
        </div>
          <div>
             <label id="msjDate" runat="server" AutoPostBack="true"   Style="color:red">Ingrese una fecha</label>
              </div>
        <div class="contentForm">
            <div>
                <p>GENERO:</p>

            </div>
            <div>
                <asp:DropDownList Style="margin-left: 100px" Width="250px" runat="server" ID="lstGenero" />
            </div>
        </div>
          <div>
             <label id="msjGenero" runat="server" AutoPostBack="true"   Style="color:red">Seleccione un genero</label>
              </div>
        <div class="contentForm">
            <asp:Button ID="btnCotizar" runat="server" Text="Validar" Width="300" OnClick="btnCotizar_Click"  />
        </div>
    </div>
     <div style="width: 100%; height: 100%; vertical-align: middle margin-left: -88px; position: fixed; display: block; top: 0; left: 0; text-align: center; opacity: .9; background-color: #fff; z-index: 99;"
        id="dvProgress" runat="server">
        Espere ...<image src="./Content/images/loading.gif" style="vertical-align: middle; position: absolute; top: 26%; z-index: 100;" alt="cargando"/>
         </div>

    <script>
        setTimeout(() => { document.getElementById("MainContent_dvProgress").style.display = 'none'; }, 1000);
    </script>
</asp:Content>
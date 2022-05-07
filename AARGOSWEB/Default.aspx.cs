using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AARGOS.ENTITY;
using AARGOS.BL;
namespace AARGOSWEB
{
    public partial class _Default : Page
    {
        string head = "Seleccione un";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ListMarca();
                    LstGeneros();
                    validacion();
                    inicial();
                    DivDomicilio.Visible = false;
                    DivPerson.Visible = false;

                }

            }
            catch (Exception )
            {
                string script = string.Format("alert('fallo');");
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                throw;
            }
           
        }

        readonly Filtro filtro = new Filtro();
        
        protected void ListMarca()
        {
            try
            {
                               
                BindCatalog(lstMarca, "IdMarca", "Marca", filtro.LstMarcas(), head+"a marca");
            }
            catch (Exception)
            {
                string script = string.Format("alert('fallo');");
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);

                throw;
            }
            
        }

        
        protected void lstMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {               
                    int idMarca;
                    int.TryParse(lstMarca.SelectedItem.Value, out idMarca);
                    BindCatalog(lstSub, "IdSubMarca", "SubMarca", filtro.LstSubMarcas(idMarca), head+ "a submarca");
                   
            }
            catch (Exception )
            {
                string script = string.Format("alert('fallo');");
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
               
            }
            
        }

        protected void lstSub_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idSubmarca;
                int.TryParse(lstSub.SelectedItem.Value, out idSubmarca);
                BindCatalog(lstModelo, "IdModelo", "Modelo", filtro.Modelo(idSubmarca), head+ " Modelo");
                                
            }
            catch (Exception)
            {
                string script = string.Format("alert('fallo');");
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                throw;
            }
          
        }

        protected void lstModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idModelo;
                int.TryParse(lstModelo.SelectedItem.Value, out idModelo);
                BindCatalog(lstDescription, "IdDescripcionModelo", "Descripcion", filtro.lstDescriptions(idModelo), head +"a descripcion");
            }
            catch (Exception)
            {
                string script = string.Format("alert('fallo');");
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                throw;
            }
          
        }

        protected void LstGeneros()
        {
            try
            {
                CatFiltro Entfiltro = new CatFiltro();
                lstGenero.DataSource = filtro.Generos();
                lstGenero.DataTextField = "Genero";
                lstGenero.DataValueField = "Id";
                lstGenero.DataBind();
            }
           catch (Exception)
            {
                string script = string.Format("alert('fallo');");
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                throw;
            }

        }
        protected void BusquedaCp()
        {
            int cp;
            if (Int32.TryParse(CP.Text, out cp))
            {
                var domicilio = filtro.domicilio(cp);

                IntMunicipio.Text = domicilio.Municipio;
                InpEstado.Text = domicilio.Estado;
                InpCol.Text = domicilio.Colonia;
                msjCp.Visible = false;
                DivPerson.Visible = true;
            }

        }


        private void BindCatalog<T>(DropDownList lstCat, string id, string value, IEnumerable<T> data, string msj)
        {
            try
            {
                lstCat.Enabled = true;
                lstCat.DataSource = data;
                lstCat.DataTextField = value;
                lstCat.DataValueField = id;
                lstCat.DataBind();
                lstCat.Items.Insert(0, new ListItem(msj));
            }
            catch (Exception)
            {
                string script = string.Format("alert('fallo');");
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                throw;
            }
            
        }

      

        protected void CP_TextChanged(object sender, EventArgs e)
        {
            if (CP.Text.Length == 5)
            {
                BusquedaCp();
            }
        }

        protected void btnCotizar_Click(object sender, EventArgs e)
        {
          
            msjMarca.Visible = Convert.ToInt32(lstMarca.SelectedItem.Value) > 1 ? false : true;
            msjSubMarca.Visible = Convert.ToInt32(lstSub.SelectedItem.Value) < 1 ? true : false;
            msjModelo.Visible = Convert.ToInt32(lstModelo.SelectedItem.Value) < 1 ? true : false;
            msjDescripcion.Visible = Convert.ToInt32(lstDescription.SelectedItem.Value) < 1 ? true : false;
             


            msjCp.Visible = CP.Text.Length > 4 ? false : true;

            if (msjMarca.Visible == false)
            {
                if( msjSubMarca.Visible == false)
                {
                    if (msjModelo.Visible == false)
                    {
                        if (msjDescripcion.Visible == false)
                        {
                            if (msjCp.Visible == false)
                            {
                                string script = string.Format("alert('Datos correctos ');");
                                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                            }
                            else
                            {
                                string script = string.Format("alert('Faltan datos por llenar ');");
                                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                            }
                        }
                        else
                        {
                            string script = string.Format("alert('Faltan datos por llenar');");
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                        }
                    }
                    else
                    {
                        string script = string.Format("alert('Faltan datos por llenar');");
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                    }
                }
                else
                {
                    string script = string.Format("alert('Faltan datos por llenar');");
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                }
            }
            else
            {
                string script = string.Format("alert('Faltan datos por llenar');");
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }

        }


        protected void validacion()
        {
            msjMarca.Visible = false;
            msjSubMarca.Visible = false;
            msjModelo.Visible = false;
            msjDescripcion.Visible = false;
            msjCp.Visible = false;
            msjDate.Visible = false;
            msjGenero.Visible = false;
            lstMarca.Enabled = true;
            lstSub.Enabled = false;
            lstModelo.Enabled = false;
            lstDescription.Enabled = false;

        }

        protected void inicial()
        {
            
            lstSub.Items.Insert(0, new ListItem(head+"a submarca"));
            lstModelo.Items.Insert(0, new ListItem(head+ " modelo"));
            lstDescription.Items.Insert(0, new ListItem(head+ "a descripcion"));
        }

        protected void lstDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            DivDomicilio.Visible = true;
        }
    }
}




using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebApiClientLibrary;

namespace ClienteWF_EnMetodosHttp
{
    public partial class Form1 : Form
    {
        private System.Drawing.Color ColorSeleccion;
        private WebApiHttpClient HttpCliente;
        private string BaseURI
        {
            get
            {
                Enums.tipo_enrutamiento enrutamiento = 
                    ObenTipoDeEnrutamiento(cbTipoApi.SelectedItem.ToString());

                return enrutamiento == Enums.tipo_enrutamiento.METODOS_HTTP ?
                    ConfigurationManager.AppSettings["BaseURIHttpMethod"] :
                    enrutamiento == Enums.tipo_enrutamiento.NOMBRES_ACCIONES ?
                    ConfigurationManager.AppSettings["BaseURIActionNames"] :
                    ConfigurationManager.AppSettings["BaseURIAttribute"];
            }
        }
        private int ColorId
        {
            get
            {
                return
                    int.Parse(!string.IsNullOrEmpty(tbId.Text) ? tbId.Text : "0");
            }
        }

        public Form1()
        {
            InitializeComponent();
            tbColorSeleccionado.BackColor = System.Drawing.Color.Black;
            cbTipoApi.SelectedIndex = 0;
            tbInfoUri.Text = BaseURI;
        }

        private void btnSelecColor_Click(object sender, EventArgs e)
        {
            ColorDialog Ventana = new ColorDialog();
            Ventana.ShowDialog();
            ColorSeleccion = Ventana.Color;
            tbColorSeleccionado.BackColor = ColorSeleccion;
        }

        private async void btnGET_Click(object sender, EventArgs e)
        {
            HttpCliente = new WebApiHttpClient(BaseURI, ObenTipoDeEnrutamiento(
                cbTipoApi.SelectedItem.ToString()));
            WebApiClientLibrary.Color Color;

            try
            {
                Color = await HttpCliente.GetColorById(ColorId);
                CargaColor(Color);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ha fallado la solicitud GET; Error: {ex.Message}");
            }
        }

        private Enums.tipo_enrutamiento ObenTipoDeEnrutamiento(string elementoSeleccionado)
        {
            Enums.tipo_enrutamiento Enrutamiento;

            switch (elementoSeleccionado)
            {
                case "Métodos HTTP":
                    Enrutamiento = Enums.tipo_enrutamiento.METODOS_HTTP;
                    break;
                case "Nombres de Acciones":
                    Enrutamiento = Enums.tipo_enrutamiento.NOMBRES_ACCIONES;
                    break;
                case "Atributo":
                    Enrutamiento = Enums.tipo_enrutamiento.ATRIBUTO;
                    break;
                default:
                    Enrutamiento = Enums.tipo_enrutamiento.METODOS_HTTP;
                    break;
            }

            return Enrutamiento;
        }

        private async void btnPOST_Click(object sender, EventArgs e)
        {
            HttpCliente = new WebApiHttpClient(BaseURI, ObenTipoDeEnrutamiento(
                cbTipoApi.SelectedItem.ToString()));

            try
            {
                Uri Enlace = await HttpCliente.InsertColor(ObtenColor());
                MessageBox.Show("Se ha registrado correctamente el color");
                tbId.Text = Enlace.Segments[Enlace.Segments.Length - 1];
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ha fallado la solicitud POST; Error: {ex.Message}");
            }
        }

        private WebApiClientLibrary.Color ObtenColor()
        {
            return new WebApiClientLibrary.Color
            {
                Id = ColorId,
                Nombre = tbNombre.Text,
                Intensidad = tbIntensidad.Text,
                Tipo = int.Parse(tbTipo.Text),
                EsBrilosso = cbEsBrilloso.Checked,
                CodigoEx = tbColorSeleccionado.BackColor.ToArgb().ToString()
            };
        }

        private async void btnPUT_Click(object sender, EventArgs e)
        {
            HttpCliente = new WebApiHttpClient(BaseURI, ObenTipoDeEnrutamiento(
                cbTipoApi.SelectedItem.ToString()));

            try
            {
                await HttpCliente.UpdateColor(ColorId,
                    ObtenColor());
                MessageBox.Show("La actualización se ha realizado con éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ha fallado la solicitud PUT; Error: {ex.Message}");
            }
        }

        private async void btnDELETE_Click(object sender, EventArgs e)
        {
            HttpCliente = new WebApiHttpClient(BaseURI, ObenTipoDeEnrutamiento(
                cbTipoApi.SelectedItem.ToString()));
            WebApiClientLibrary.Color Color;

            try
            {
                Color = await HttpCliente.DeleteColor(ColorId);
                MessageBox.Show($"Se ha eliminado el color: {Color.Nombre}-{Color.Id}");
                LimpiaColor();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ha fallado la solicitud DELETE; Error: {ex.Message}");
            }
        }

        private void LimpiaColor()
        {
            tbId.Text = string.Empty;
            tbNombre.Text = string.Empty;
            tbIntensidad.Text = string.Empty;
            tbTipo.Text = string.Empty;
            cbEsBrilloso.Checked = false;
            tbColorSeleccionado.BackColor = System.Drawing.Color.Black;
        }

        private void CargaColor(WebApiClientLibrary.Color color)
        {
            tbId.Text = color.Id.ToString();
            tbNombre.Text = color.Nombre;
            tbIntensidad.Text = color.Intensidad;
            tbTipo.Text = color.Tipo.ToString();
            cbEsBrilloso.Checked = color.EsBrilosso;
            tbColorSeleccionado.BackColor =
                System.Drawing.Color.FromArgb(int.Parse(color.CodigoEx));
        }

        private void cbTipoApi_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbInfoUri.Text = BaseURI;
        }
    }
}

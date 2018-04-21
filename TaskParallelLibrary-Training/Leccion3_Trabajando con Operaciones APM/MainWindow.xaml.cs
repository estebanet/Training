using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Leccion3_Trabajando_con_Operaciones_APM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnValidarURL_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //HttpWebRequest webRequest = (HttpWebRequest)WebRequest
                //    .Create(tbURL.Text);

                //IAsyncResult asyncResultado =
                //    webRequest.BeginGetResponse(MetodoAsync, webRequest);
                //Task<WebResponse> taskResultado =
                //    Task<WebResponse>.Factory.FromAsync(webRequest.BeginGetResponse,
                //        webRequest.EndGetResponse, webRequest);

                //var resultado = await taskResultado as HttpWebResponse;
                //lblResultado.Content = $"El estatus de la petición es: {resultado.StatusDescription}";

                FileStream fileStream = new FileStream(
                    @"C:\Users\estebangaro\Documents\GitHub\Training\AzureTableStorage-Documentation\Microsoft-Azure-Table-Storage\App.config",
                    FileMode.Open, FileAccess.Read);

                byte[] bytesFile = new byte[fileStream.Length];
                //fileStream.BeginRead(bytesFile, 0, (int)fileStream.Length, asyncResult =>
                //{
                //    int noBytes = (asyncResult.AsyncState as FileStream).EndRead(asyncResult);

                //    using (MemoryStream msFileConfig = new MemoryStream(bytesFile))
                //    {
                //        using (StreamReader strwFileConfig = new StreamReader(msFileConfig))
                //        {
                //            string fileRow = string.Empty;
                //            while (!string.IsNullOrEmpty(fileRow = strwFileConfig.ReadLine()))
                //            {
                //                lblResultado.Dispatcher.Invoke(() =>
                //                {
                //                    lblResultado.Content += $"{fileRow}{Environment.NewLine}";
                //                });
                //            }
                //        }
                //    }

                //}, fileStream);

                Task<int> resultadoT = Task<int>.Factory.FromAsync<byte[], int, int>(fileStream.BeginRead, fileStream.EndRead,
                    bytesFile, 0, (int)fileStream.Length, fileStream);

                var noI = await resultadoT;

                using (MemoryStream msFileConfig = new MemoryStream(bytesFile))
                {
                    using (StreamReader strwFileConfig = new StreamReader(msFileConfig))
                    {
                        string fileRow = string.Empty;
                        while (!string.IsNullOrEmpty(fileRow = strwFileConfig.ReadLine()))
                        {
                            lblResultado.Dispatcher.Invoke(() =>
                            {
                                lblResultado.Content += $"{fileRow}{Environment.NewLine}";
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblResultado.Content = $"La ejecución ha generado una excepción: {ex.Message}";
            }
        }

        private void MetodoAsync(IAsyncResult ar)
        {
            HttpWebRequest wr = ar.AsyncState as HttpWebRequest;
            HttpWebResponse webResponse = wr.EndGetResponse(ar) as HttpWebResponse;
            
            lblResultado.Dispatcher.Invoke(() =>
            {
                lblResultado.Content = $"El estatus de la petición es: {webResponse.StatusDescription}";
            });
        }
    }
}

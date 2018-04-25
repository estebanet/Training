using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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

namespace Leccion3_Manejando_excepciones_en_Awaitable_Method
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Continuar con excepciones no observadas - Lección 3 - Manejando excepciones en métodos esperables.
        }

        private async void GetWebContent_Click(object sender, RoutedEventArgs e)
        {
            using (WebClient webClientObj = new WebClient())
            {
                Task<string> result = null;
                try
                {

                    //string resultado = await Task.Run<string>(() => { Thread.Sleep(3000); throw new Exception("Fail"); return "Hola :)"; });

                    //result = webClientObj.DownloadStringTaskAsync("http://ticapacitacion.com2");

                    //var contentString = await result;

                    var resultadoT = GetStringAsync();

                    Result.Content = await resultadoT;

                    //var content = result.Result; No funciona

                    //Task.WaitAll(result); No funciona

                }
                catch (WebException we)
                {
                    Result.Content = $"Se ha generado una excepción: {we.Message}, " +
                        $"Estatus de Task: {result?.Status}";
                }
                catch (AggregateException ae)
                {
                    Result.Content = "Excepción manejada de tipo AggregateException";
                }
                catch (Exception ex)
                {
                    Result.Content = $"Excepción manejada de tipo Exception; Error: {ex.Message}";
                }
            }
        }

        public async Task<string> GetStringAsync()
        {
            string resultado = string.Empty;

            var t1= Task.Run(() => { Thread.Sleep(3000); throw new Exception("Fail"); return "Hola :)"; });
            var t2 = Task.Run(() => { Thread.Sleep(1000); throw new Exception("Fail 2"); return "Hola :)"; });

            //resultado = await t1;

            resultado += await t2;

            resultado = await t1;

            return resultado;
        }
    }
}

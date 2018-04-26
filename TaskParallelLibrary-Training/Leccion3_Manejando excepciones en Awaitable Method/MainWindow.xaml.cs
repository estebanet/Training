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
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

            //Continuar con excepciones no observadas - Lección 3 - Manejando excepciones en métodos esperables.
        }

        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            foreach (var exception in e.Exception.InnerExceptions)
            {
                Result.Dispatcher.Invoke(() =>
                {
                    Result.Content += $"{Environment.NewLine}{exception.Message}";
                });
            }

            e.SetObserved();
        }

        private void GetWebContent_Click(object sender, RoutedEventArgs e)
        {
            //using (WebClient webClientObj = new WebClient())
            //{
            //Task<string> resultadoT = null;
            //try
            //{

            //string resultado = await Task.Run<string>(() => { Thread.Sleep(3000); throw new Exception("Fail"); return "Hola :)"; });

            //result = webClientObj.DownloadStringTaskAsync("http://ticapacitacion.com2");

            //var contentString = await result;

            //GetStringAsync2();

            Task.Run(async () =>
            {

                string resultado = string.Empty;
                string t2;
                //var t1= Task.Run(() => { throw new Exception("Fail"); return "Hola :)"; });
                using (WebClient wc = new WebClient())
                {
                    t2 = await wc.DownloadStringTaskAsync("http://www.capacitacion.com2");
                }
                //resultado = await t1;

                resultado += t2;
                //resultado = await t1;

                return resultado;

            });

            //resultadoT.Wait();

            //Result.Content = await resultadoT;

            //var content = result.Result; No funciona

            //Task.WaitAll(result); No funciona

            //}
            //catch (WebException we)
            //{
            //    Result.Content = $"Se ha generado una excepción: {we.Message}, " +
            //        $"Estatus de Task:";
            //}
            //catch (AggregateException ae)
            //{
            //    Result.Content = "Excepción manejada de tipo AggregateException";
            //}
            //catch (Exception ex)
            //{
            //    Result.Content = $"Excepción manejada de tipo Exception; Error: {ex.Message}";
            //}
            //Thread.Sleep(6000);
            //resultadoT = null;
            Thread.Sleep(3000);
                GC.WaitForPendingFinalizers();
                GC.Collect();
                Result.Content += "Tarea finalizada";
            //}
        }

        public async Task<string> GetStringAsync()
        {
            string resultado = string.Empty;
            string t2;
            //var t1= Task.Run(() => { throw new Exception("Fail"); return "Hola :)"; });
            using (WebClient wc = new WebClient())
            {
                t2 = await wc.DownloadStringTaskAsync("http://www.capacitacion.com2");
            }
            //resultado = await t1;

            resultado += t2;
            //resultado = await t1;

            return resultado;
        }

        public Task<string> GetStringAsync2()
        {
            return Task.Run(async () => { return await GetStringAsync(); });
        }
    }
}

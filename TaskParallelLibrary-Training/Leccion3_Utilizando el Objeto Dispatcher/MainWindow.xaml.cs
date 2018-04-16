using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Threading;

namespace Leccion3_Utilizando_el_Objeto_Dispatcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Boton2_funcion(null, null);
        }

        void ShowMessage(string message)
        {
            Resultado.Content += $"{message}, Thread: {Thread.CurrentThread.ManagedThreadId}";
        }

        private void Boton_Click(object sender, RoutedEventArgs e)
        {
            Dispatcher dispatcher = Dispatcher.CurrentDispatcher;
            Task.Run(() =>
            {
                string _Resultado = "Resultado obtenido";
                dispatcher
                    .BeginInvoke(new ShowMessageDelegate(ShowMessage), _Resultado);
            });
        }

        delegate void ShowMessageDelegate(string m);

        private void Boton2_funcion(object sender, RoutedEventArgs e)
        {
            tcs = new CancellationTokenSource();
            var ct = tcs.Token;

            Task.Run(() =>
            {
                dispatcher1 = Dispatcher.CurrentDispatcher;
                while (!ct.IsCancellationRequested)
                {
                    Thread.Sleep(2000);
                }
                Resultado.Dispatcher
                    .BeginInvoke(new ShowMessageDelegate(ShowMessage), 
                    $"Por finalizar ejecución de tarea, Thread: {Thread.CurrentThread.ManagedThreadId}");
            });
        }

        CancellationTokenSource tcs { get; set; }
        Dispatcher dispatcher1 { get; set; }

        private void Boton2_Click(object sender, RoutedEventArgs e)
        {
            ShowMessage($"Apunto de solicitar ejecución de delegado en Thread: {dispatcher1.Thread.ManagedThreadId}");
            dispatcher1.BeginInvoke(new Action(() =>
            {
                System.Diagnostics.Debug.WriteLine("Ejecutando delegado test!");
                Resultado.Dispatcher
                    .BeginInvoke(new ShowMessageDelegate(ShowMessage),
                    $"Mensaje Test ; Thread {Thread.CurrentThread.ManagedThreadId}!");
            }));
        }

        private void Boton3_Click(object sender, RoutedEventArgs e)
        {
            tcs.Cancel();
        }
    }
}

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

namespace Leccion3_Utilizando_async_y_await
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dispatcher Dispatcher { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Dispatcher = Dispatcher.CurrentDispatcher;
        }

        private async void btnResult_Click(object sender, RoutedEventArgs e)
        {
            Task<string> T = new Task<string>(() =>
            {
                System.Diagnostics.Debug.WriteLine($"Hilo que ejecuta la tarea: " +
                    $"{Thread.CurrentThread.ManagedThreadId}");

                Thread.Sleep(10000);

                return "2509";
            });

            await RunTaskAsync(T, "Thread Principal");
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(async delegate
            {
                Task<string> T = new Task<string>(() =>
                {
                    System.Diagnostics.Debug.WriteLine($"Hilo que ejecuta la tarea: " +
                        $"{Thread.CurrentThread.ManagedThreadId}");

                    Thread.Sleep(10000);

                    return "2509";
                });

                await RunTaskAsync(T, "Tarea");
            });
        }

        Task MuestraMensaje(string mensaje)
        {
            return Task.Run(() =>
            {
                Thread.Sleep(7000);
                Dispatcher.Invoke(new Action<string>((msj) =>
                {
                    lblResult.Content = msj;
                }), mensaje);
            });
        }

        async Task RunTaskAsync(Task<string> T, string context)
        {
            Dispatcher.Invoke(() =>
            {
                lblResult.Content = $"Obteniendo resultado...({context})";
            });
            System.Diagnostics.Debug.WriteLine($"Hilo que inicia la tarea: {Thread.CurrentThread.ManagedThreadId}...({context})");

            T.Start();

            System.Diagnostics.Debug.WriteLine($"Hilo antes del operador await: " +
                $"{Thread.CurrentThread.ManagedThreadId}...({context})");
            string taskValue = await T;
            System.Diagnostics.Debug.WriteLine($"Hilo despues del operador await: " +
                $"{Thread.CurrentThread.ManagedThreadId}...({context})");
            Dispatcher.Invoke(() =>
                {
                    lblResult.Content += $"{Environment.NewLine}El resultado obtenido es: {taskValue}...({context})";
                });
        }
    }
}

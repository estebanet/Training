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

namespace Leccion3_Creando_Metodos_Esperables
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

        async Task<string> GetProductName(int id)
        {
            string ProductName =
                await Task.Run<string>(() =>
            {
                Thread.Sleep(10000);
                return "Chai";
            });

            return ProductName;
        }

        private async void ObtenerResultado_Click(object sender, RoutedEventArgs e)
        {
            StartCountClock();

            Result.Content = "Obteniendo resultado...";
            //string productName = await GetProductName(1);
            //Result.Content += $"{Environment.NewLine}Nombre de producto: {productName}";
            //await ShowName(2);

            var ProductName = GetProductName(1);
            var ProductName2 = ShowName(2);

            string ProductNameResult = await ProductName;
            Result.Content += $"{Environment.NewLine}Nombre de producto: {ProductNameResult}";
            await ProductName2;
        }

        async Task ShowName(int ProductId)
        {
            string Result = string.Empty;
            await Task.Run(() =>
            {
                Thread.Sleep(10000);
                Result = "Chai 2";
            });

            this.Result.Content += $"{Environment.NewLine}Producto 2: {Result}";
        }
        
        void StartCountClock()
        {
            int count = 0;
            Task.Run(() =>
            {
                while (count < 120)
                {
                    Clock.Dispatcher.Invoke(() =>
                    {
                        Clock.Content = $"{count++} segundos";
                    });

                    Thread.Sleep(1000);
                }
            });
        }
    }
}

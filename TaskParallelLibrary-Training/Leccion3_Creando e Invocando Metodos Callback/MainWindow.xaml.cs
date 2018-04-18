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

namespace Leccion3_Creando_e_Invocando_Metodos_Callback
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        delegate Task RemoveDuplicateProductsDelegate(List<string> Products);

        public MainWindow()
        {
            InitializeComponent();
        }

        async Task GetAllProducts(RemoveDuplicateProductsDelegate callbackMethod = null)
        {
            List<string> Products = await Task.Run<List<string>>(() =>
            {
                Thread.Sleep(10000);
                return new List<string> { "Papa", "Frijol", "Chicharron", "Adobo",
                    "Papa con longaniza", "Adobo", "Chicharron", "Frijol" };
            });

            if (callbackMethod != null)
                await callbackMethod(Products);
            else
                Names.ItemsSource = Products;
        }

        async Task ProccessProducts(List<string> Products)
        {
            List<string> UniqueProducts = await Task.Run(() =>
            {
                return Products.Distinct().ToList();
            });

            Names.ItemsSource = UniqueProducts;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await GetAllProducts();
        }
    }
}

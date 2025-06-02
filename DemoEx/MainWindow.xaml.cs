using System;
using System.Collections.Generic;
using System.Linq;
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
using DemoEx.DBmodel;

namespace DemoEx
{
    public partial class MainWindow : Window
    {
        private readonly DEMOdemoEntities dbContext;
        private readonly Users _currentUser;

        public MainWindow(Users user)
        {
            InitializeComponent();
            dbContext = new DEMOdemoEntities();
            _currentUser = user;
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string productName = ProductNameTextBox.Text;
                if (string.IsNullOrWhiteSpace(productName))
                {
                    MessageBox.Show("Введите название товара.");
                    return;
                }

                if (!decimal.TryParse(ProductPriceTextBox.Text, out decimal productPrice))
                {
                    MessageBox.Show("Введите корректную цену товара.");
                    return;
                }

                string productDescription = ProductDescriptionTextBox.Text;

                var newProduct = new Products
                {
                    ProductName = productName,
                    Price = productPrice,
                    Description = productDescription
                };

                dbContext.Products.Add(newProduct);
                dbContext.SaveChanges();

                MessageBox.Show("Товар успешно добавлен.");

                // Очистка полей после добавления
                ProductNameTextBox.Clear();
                ProductPriceTextBox.Clear();
                ProductDescriptionTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении товара: {ex.Message}");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Возврат к списку товаров, передаём текущего пользователя обратно
            DataGrid dataGridWindow = new DataGrid(_currentUser);
            dataGridWindow.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Авторизация");
        }
    }
}

using System;
using System.IO;
using System.Linq;
using System.Windows;
using DemoEx.DBmodel;
using static System.Net.WebRequestMethods;

namespace DemoEx
{
    public partial class DataGrid : Window
    {
        private readonly DEMOdemoEntities _dbContext;
        private readonly Users _currentUser;

        public DataGrid(Users user)
        {
            InitializeComponent();
            _dbContext = new DEMOdemoEntities();
            _currentUser = user;

            LoadProducts();

            if (_currentUser.Roles.RoleName == "Manager")
            {
                DelButton.IsEnabled = false;
            }
        }

        private void LoadProducts()
        {
            try
            {
                var products = _dbContext.Products.ToList();
                ProductsDataGrid.ItemsSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
            }
        }
                
        private void DelButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = ProductsDataGrid.SelectedItem as Products;
            if (selectedProduct == null)
            {
                MessageBox.Show("Выберите товар для удаления.");
                return;
            }

            _dbContext.Products.Remove(selectedProduct);
            _dbContext.SaveChanges();
            LoadProducts();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
        }
    }
}

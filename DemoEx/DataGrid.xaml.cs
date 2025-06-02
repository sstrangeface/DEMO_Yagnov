using System;
using System.IO;
using System.Linq;
using System.Windows;
using DemoEx.DBmodel;

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
                AddButton.IsEnabled = false;
                EditButton.IsEnabled = false;
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

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Передаём пользователя в MainWindow
            MainWindow mainWindow = new MainWindow(_currentUser);
            mainWindow.Show();
            this.Close();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = ProductsDataGrid.SelectedItem as Products;
            if (selectedProduct == null)
            {
                MessageBox.Show("Выберите товар для редактирования.");
                return;
            }

            var productToEdit = new Products
            {
                ProductID = selectedProduct.ProductID,
                ProductName = selectedProduct.ProductName,
                Price = selectedProduct.Price,
                Description = selectedProduct.Description
            };

            var editWindow = new EditWindow(productToEdit, _dbContext);
            if (editWindow.ShowDialog() == true)
            {
                selectedProduct.ProductName = productToEdit.ProductName;
                selectedProduct.Price = productToEdit.Price;
                selectedProduct.Description = productToEdit.Description;

                _dbContext.SaveChanges();
                ProductsDataGrid.Items.Refresh();
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

        private void ExpButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var time = DateTime.Today.ToShortDateString().Replace('.', '-');
                string filePath = $"{time}_report.csv";

                var data = ProductsDataGrid.ItemsSource.Cast<Products>().ToList();

                var csvContent = new System.Text.StringBuilder();
                csvContent.AppendLine("Название;Цена;Описание");

                foreach (var item in data)
                {
                    csvContent.AppendLine(
                        $"\"{item.ProductName?.Replace("\"", "\"\"")}\";" +
                        $"{item.Price.ToString().Replace(",", ".")};" +
                        $"\"{item.Description?.Replace("\"", "\"\"")}\"");
                }

                File.WriteAllText(filePath, csvContent.ToString(), System.Text.Encoding.UTF8);
                MessageBox.Show($"Данные успешно импортированы: {Path.GetFullPath(filePath)}",
                                "Импорт завершен",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при экспорте: {ex.Message}",
                                "Ошибка",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
        }
    }
}

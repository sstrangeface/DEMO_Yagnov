using System.Windows;
using DemoEx.Services;
using DemoEx.Logic;
using DemoEx.DBmodel;
using DemoEx.Model;


namespace DemoEx
{
    public partial class AuthWindow : Window
    {
        private IAuthService _authService;

        public AuthWindow()
        {
            InitializeComponent();
            _authService = new AuthService();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            string login = tbxlogin.Text;
            string pass = tbxPass.Text;

            Users user = _authService.Authenticate(login, pass);

            if (user != null)
            {
                MessageBox.Show($"Добро пожаловать, {user.Login}!\nВаша роль: {user.Roles.RoleName}",
                                "Успешная авторизация", MessageBoxButton.OK, MessageBoxImage.Information);

                // Открываем DataGrid и передаём пользователя
                DataGrid dataGridWindow = new DataGrid(user);
                dataGridWindow.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка, проверьте правильность введённых данных",
                                "Ошибка входа", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}

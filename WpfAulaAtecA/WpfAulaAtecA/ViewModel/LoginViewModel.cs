using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Net.Http;
using System.Windows.Input;
using WpfAulaAtecA.Models;
using WpfAulaAtecA.Utils;
using WpfAulaAtecA.View;
using WpfAulaAtecA.ViewModel;

namespace WpfAulaAtecA.ViewModel
{
    public partial class LoginViewModel : ViewModelBase
    {
        private string _userName;
        private string _password;
        private string _errorMessage;

        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(async () => await OnLoginAsync(), CanLogin);
        }

        private bool CanLogin()
        {
            return !string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password);
        }

        private async System.Threading.Tasks.Task OnLoginAsync()
        {
            ErrorMessage = string.Empty;

            if (!CanLogin())
            {
                ErrorMessage = "Usuario o contraseña vacíos.";
                return;
            }

            var loginDto = new LoginUserDTO
            {
                Email = UserName,
                Password = Password
            };

            var usuario = await HttpJsonClient<UserDTO>.Post("https://localhost:5001/api/login", loginDto) as UserDTO;

            if (usuario != null)
            {
                // Login correcto → abrir ventana principal
                var mainWindow = new MainWindow();
                Application.Current.MainWindow.Close();
                Application.Current.MainWindow = mainWindow;
                mainWindow.Show();
            }
            else
            {
                ErrorMessage = "Credenciales incorrectas.";
            }
        }
    }
}



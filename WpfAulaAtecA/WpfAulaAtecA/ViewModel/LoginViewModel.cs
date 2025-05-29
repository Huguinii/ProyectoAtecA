using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WpfAulaAtecA.Models;
using WpfAulaAtecA.Utils;

namespace WpfAulaAtecA.ViewModel
{
    public partial class LoginViewModel : ViewModelBase
    {

        [ObservableProperty]
        public string _UserName;


        public string Password;
        [ObservableProperty] 
        public string _ErrorMessage;


        public override Task LoadAsync()
        {
            return base.LoadAsync();
        }

        private bool CanLogin()
        {
            return !string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password);
        }

        [RelayCommand]
        public async Task Login()
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
                /*Login correcto → abrir ventana principal
                var mainWindow = App.Current.Services.GetService<MainWindow>();
                mainWindow?.Show();
                App.Current.MainWindow.Close();
                App.Current.MainWindow = mainWindow;
                mainWindow.Show();
                */
            }
            else
            {
                ErrorMessage = "Credenciales incorrectas.";
            }
        }
    }
}



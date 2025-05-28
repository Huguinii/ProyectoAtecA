using CommunityToolkit.Mvvm.ComponentModel;
using System.Net.Http;
using System.Windows.Input;
using WpfAulaAtecA.View;

namespace WpfAulaAtecA.ViewModel
{
    public partial class LoginViewModel : ViewModelBase
    {
        private string _userName;
        private string _password;
        private string _errorMessage;

        // Instancia estática de HttpClient para realizar solicitudes HTTP
        private static readonly HttpClient httpClient = new HttpClient();

        // Propiedades de enlace de datos
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

        // Comando de inicio de sesión que llama a OnLoginAsync
        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            // Asocia el comando LoginCommand al método OnLoginAsync
            //LoginCommand = new RelayCommand(async (parameter) => await OnLoginAsync(), CanLogin);
        }

    }
}



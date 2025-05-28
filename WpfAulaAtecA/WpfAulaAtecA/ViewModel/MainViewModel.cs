using WpfAulaAtecA.ViewModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WpfAulaAtecA.ViewModel
{
    public partial class MainViewModel : ViewModelBase
    {

        private ViewModelBase? _selectedViewModel;

        public MainViewModel(ReservasPendientesViewModel reservasPendientesViewModel, LoginViewModel loginViewModel)
        {
            _selectedViewModel = loginViewModel;
            ReservasPendientesViewModel = reservasPendientesViewModel;
            LoginViewModel = loginViewModel;
        }

        public ViewModelBase? SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                SetProperty(ref _selectedViewModel, value);
            }
        }

        public ReservasPendientesViewModel ReservasPendientesViewModel { get; }
        public LoginViewModel LoginViewModel { get; }

        public async override Task LoadAsync()
        {
            if (SelectedViewModel is not null)
            {
                await SelectedViewModel.LoadAsync();
            }
        }
        [RelayCommand]
        private async Task SelectViewModel(object? parameter)
        {
            SelectedViewModel = parameter as ViewModelBase;
            await LoadAsync();
        }

    }
}

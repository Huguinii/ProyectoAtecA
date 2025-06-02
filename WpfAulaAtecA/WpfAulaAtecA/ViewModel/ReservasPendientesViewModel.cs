using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using WpfAulaAtecA.Interface;
using WpfAulaAtecA.Models;
using WpfAulaAtecA.Services;

namespace WpfAulaAtecA.ViewModel
{
    public partial class ReservasPendientesViewModel : ViewModelBase
    {
        private readonly IGetReservaApiService _reservaService;

        public ReservasPendientesViewModel()
        {
            _reservaService = new GetReservaApiService();
            Reservas = new ObservableCollection<ReservaDTO>();
        }

        [ObservableProperty]
        private ObservableCollection<ReservaDTO> reservas;

        public override async Task LoadAsync()
        {
            var data = await _reservaService.GetReservasPendientes();
            Reservas = new ObservableCollection<ReservaDTO>(data);
        }

        [RelayCommand]
        public async Task Aprobar(ReservaDTO reserva)
        {
            if (reserva == null) return;

            bool ok = await _reservaService.AprobarReserva(reserva.Id);
            if (ok)
            {
                MessageBox.Show("Reserva aprobada.");
                await LoadAsync();
            }
        }


        [RelayCommand]
        public async Task Rechazar(ReservaDTO reserva)
        {
            if (reserva == null) return;

            bool ok = await _reservaService.RechazarReserva(reserva.Id);
            if (ok)
            {
                MessageBox.Show("Reserva rechazada.");
                await LoadAsync();
            }
        }

    }
}

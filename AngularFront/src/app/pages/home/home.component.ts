import { Component, effect, signal } from '@angular/core';
import { NgFor, NgIf } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReservaService } from 'src/app/service/reserva.service';
import { CrearReservaModel } from 'src/app/models/crear-reserva-model';
import { ReservaModel } from 'src/app/models/reserva-model';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [NgFor, NgIf, FormsModule],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  reservas = signal<ReservaModel[]>([]);
  mensaje = signal('');
  nuevaReserva = signal<CrearReservaModel>({
    fecha: '',
    horaInicio: '',
    horaFin: '',
    grupo: '',
    nombreProfesor: ''
  });

  constructor(private reservaService: ReservaService) {
    this.cargarReservas();
  }

  updateCampo(clave: keyof CrearReservaModel, valor: string) {
    this.nuevaReserva.update(n => ({ ...n, [clave]: valor }));
  }


  async cargarReservas() {
    try {
      const data = await this.reservaService.getAllReservas();
      this.reservas.set(data);
    } catch (error) {
      this.mensaje.set('Error al cargar reservas');
    }
  }

  async crearReserva() {
    try {
      const reserva = await this.reservaService.crearReserva(this.nuevaReserva());
      this.reservas.update(r => [...r, reserva]);
      this.mensaje.set('Reserva creada con éxito');
      this.nuevaReserva.set({ fecha: '', horaInicio: '', horaFin: '', grupo: '', nombreProfesor: '' });
    } catch (error) {
      this.mensaje.set('Error al crear la reserva');
    }
  }

  async eliminarReserva(id: string) {
    const ok = await this.reservaService.eliminarReserva(id);
    if (ok) {
      this.reservas.update(r => r.filter(res => res.id !== id));
    } else {
      this.mensaje.set('Error al eliminar la reserva');
    }
  }
}

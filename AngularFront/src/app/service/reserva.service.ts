// src/app/services/reserva.service.ts
import { Injectable } from '@angular/core';
import { CrearReservaModel } from '../models/crear-reserva-model';
import { ReservaModel } from '../models/reserva-model';


@Injectable({
  providedIn: 'root'
})
export class ReservaService {
  private readonly baseUrl = 'https://localhost:7777/api/Reserva';

  constructor() {}

  private getAuthHeaders(): { [key: string]: string } {
  const token = localStorage.getItem('token');
  return {
    'Authorization': `Bearer ${token}`,
    'Content-Type': 'application/json'
  };
}


  async crearReserva(dto: CrearReservaModel): Promise<ReservaModel> {
  // Asegura que la hora tenga el formato HH:mm:ss
  const formatHora = (hora: string) =>
    hora.length === 5 ? `${hora}:00` : hora; // si es "12:30", lo convierte en "12:30:00"

  const dtoFormateado: CrearReservaModel = {
    ...dto,
    horaInicio: formatHora(dto.horaInicio),
    horaFin: formatHora(dto.horaFin)
  };

  const response = await fetch(this.baseUrl, {
    method: 'POST',
    headers: this.getAuthHeaders(),
    body: JSON.stringify({ CrearReservaModel: dtoFormateado })
  });

  if (!response.ok) {
    const mensajeError = await response.text();
    console.error('Error al crear reserva:', mensajeError);
    throw new Error(mensajeError || 'Error al crear la reserva');
  }

  return await response.json();
}




  async getAllReservas(): Promise<ReservaModel[]> {
  const response = await fetch(this.baseUrl, {
    method: 'GET',
    headers: this.getAuthHeaders()
  });

  if (!response.ok) {
    const errorText = await response.text();
    console.error("Error al cargar reservas:", errorText);
    throw new Error("Error al obtener las reservas.");
  }

  return (await response.json()) ?? [];
}


  async eliminarReserva(id: string): Promise<boolean> {
    const response = await fetch(`${this.baseUrl}/${id}`, {
      method: 'DELETE',
      headers: this.getAuthHeaders()
    });

    if (!response.ok) {
      const mensajeError = await response.text();
      console.error(`Error al eliminar reserva ${id}:`, mensajeError);
    }

    return response.ok;
  }
}

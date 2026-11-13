import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

const API_URL = 'http://localhost:5169/api/Evento';

export interface eventos {
  id: number;
  title: string;
  descripcion: string;
  fechaInicio: Date;
  fechaFin: Date;
  ubicacion: string;
  organizadorId: number;
}

@Injectable({
  providedIn: 'root',
})
export class EventService {
  private http = inject(HttpClient);

  listar(): Observable<eventos[]> {
    return this.http.get<eventos[]>(API_URL);
  }
}

import { Component, OnInit, inject, signal } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { EventService, eventos } from '../../services/event-service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-event-compoment',
  imports: [CommonModule, MatTableModule],
  templateUrl: './event-compoment.html',
  styleUrl: './event-compoment.css',
})
export class EventCompoment implements OnInit {
  private eventService = inject(EventService);

  dataSource = signal<eventos[]>([]);

  displayedColumns: string[] = ['id', 'title', 'ubicacion', 'descripcion', 'fechaInicio'];

  ngOnInit(): void {
    this.eventService.listar().subscribe({
      next: (data) => {
        this.dataSource.set(data);
        console.log(data);
      },
      error: (err) => console.error('Error al consumir la API:', err),
    });
  }
}

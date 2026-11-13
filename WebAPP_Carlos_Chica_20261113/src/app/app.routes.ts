import { Routes } from '@angular/router';
import { EventCompoment } from './component/event-compoment/event-compoment';

export const routes: Routes = [
  { path: '', component: EventCompoment },
  { path: '**', redirectTo: '' },
];

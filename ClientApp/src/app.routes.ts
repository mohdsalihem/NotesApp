import { Routes } from '@angular/router';
import { AboutComponent } from './app/about/about.component';
import { AuthGuard } from './app/guards/auth.guard';

export const routes: Routes = [
  { path: 'about', component: AboutComponent },
  {
    path: 'user',
    loadChildren: () => import('./app/user/user.routes'),
  },
  {
    path: 'note',
    canActivate: [AuthGuard],
    loadChildren: () => import('./app/note/note.routes'),
  },
  { path: '**', redirectTo: 'note' },
];

import { Routes } from '@angular/router';
import { AboutComponent } from './about/about.component';
import { AuthGuard } from './guards/auth.guard';

export const routes: Routes = [
  { path: 'about', component: AboutComponent },
  {
    path: 'user',
    loadChildren: () => import('./user/user.routes'),
  },
  {
    path: 'note',
    canActivate: [AuthGuard],
    loadChildren: () => import('./note/note.routes'),
  },
  { path: '**', redirectTo: 'note' },
];

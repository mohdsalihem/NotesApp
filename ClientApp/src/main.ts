import { enableProdMode, importProvidersFrom } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { environment } from './environments/environment';
import { AppComponent } from './app/app.component';
import { AppRoutingModule } from './app/app-routing.module';
import { UserModule } from './app/user/user.module';
import { NoteModule } from './app/note/note.module';
import { BrowserModule, bootstrapApplication } from '@angular/platform-browser';
import { JwtInterceptor } from './app/interceptor/jwt.interceptor';
import {
  HTTP_INTERCEPTORS,
  withInterceptorsFromDi,
  provideHttpClient,
} from '@angular/common/http';

if (environment.production) {
  enableProdMode();
}

bootstrapApplication(AppComponent, {
  providers: [
    importProvidersFrom(
      BrowserModule,
      NoteModule,
      UserModule,
      AppRoutingModule,
    ),
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    provideHttpClient(withInterceptorsFromDi()),
  ],
}).catch((err) => console.error(err));

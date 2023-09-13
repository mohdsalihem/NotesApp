import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';

import { ReactiveFormsModule } from '@angular/forms';
import { UserRoutingModule } from './user-routing.module';

@NgModule({
    imports: [CommonModule, UserRoutingModule, ReactiveFormsModule, LoginComponent, SignupComponent],
})
export class UserModule {}

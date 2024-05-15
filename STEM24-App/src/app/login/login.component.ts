import { Component } from '@angular/core';
import { AppMaterialModule } from '../../../app-material.module';
import { FormsModule, NgForm } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AuthService } from '../services/auth/auth-service.service';
import { ErrorHandlerService } from '../services/error-handler/error-handler.service';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    AppMaterialModule,
    FormsModule,
    CommonModule,
    RouterLink,
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {

  constructor(
    private authService: AuthService,
    private errorHandler: ErrorHandlerService,
    private router: Router
  ) {}

  loginForm!: NgForm;

  email: string = '';
  password: string = '';

  login(): void {
    this.authService.login({ email: this.email, password: this.password }).subscribe(
      (response) => {
        this.authService.saveTokens(response);
        this.router.navigate(['/events']);
      },
      (error) => {
        this.errorHandler.handleError(error);
      }
    );
  }
}

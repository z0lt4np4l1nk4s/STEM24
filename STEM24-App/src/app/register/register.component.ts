import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { AppMaterialModule } from '../../../app-material.module';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { RegisterService } from './service/register.service';
import { ErrorHandlerService } from '../services/error-handler/error-handler.service';
import { SnackBarService } from '../services/snack-bar/snack-bar.service';
import { MsgDialogService } from '../services/msg-dialog/msg-dialog.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [
    CommonModule,
    AppMaterialModule,
    FormsModule,
    RouterLink,
  ],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent {

  constructor(
    private registerService: RegisterService,
    private errorHandler: ErrorHandlerService,
    private router: Router,
    private msg: MsgDialogService,
  ) { }

  name: string = '';
  surname: string = '';
  username: string = '';
  email: string = '';
  password: string = '';
  passwordConfirm: string = '';

  register() {
    this.registerService.register({
      name: this.name,
      surname: this.surname,
      username: this.username,
      email: this.email,
      password: this.password,
      passwordConfirm: this.passwordConfirm,
    }).subscribe({
      next: (response) => {
        this.msg.open(
          'Registration successful. Please check your email to confirm your account.',
        );
        this.router.navigate(['/login']);
      },
      error: (error) => {
        this.errorHandler.handleError(error);
      }
    });
  }
}

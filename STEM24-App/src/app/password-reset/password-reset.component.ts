import { Component } from '@angular/core';
import { PasswordResetService } from './service/password-reset.service';
import { ErrorHandlerService } from '../services/error-handler/error-handler.service';
import { SnackBarService } from '../services/snack-bar/snack-bar.service';
import { MsgDialogService } from '../services/msg-dialog/msg-dialog.service';
import { CommonModule } from '@angular/common';
import { AppMaterialModule } from '../../../app-material.module';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-password-reset',
  standalone: true,
  imports: [
    CommonModule,
    AppMaterialModule,
    FormsModule,
    RouterLink,
  ],
  templateUrl: './password-reset.component.html',
  styleUrl: './password-reset.component.scss'
})
export class PasswordResetComponent {
  constructor(
    passwordReset: PasswordResetService,
    errorHandler: ErrorHandlerService,
    snackbar: SnackBarService,
    msg: MsgDialogService,
  ) {}

  resetPassword() {
    // TODO: implement
  }
}

import { Component, OnInit } from '@angular/core';
import { MsgDialogService } from '../services/msg-dialog/msg-dialog.service';
import { PasswordResetService } from '../password-reset/service/password-reset.service';
import { ErrorHandlerService } from '../services/error-handler/error-handler.service';
import { SnackBarService } from '../services/snack-bar/snack-bar.service';
import { EventsService } from '../events/service/events.service';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { AppMaterialModule } from '../../../app-material.module';
import { AuthService } from '../services/auth/auth-service.service';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [
    CommonModule,
    RouterOutlet,
    AppMaterialModule,
  ],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
export class DashboardComponent {
  constructor(
    private authService: AuthService,
  ) {}

  logout() {
    this.authService.logout();
  }

}

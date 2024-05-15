import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { AppMaterialModule } from '../../../app-material.module';
import { FormsModule } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { EventsService } from '../events/service/events.service';
import { ErrorHandlerService } from '../services/error-handler/error-handler.service';
import { MsgDialogService } from '../services/msg-dialog/msg-dialog.service';
import { SnackBarService } from '../services/snack-bar/snack-bar.service';

@Component({
  selector: 'app-upsert-event',
  standalone: true,
  imports: [
    CommonModule,
    AppMaterialModule,
    FormsModule,
  ],
  templateUrl: './upsert-event.component.html',
  styleUrl: './upsert-event.component.scss'
})
export class UpsertEventComponent {
  constructor(
    private eventsService: EventsService,
    private router: Router,
    private errorHandler: ErrorHandlerService,
    private snackbar: SnackBarService,
    private dialog: MatDialog,
    private msg: MsgDialogService
  ) {}
}

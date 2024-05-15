import { Component, OnInit } from '@angular/core';
import { EventsService } from '../dashboard/service/events.service';
import { Router } from '@angular/router';
import { ErrorHandlerService } from '../services/error-handler/error-handler.service';
import { SnackBarService } from '../services/snack-bar/snack-bar.service';
import { MatDialog } from '@angular/material/dialog';
import { MsgDialogService } from '../services/msg-dialog/msg-dialog.service';
import { CommonModule } from '@angular/common';
import { AppMaterialModule } from '../../../app-material.module';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-events',
  standalone: true,
  imports: [
    CommonModule,
    AppMaterialModule,
    FormsModule,
  ],
  templateUrl: './events.component.html',
  styleUrl: './events.component.scss'
})
export class EventsComponent implements OnInit {
  constructor(
    private eventsService: EventsService,
    private router: Router,
    private errorHandler: ErrorHandlerService,
    private snackbar: SnackBarService,
    private dialog: MatDialog,
    private msg: MsgDialogService
  ) { }

  ngOnInit(): void {
      // TODO
  }

  clearEventStatuses() {
    // TODO
  }

  clearSearch() {
    // TODO
  }

  clearDate() {
    // TODO
  }
}

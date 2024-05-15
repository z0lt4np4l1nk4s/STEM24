import { Component, OnInit } from '@angular/core';
import { EventsService } from '../events/service/events.service';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ErrorHandlerService } from '../services/error-handler/error-handler.service';
import { MsgDialogService } from '../services/msg-dialog/msg-dialog.service';
import { SnackBarService } from '../services/snack-bar/snack-bar.service';

@Component({
  selector: 'app-event-details',
  standalone: true,
  imports: [],
  templateUrl: './event-details.component.html',
  styleUrl: './event-details.component.scss'
})
export class EventDetailsComponent implements OnInit {
  constructor(
    private eventsService: EventsService,
    private router: Router,
    private errorHandler: ErrorHandlerService,
    private snackbar: SnackBarService,
    private dialog: MatDialog,
    private msg: MsgDialogService
  ) { }

  ngOnInit(): void {
      
  }
}

import { Component, OnInit } from '@angular/core';
import { EventListItem, EventsService } from '../service/events.service';
import { Router } from '@angular/router';
import { ErrorHandlerService } from '../../services/error-handler/error-handler.service';
import { SnackBarService } from '../../services/snack-bar/snack-bar.service';
import { MatDialog } from '@angular/material/dialog';
import { MsgDialogService } from '../../services/msg-dialog/msg-dialog.service';
import { CommonModule } from '@angular/common';
import { AppMaterialModule } from '../../../../app-material.module';
import { FormsModule } from '@angular/forms';
import { EventCardComponent } from '../../event-card/event-card.component';

@Component({
  selector: 'app-events',
  standalone: true,
  imports: [
    CommonModule,
    AppMaterialModule,
    FormsModule,
    EventCardComponent,
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
  
  // filters
  search: string = '';
  date: string = '';
  todoStatusChecked: boolean = false;
  inProgressStatusChecked: boolean = false;
  doneStatusChecked: boolean = false;

  events: EventListItem[] = [
    {
      id: '1',
      affectedBrand: 'Brand 1',
      name: 'Event 1',
      description: 'Description 1',
      date: '2021-01-01'
    },
    {
      id: '2',
      affectedBrand: 'Brand 2',
      name: 'Event 2',
      description: 'Description 2',
      date: '2021-01-02'
    }
  ];

  ngOnInit(): void {
      // TODO
  }

  clearEventStatuses() {
    this.todoStatusChecked = false;
    this.inProgressStatusChecked = false;
    this.doneStatusChecked = false;
  }

  clearSearch() {
    this.search = '';
  }

  clearDate() {
    this.date = '';
  }

  applyFilters() {
    // TODO
  }
}

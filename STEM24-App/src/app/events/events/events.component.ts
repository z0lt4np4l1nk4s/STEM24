import { AfterViewChecked, AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
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
import { MatPaginator } from '@angular/material/paginator';

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
export class EventsComponent implements OnInit, AfterViewInit {
  constructor(
    private eventsService: EventsService,
    private router: Router,
    private errorHandler: ErrorHandlerService,
    private snackbar: SnackBarService,
    private dialog: MatDialog,
    private msg: MsgDialogService
  ) { }

  @ViewChild(MatPaginator) paginator?: MatPaginator;
  
  // filters
  search: string = '';
  date: string = '';
  todoStatusChecked: boolean = false;
  inProgressStatusChecked: boolean = false;
  doneStatusChecked: boolean = false;

  page: number = 1;
  perPage: number = 10;
  pageSizeOptions: number[] = [10, 20, 50, 100];
  
  ngAfterViewInit(): void {
    this.paginator?.page.subscribe(() => {
      window.scroll(0, 0);
      this.fetchData();
    });
  }

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
    // this.fetchData()
  }

  preProcessFilters() {
    return {
      query: !!this.search ? this.search : undefined,
      date: !!this.date ? this.date : undefined,
    }
  }

  fetchData() {
    const filters = this.preProcessFilters();
    this.eventsService.getEvents(filters, this.page, this.perPage).subscribe({
      next: (data : any) => {
        this.events = data;
      },
      error: (error: any) => {
        this.errorHandler.handleError(error);
      }
    });
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
}

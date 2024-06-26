import { Component, Input, OnInit } from '@angular/core';
import { AppMaterialModule } from '../../../app-material.module';
import { CommonModule } from '@angular/common';
import { EventListItem } from '../events/service/events.service';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-event-card',
  standalone: true,
  imports: [
    AppMaterialModule,
    CommonModule,
    RouterLink,
  ],
  templateUrl: './event-card.component.html',
  styleUrl: './event-card.component.scss'
})
export class EventCardComponent implements OnInit {
  @Input() event!: EventListItem;

  registrationTime: string = '';

  ngOnInit(): void {
    this.registrationTime = ( new Date(this.event.domainRegistrationTime)).toDateString();
  }
}

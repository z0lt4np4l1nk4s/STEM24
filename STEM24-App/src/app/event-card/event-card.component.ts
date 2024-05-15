import { Component, Input, input } from '@angular/core';
import { AppMaterialModule } from '../../../app-material.module';
import { CommonModule } from '@angular/common';
import { EventListItem } from '../events/service/events.service';

@Component({
  selector: 'app-event-card',
  standalone: true,
  imports: [
    AppMaterialModule,
    CommonModule,
  ],
  templateUrl: './event-card.component.html',
  styleUrl: './event-card.component.scss'
})
export class EventCardComponent {
  @Input() event!: EventListItem;
}

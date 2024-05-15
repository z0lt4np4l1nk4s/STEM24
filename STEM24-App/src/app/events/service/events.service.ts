import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EventsService {

  constructor(
    private http: HttpClient,
  ) { }
}

export type EventListItem = {
  id: string;
  affectedBrand: string;
  name: string;
  description: string;
  date: string;
}
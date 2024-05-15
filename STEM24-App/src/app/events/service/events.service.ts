import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EventsService {

  constructor(
    private http: HttpClient,
  ) { }


  getEvents(
    filters: EventListItemfilters,
    page: number,
    perPage: number
  ) {
    let q = {
      ...filters,
      pageNumber: page,
      perPage

    }
    return this.http.get('event', {params: q}).pipe(
      map(response => response)
    );
  }

  getEvent(id: string) {
    return this.http.get(`event/${id}`).pipe(
      map(response => {
        
      })
    );
  }

}

export type EventListItemfilters = {
  query?: string,
  date?: string,
}

export type EventListItem = {
  id: string;
  affectedBrand: string;
  name: string;
  description: string;
  date: string;
}
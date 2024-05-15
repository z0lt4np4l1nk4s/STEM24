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
      ...JSON.parse(JSON.stringify(filters)),
      pageNumber: page,
      perPage

    }
    
    return this.http.get('event', {params: q}).pipe(
      map(response => response)
    );
  }

  getEvent(id: string) {
    return this.http.get(`event/${id}`).pipe(
      map(response => response)
    );
  }

  createEvent(createEvent: CreateEventType) {
    return this.http.post('event', createEvent).pipe(
      map(response => response) 
    )
  }

}

export type CreateEventType = {
  userId: string;
  name: string;
  affectedBrand: string;
  maliciousUrl: string;
  domainRegistrationTime: string;
  keywords: string[];
  dnsRecords: CreateEventDnsRecord[];
}

export type CreateEventDnsRecord = {
  type: string;
  content: string;
  name: string;
}

export type EventListItemfilters = {
  query?: string,
  date?: string,
}

export type EventListItem = {
  id: string;
  userId: string; 
  name: string;
  description: string;
  date: string;
  
  affectedBrand: string;
  maliciousUrl: string;
  domainRegistrationTime: string;
  keywords: string[];
  status: number;
  creationTime: string;
  dnsRecords: DnsRecord[];
  
}

export type DnsRecord = {
  id: string;
  type: string;
  content: string;
  name: string;
}
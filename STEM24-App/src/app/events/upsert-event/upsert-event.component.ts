import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { AppMaterialModule } from '../../../../app-material.module';
import { FormsModule } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { EventsService } from '../service/events.service';
import { ErrorHandlerService } from '../../services/error-handler/error-handler.service';
import { MsgDialogService } from '../../services/msg-dialog/msg-dialog.service';
import { SnackBarService } from '../../services/snack-bar/snack-bar.service';
import { AuthService } from '../../services/auth/auth-service.service';

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
    private authService: AuthService,
    private router: Router,
    private errorHandler: ErrorHandlerService,
    private snackbar: SnackBarService,
    private dialog: MatDialog,
    private msg: MsgDialogService
  ) {}

  // state for everything in the template

  // step 1
  name: string = '';
  affectedBrand: string = '';
  keyword: string = '';
  keywords: string[] = [];
  description: string = '';
  status: string = '';

  // step 2
  maliciousUrl: string = '';
  maliciousDomainRegistrationDate: string = '';

  // record inputs
  aRecords: ARecord[] = [];
  nsRecords: NSRecord[] = [];
  mxRecords: MXRecord[] = [];

  aHost: string = '';
  aIp: string = '';

  nsNameserver: string = '';

  mxMailServer: string = '';
  mxPriority: number = 0;
  
  addARecord() {
    if (this.aHost && this.aIp) {
      this.aRecords = [...this.aRecords, { host: this.aHost, ip: this.aIp }]
      this.aHost = '';
      this.aIp = '';
    }
  }

  addMxRecord() {
    if (this.mxMailServer && this.mxPriority) {
      this.mxRecords = [...this.mxRecords, { mailServer: this.mxMailServer, priority: this.mxPriority }]
      this.mxMailServer = '';
      this.mxPriority = 0;
    }
  }

  addNsRecord() {
    if (this.nsNameserver) {
      this.nsRecords = [...this.nsRecords, { nameserver: this.nsNameserver }]
      this.nsNameserver = '';
    }
  }

  addKeyword() {
    if (this.keyword) {
      this.keywords.push(this.keyword);
      this.keyword = '';
    }
  }
  removeKeyword(index: number) {
    this.keywords.splice(index, 1);
  }

  onSubmit() {
    // const ADnsRecords = this.aRecords.map(record => ({
    //   type: 'A',
    //   name: ''
    // }))
    // const data: CreateEventType = {
    //   userId: this.authService.getUserId(),
    //   name: this.name,
    //   affectedBrand: this.affectedBrand,
    //   maliciousUrl: this.maliciousUrl,
    //   domainRegistrationTime: this.maliciousDomainRegistrationDate,
    //   keywords: this.keywords,
    //   2

    // }
    // this.eventsService.createEvent(event: )
  }

}

export type ARecord = {
  host: string;
  ip: string;
}

export type NSRecord = {
  nameserver: string;
}

export type MXRecord = {
  mailServer: string;
  priority: number;
}

import { Injectable } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MsgDialogTemplateComponent } from '../../ui/msg-dialog-template/msg-dialog-template.component';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MsgDialogService {
  public dialogRef!: MatDialogRef<MsgDialogTemplateComponent>;

  constructor(
    private dialog: MatDialog,
  ) { }

  open(text: string | string[], autoClose: number = 0): Observable<boolean> {
    this.dialogRef = this.dialog.open(MsgDialogTemplateComponent, {
      width: '400px',
      data: {
        text: text,
        autoClose: autoClose,
      },
    });
    return this.dialogRef.afterClosed();
  }

  close() {
    this.dialogRef.close();
  }
}

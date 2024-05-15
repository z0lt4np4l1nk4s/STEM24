import { Injectable } from '@angular/core';
import { MsgDialogService } from '../msg-dialog/msg-dialog.service';
import { HttpErrorResponse } from '@angular/common/http';
import { SnackBarService } from '../snack-bar/snack-bar.service';

@Injectable({
  providedIn: 'root'
})
export class ErrorHandlerService implements ErrorHandlerService {

  constructor(
    private msgDialog: MsgDialogService,
    private snackBar: SnackBarService,
  ) { }

  handleError(error: HttpErrorResponse) {
    console.error(error);
    this.snackBar.dismiss();
    let errorMsg = [ 'Sorry! Error occurred.', error.status + ': ' + error.statusText ];
    if(error.error && error.error.error && typeof error.error.error == 'string') {
      errorMsg.push(error.error.error);
    }
    else if(error.error && error.error.errors) {
      for (const [key, value] of Object.entries(error.error.errors)) {
        errorMsg.push('' + value);
      }
    }
    else if(error.error && typeof error.error == 'string') {
      errorMsg.push(error.error);
    }
    this.msgDialog.open(errorMsg);
  }
}
import { Injectable } from '@angular/core';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';
import { SnackBarComponent } from '../../ui/snack-bar/snack-bar.component';

@Injectable({
  providedIn: 'root'
})
export class SnackBarService {

  constructor(public matSnackBar: MatSnackBar) { }

  open(text: string, config: MatSnackBarConfig = {}) {
    config.data = {
      text: text,
    };
    this.matSnackBar.openFromComponent(SnackBarComponent, config);
  }

  dismiss() {
    this.matSnackBar.dismiss();
  }
}

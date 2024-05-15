import { CommonModule } from '@angular/common';
import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { AppMaterialModule } from '../../../../app-material.module';

@Component({
  selector: 'app-msg-dialog-template',
  standalone: true,
  imports: [
    CommonModule,
    AppMaterialModule
  ],
  templateUrl: './msg-dialog-template.component.html',
  styleUrl: './msg-dialog-template.component.scss'
})
export class MsgDialogTemplateComponent {
  text: string[] = [];
  countdownInterval!: ReturnType<typeof setInterval>;

  constructor(
    public dialogRef: MatDialogRef<MsgDialogTemplateComponent>,
    @Inject(MAT_DIALOG_DATA) public data: {
      text: string | string[],
      autoClose: number,
    },
  ) { }

  ngOnInit() {
    if(typeof this.data.text == 'string') {
      this.text = [ this.data.text ];
    }
    else {
      this.text = this.data.text;
    }
    if(this.data.autoClose) {
      this.countdownInterval = setInterval(() => {
        this.data.autoClose--;
        if(this.data.autoClose == 0) {
          this.clearInterval();
          this.dialogRef.close(true);
        }
      }, 1000);
    }
  }
  ngOnDestroy(): void {
    this.clearInterval();
  }

  clearInterval() {
    if(this.countdownInterval) {
      clearInterval(this.countdownInterval);
    }
  }

  confirm() {
    this.clearInterval();
    this.dialogRef.close(true);
  }
}

import { CommonModule } from '@angular/common';
import { Component, Inject } from '@angular/core';
import { MAT_SNACK_BAR_DATA, MatSnackBar } from '@angular/material/snack-bar';
import { AppMaterialModule } from '../../../../app-material.module';

@Component({
  selector: 'app-snack-bar',
  standalone: true,
  imports: [
    CommonModule,
    AppMaterialModule,
  ],
  templateUrl: './snack-bar.component.html',
  styleUrl: './snack-bar.component.scss'
})
export class SnackBarComponent {
  constructor(
    public matSnackBar: MatSnackBar,
    @Inject(MAT_SNACK_BAR_DATA) public data: { text: string },
  ) { }

  ngOnInit(): void {}

  dismiss() {
    this.matSnackBar.dismiss();
  }
}

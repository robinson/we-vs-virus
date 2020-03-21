import { Component, Inject } from '@angular/core';
import { MAT_SNACK_BAR_DATA } from '@angular/material/snack-bar';

@Component({
  selector: 'app-alert-snackbar',
  templateUrl: './alert-snackbar.component.html',
  styleUrls: ['./alert-snackbar.component.css']
})
export class AlertSnackBarComponent {

  constructor(@Inject(MAT_SNACK_BAR_DATA) public data: MatSnackBarData) {
  }
}

export interface MatSnackBarData {
  title: string;
  message: string;
  type: string;
}

import { Component, OnInit, Inject } from '@angular/core';
import { MatBottomSheetRef, MAT_BOTTOM_SHEET_DATA } from '@angular/material/bottom-sheet';
import { BottomSheetDialogData } from '../../models/bottom-sheet-dialog-data.model';

@Component({
  selector: 'app-bottom-sheet-information-dialog',
  templateUrl: './bottom-sheet-information-dialog.component.html',
  styleUrls: ['./bottom-sheet-information-dialog.component.css']
})
export class BottomSheetInformationDialogComponent implements OnInit {

  constructor(protected bottomSheetRef: MatBottomSheetRef<BottomSheetInformationDialogComponent>,
    @Inject(MAT_BOTTOM_SHEET_DATA) public data: BottomSheetDialogData) {
    data.acceptText = data.acceptText ? data.acceptText : 'OK';
  }

  close(event: any): void {
    this.bottomSheetRef.dismiss();
    event.preventDefault();
  }

  ngOnInit() {
  }
}

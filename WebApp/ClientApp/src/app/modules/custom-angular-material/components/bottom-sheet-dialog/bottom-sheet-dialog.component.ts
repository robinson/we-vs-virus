import { Component, OnInit, Inject } from '@angular/core';
import { MatBottomSheetRef, MAT_BOTTOM_SHEET_DATA } from '@angular/material/bottom-sheet';
import { BottomSheetDialogData } from '../../models/bottom-sheet-dialog-data.model';

@Component({
  selector: 'app-bottom-sheet-dialog',
  templateUrl: './bottom-sheet-dialog.component.html',
  styleUrls: ['./bottom-sheet-dialog.component.css']
})
export class BottomSheetDialogComponent implements OnInit {

  constructor(protected bottomSheetRef: MatBottomSheetRef<BottomSheetDialogComponent>,
    @Inject(MAT_BOTTOM_SHEET_DATA) public data: BottomSheetDialogData) {
    data.acceptText = data.acceptText ? data.acceptText : 'OK';
    data.declineText = data.declineText ? data.declineText : 'ABBRECHEN';
  }

  close(event: any, isAccepted: boolean): void {
    if (isAccepted && this.data.acceptCallback) {
      this.data.acceptCallback();
    } else if (!isAccepted && this.data.declineCallback) {
      this.data.declineCallback();
    }
    this.bottomSheetRef.dismiss(isAccepted);
    event.preventDefault();
  }

  ngOnInit() {
  }
}

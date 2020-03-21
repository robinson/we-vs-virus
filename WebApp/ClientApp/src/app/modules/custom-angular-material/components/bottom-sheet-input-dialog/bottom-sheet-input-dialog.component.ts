import { Component, Inject } from '@angular/core';
import { MatBottomSheetRef, MAT_BOTTOM_SHEET_DATA } from '@angular/material/bottom-sheet';
import { BottomSheetDialogComponent } from '../bottom-sheet-dialog/bottom-sheet-dialog.component';
import { BottomSheetDialogData } from '../../models/bottom-sheet-dialog-data.model';

@Component({
  selector: 'app-bottom-sheet-input-dialog',
  templateUrl: './bottom-sheet-input-dialog.component.html',
  styleUrls: ['./bottom-sheet-input-dialog.component.css']
})
export class BottomSheetInputDialogComponent extends BottomSheetDialogComponent {

  constructor(protected bottomSheetRef: MatBottomSheetRef<BottomSheetInputDialogComponent>,
    @Inject(MAT_BOTTOM_SHEET_DATA) public data: BottomSheetDialogData) {
    super(bottomSheetRef, data);
  }

  close(event: any, isAccepted: boolean): void {
    if (isAccepted) {
      const inputValue = this.data.inputFieldValue;
      if (inputValue) {
        this.bottomSheetRef.dismiss(this.data.inputFieldValue);
      }
    } else {
      this.bottomSheetRef.dismiss();
    }
    event.preventDefault();
  }
}

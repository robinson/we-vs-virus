/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { BottomSheetDialogComponent } from './bottom-sheet-dialog.component';

describe('BottomSheetDialogComponent', () => {
  let component: BottomSheetDialogComponent;
  let fixture: ComponentFixture<BottomSheetDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BottomSheetDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BottomSheetDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

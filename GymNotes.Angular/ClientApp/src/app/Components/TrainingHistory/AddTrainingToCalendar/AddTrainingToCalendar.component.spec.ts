/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from "@angular/core/testing";
import { By } from "@angular/platform-browser";
import { DebugElement } from "@angular/core";

import { AddTrainingToCalendarComponent } from "./AddTrainingToCalendar.component";

describe("AddTrainingToCalendarComponent", () => {
  let component: AddTrainingToCalendarComponent;
  let fixture: ComponentFixture<AddTrainingToCalendarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [AddTrainingToCalendarComponent],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddTrainingToCalendarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});

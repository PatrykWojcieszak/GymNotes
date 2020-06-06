/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { WilksComponent } from './Wilks.component';

describe('WilksComponent', () => {
  let component: WilksComponent;
  let fixture: ComponentFixture<WilksComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WilksComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WilksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

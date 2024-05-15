import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpsertEventComponent } from './upsert-event.component';

describe('UpsertEventComponent', () => {
  let component: UpsertEventComponent;
  let fixture: ComponentFixture<UpsertEventComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UpsertEventComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UpsertEventComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

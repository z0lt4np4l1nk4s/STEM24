import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MsgDialogTemplateComponent } from './msg-dialog-template.component';

describe('MsgDialogTemplateComponent', () => {
  let component: MsgDialogTemplateComponent;
  let fixture: ComponentFixture<MsgDialogTemplateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MsgDialogTemplateComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MsgDialogTemplateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

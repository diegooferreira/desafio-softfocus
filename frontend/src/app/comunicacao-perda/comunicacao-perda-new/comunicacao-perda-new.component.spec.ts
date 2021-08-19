import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComunicacaoPerdaNewComponent } from './comunicacao-perda-new.component';

describe('ComunicacaoPerdaNewComponent', () => {
  let component: ComunicacaoPerdaNewComponent;
  let fixture: ComponentFixture<ComunicacaoPerdaNewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ComunicacaoPerdaNewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ComunicacaoPerdaNewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

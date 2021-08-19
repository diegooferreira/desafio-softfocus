import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComunicacaoPerdaEditComponent } from './comunicacao-perda-edit.component';

describe('ComunicacaoPerdaEditComponent', () => {
  let component: ComunicacaoPerdaEditComponent;
  let fixture: ComponentFixture<ComunicacaoPerdaEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ComunicacaoPerdaEditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ComunicacaoPerdaEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

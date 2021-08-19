import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComunicacaoPerdaViewComponent } from './comunicacao-perda-view.component';

describe('ComunicacaoPerdaViewComponent', () => {
  let component: ComunicacaoPerdaViewComponent;
  let fixture: ComponentFixture<ComunicacaoPerdaViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ComunicacaoPerdaViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ComunicacaoPerdaViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ComunicacaoPerdaListComponent } from './comunicacao-perda-list.component';

describe('ComunicacaoPerdaListComponent', () => {
  let component: ComunicacaoPerdaListComponent;
  let fixture: ComponentFixture<ComunicacaoPerdaListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ComunicacaoPerdaListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ComunicacaoPerdaListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

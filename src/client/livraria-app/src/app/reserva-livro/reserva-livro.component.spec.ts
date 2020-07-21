import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReservaLivroComponent } from './reserva-livro.component';

describe('ReservaLivroComponent', () => {
  let component: ReservaLivroComponent;
  let fixture: ComponentFixture<ReservaLivroComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReservaLivroComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReservaLivroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

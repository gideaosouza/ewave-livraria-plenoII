import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmprestimoLivroComponent } from './emprestimo-livro.component';

describe('EmprestimoLivroComponent', () => {
  let component: EmprestimoLivroComponent;
  let fixture: ComponentFixture<EmprestimoLivroComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmprestimoLivroComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmprestimoLivroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

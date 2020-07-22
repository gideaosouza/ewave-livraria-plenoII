import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InstituicaoEnsinoComponent } from './instituicao-ensino.component';

describe('InstituicaoEnsinoComponent', () => {
  let component: InstituicaoEnsinoComponent;
  let fixture: ComponentFixture<InstituicaoEnsinoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InstituicaoEnsinoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InstituicaoEnsinoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

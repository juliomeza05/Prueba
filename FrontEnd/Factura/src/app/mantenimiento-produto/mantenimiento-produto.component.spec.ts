import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MantenimientoProdutoComponent } from './mantenimiento-produto.component';

describe('MantenimientoProdutoComponent', () => {
  let component: MantenimientoProdutoComponent;
  let fixture: ComponentFixture<MantenimientoProdutoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MantenimientoProdutoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MantenimientoProdutoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

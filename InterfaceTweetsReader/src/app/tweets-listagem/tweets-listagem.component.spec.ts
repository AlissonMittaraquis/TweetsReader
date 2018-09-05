import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TweetsListagemComponent } from './tweets-listagem.component';

describe('TweetsListagemComponent', () => {
  let component: TweetsListagemComponent;
  let fixture: ComponentFixture<TweetsListagemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TweetsListagemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TweetsListagemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

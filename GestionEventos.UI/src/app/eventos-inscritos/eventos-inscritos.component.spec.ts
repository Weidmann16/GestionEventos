import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventosInscritosComponent } from './eventos-inscritos.component';

describe('EventosInscritosComponent', () => {
  let component: EventosInscritosComponent;
  let fixture: ComponentFixture<EventosInscritosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EventosInscritosComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EventosInscritosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

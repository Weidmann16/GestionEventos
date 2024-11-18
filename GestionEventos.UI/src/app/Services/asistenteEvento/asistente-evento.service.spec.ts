import { TestBed } from '@angular/core/testing';

import { AsistenteEventoService } from './asistente-evento.service';

describe('AsistenteEventoService', () => {
  let service: AsistenteEventoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AsistenteEventoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

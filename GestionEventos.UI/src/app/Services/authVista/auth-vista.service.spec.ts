import { TestBed } from '@angular/core/testing';

import { AuthVistaService } from './auth-vista.service';

describe('AuthVistaService', () => {
  let service: AuthVistaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AuthVistaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

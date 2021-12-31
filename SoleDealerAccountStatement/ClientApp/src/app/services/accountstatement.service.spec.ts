import { TestBed } from '@angular/core/testing';

import { AccountstatementService } from './accountstatement.service';

describe('AccountstatementService', () => {
  let service: AccountstatementService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AccountstatementService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

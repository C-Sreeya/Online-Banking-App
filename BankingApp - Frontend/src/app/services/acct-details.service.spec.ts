import { TestBed } from '@angular/core/testing';

import { AcctDetailsService } from './acct-details.service';

describe('AcctDetailsService', () => {
  let service: AcctDetailsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AcctDetailsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

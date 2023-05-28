import { TestBed } from '@angular/core/testing';

import { RepairRequestService } from './repair-request.service';

describe('RepairRequestService', () => {
  let service: RepairRequestService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RepairRequestService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

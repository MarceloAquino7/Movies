import { TestBed, inject } from '@angular/core/testing';
import { HttpService } from '@services/http/http.service';
import { HttpClientModule } from '@angular/common/http';
import { ToastyModule } from 'ng2-toasty';

describe('HttpService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule, ToastyModule],
      providers: [HttpService]
    });
  });

  it('should be created', inject([HttpService], (service: HttpService) => {
    expect(service).toBeTruthy();
  }));
});

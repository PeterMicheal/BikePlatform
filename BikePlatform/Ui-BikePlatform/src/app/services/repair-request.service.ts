import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { RepairRequestModel } from '../models/repairRequest.model';
import { ApiResult } from './contracts/apiResult.model';
import { createRepairRequestResponse } from './contracts/createRepairRequestResponse';

@Injectable({
  providedIn: 'root'
})
export class RepairRequestService {

  private apiUrl
  constructor(private httpClient: HttpClient) {
    this.apiUrl = environment.apiUrl
  }

  public createRepairRequest(repairRequest: RepairRequestModel): Observable<ApiResult<createRepairRequestResponse>>{
    return this.httpClient.post<ApiResult<createRepairRequestResponse>>(`${this.apiUrl}/bikeRepair`, repairRequest)
  }
}

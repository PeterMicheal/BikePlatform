import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { RepairRequestModel } from '../models/repairRequest.model';
import { RepairRequestService } from '../services/repair-request.service';

@Component({
  selector: 'app-repair-request',
  templateUrl: './repair-request.component.html',
  styleUrls: ['./repair-request.component.scss']
})
export class RepairRequestComponent implements OnInit {

  public newRepairRequest: RepairRequestModel = {
    id: undefined,
    name: undefined,
    email: undefined,
    description: undefined,
  }

  constructor(private repairRequestService: RepairRequestService) { }

  ngOnInit(): void {
  }

  public createRepairRequest(form: NgForm): void{
    if(form.invalid || !this.newRepairRequest ){
      alert('From is not valid');
    }else{
      this.repairRequestService.createRepairRequest(this.newRepairRequest)
        .subscribe(createRequestResult => {
          console.log('New Repair Request created with id ' + createRequestResult.data.requestId);
        },
        error => console.log('Error' +  error.message))
    }
  }

}

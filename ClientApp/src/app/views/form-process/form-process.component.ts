import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Process } from 'src/app/shared/model/Process/Process';
import { ProcessService } from 'src/app/shared/services/process.service';

@Component({
  selector: 'app-form-process',
  templateUrl: './form-process.component.html',
  styleUrls: ['./form-process.component.css']
})
export class FormProcessComponent implements OnInit {
  public processForm: FormGroup;

  private processGetByIdSubscription: Subscription = null;
  private processInsertSubscription: Subscription = null;
  private processUpdateSubscription: Subscription = null;

  public edit: boolean;

  public process: Process;

  constructor(
    public formBuilder: FormBuilder,
    public processService: ProcessService,
    public router: Router,
    protected route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.processForm = this.formBuilder.group({
      active: [null, Validators.required],
      processNumber : [null, Validators.required],
      state: [null, [Validators.required, Validators.maxLength(2)]],
      monetaryValue: [null, Validators.required],
      startDate : [null, Validators.required],
      clientId: [null, Validators.required],
      processState: [null, [Validators.required, Validators.maxLength(2)]],
    });

    console.log("route", this.router.url);

    // if (this.router.url === '') {
    //   this.edit = false;
    // } else {
    //   this.edit = true;

    //   const param = this.route.snapshot.paramMap.get('id').split('-');

    //   const processId: any = param[0];

    //   if (this.processGetByIdSubscription) {
    //     this.processGetByIdSubscription.unsubscribe();
    //     this.processGetByIdSubscription = null;
    //   }

    //   this.processGetByIdSubscription = this.processService.getProcessById(processId).subscribe(process => {
    //     this.process = process;

    //     this.processForm.controls['active'].setValue(process.active);
    //     this.processForm.controls['processNumber'].setValue(process.processNumber);
    //     this.processForm.controls['state'].setValue(process.state);
    //     this.processForm.controls['monetaryValue'].setValue(process.monetaryValue);
    //     this.processForm.controls['startDate'].setValue(process.startDate);
    //     this.processForm.controls['clientId'].setValue(process.clientId);this.processForm.controls['processState'].setValue(process.processState);
    //   })
    // }
  }

  public insertProcess() {
    this.process.id = 0;
    // this.process.active = this.processForm.get('active')?.value;
    // this.process.processNumber = this.processForm.get('processNumber')?.value;
    // this.process.state = this.processForm.get('state')?.value;
    // this.process.monetaryValue = this.processForm.get('monetaryValue')?.value;
    // this.process.startDate = this.processForm.get('startDate')?.value;
    // this.process.clientId = this.processForm.get('clientId')?.value;
    // this.process.processState = this.processForm.get('processState')?.value;

    if (this.processInsertSubscription) {
      this.processInsertSubscription.unsubscribe();
      this.processInsertSubscription = null;
    }

    this.processInsertSubscription = this.processService.insert(this.process).subscribe(response => {
      //implements sweetAlert
      this.router.navigate([]);
    },
    error => {
      //implements sweetAlert
    },
    () => {
      this.router.navigate([]);
    })
  }

  public update() {
    // this.process.active = this.processForm.get('active')?.value;
    // this.process.processNumber = this.processForm.get('processNumber')?.value;
    // this.process.state = this.processForm.get('state')?.value;
    // this.process.monetaryValue = this.processForm.get('monetaryValue')?.value;
    // this.process.startDate = this.processForm.get('startDate')?.value;
    // this.process.clientId = this.processForm.get('clientId')?.value;
    // this.process.processState = this.processForm.get('processState')?.value;

    if (this.processUpdateSubscription) {
      this.processUpdateSubscription.unsubscribe();
      this.processUpdateSubscription = null;
    }

    this.processUpdateSubscription = this.processService.update(this.process).subscribe(response => {
      //implements sweetAlert
      this.router.navigate([]);
    }),
    error => {
      //implements sweetAlert
    },
    () => {
      this.router.navigate([]);
    }
  }

  public saveProcess() {
    if(this.edit) {
      this.update();
    } else {
      this.insertProcess();
    }
  }

  public validFields(field: string) {
    // return this.processForm.get(field)?.errors && (this.processForm.get(field)?.dirty || this.processForm.get(field)?.touched);
  }

  ngOnDestroy(): void {
    if (this.processGetByIdSubscription) {
      this.processGetByIdSubscription.unsubscribe();
    }
    if (this.processInsertSubscription) {
      this.processInsertSubscription.unsubscribe();
    }
  }
}

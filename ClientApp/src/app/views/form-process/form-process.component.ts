import { SweetAlert } from './../../shared/SweetAlert';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Process } from 'src/app/shared/model/Process/Process';
import { ProcessService } from 'src/app/shared/services/Process/process.service';
import { Client } from 'src/app/shared/model/Client/Client';
import { ClientService } from 'src/app/shared/services/Client/client.service';


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

  public process: Process = new Process();

  public clients: Client[];
  public clientId: number;

  public showModalClient: boolean = false;

  constructor(
    public formBuilder: FormBuilder,
    public processService: ProcessService,
    public router: Router,
    protected route: ActivatedRoute,
    public sweetAlert: SweetAlert,
    public clientService: ClientService
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

    this.getAllClients();

    if (this.router.url === '/newProcess') {
      this.edit = false;
    } else {
      this.edit = true;

      const param = this.route.snapshot.paramMap.get('id');

      console.log("param", param)
      const processId: any = param;

      if (this.processGetByIdSubscription) {
        this.processGetByIdSubscription.unsubscribe();
        this.processGetByIdSubscription = null;
      }

      this.processGetByIdSubscription = this.processService.getProcessById(processId).subscribe(process => {
        this.process = process;

        this.processForm.controls['active'].setValue(process.active);
        this.processForm.controls['processNumber'].setValue(process.processNumber);
        this.processForm.controls['state'].setValue(process.state);
        this.processForm.controls['monetaryValue'].setValue(process.monetaryValue);
        this.processForm.controls['startDate'].setValue(process.startDate.toString().slice(0, process.startDate.toString().indexOf('T')));
        this.processForm.controls['clientId'].setValue(process.clientId);
        this.clientId = process.clientId;
      })
    }
  }

  public getAllClients() {
    this.clientService.getAllClient().subscribe(response => {
      this.clients = response;
    })
  }

  public insertProcess() {
    console.log("process", this.process)
    this.process.id = 0;
    this.process.active = this.processForm.get('active').value;
    this.process.processNumber = this.processForm.get('processNumber').value;
    this.process.state = this.processForm.get('state').value;
    this.process.monetaryValue = this.processForm.get('monetaryValue').value;
    this.process.startDate = this.processForm.get('startDate').value;
    this.process.clientId = this.processForm.get('clientId').value;

    if (this.processInsertSubscription) {
      this.processInsertSubscription.unsubscribe();
      this.processInsertSubscription = null;
    }

    this.processInsertSubscription = this.processService.insert(this.process).subscribe(response => {
      this.sweetAlert.ShowAlert("Sucesso!", "O processo foi criado com sucesso!", "success");
      this.router.navigate(["/home"]);
    },
    error => {
      this.sweetAlert.ShowAlert("Erro!", "O processo não foi criado, por gentileza tente novamente!", "error");
    },
    () => {
      this.router.navigate([]);
    })
  }

  public update() {
    this.process.active = this.processForm.get('active').value;
    this.process.processNumber = this.processForm.get('processNumber').value;
    this.process.state = this.processForm.get('state').value;
    this.process.monetaryValue = this.processForm.get('monetaryValue').value;
    this.process.startDate = this.processForm.get('startDate').value;
    this.process.clientId = this.processForm.get('clientId').value;

    if (this.processUpdateSubscription) {
      this.processUpdateSubscription.unsubscribe();
      this.processUpdateSubscription = null;
    }

    this.processUpdateSubscription = this.processService.update(this.process).subscribe(response => {
      this.sweetAlert.ShowAlert("Sucesso!", "O processo foi atualizado com sucesso!", "success");
      this.router.navigate(['/home']);
    }),
    error => {
      this.sweetAlert.ShowAlert("Erro!", "O processo não foi atualizado, por gentileza tente novamente!", "error");
    },
    () => {
      this.router.navigate(['/home']);
    }
  }

  public saveProcess() {
    console.log("process", this.processForm.invalid)
    // if(this.edit) {
    //   this.update();
    // } else {
    //   this.insertProcess();
    // }
  }

  public validFields(field: string) {
    if(this.processForm.get(field)) {
      return this.processForm.get(field).errors && (this.processForm.get(field).dirty || this.processForm.get(field).touched);
    }
  }

  public goToHome() {
    this.router.navigate(['']);
  }

  public showModal() {
    console.log("teste", this.showModalClient)
    this.showModalClient = !this.showModalClient;
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

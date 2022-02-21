import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material';
import { Subscription } from 'rxjs';
import { Client } from '../model/Client/Client';
import { ClientService } from '../services/Client/client.service';
import { SweetAlert } from '../SweetAlert';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent implements OnInit {
  public clientForm: FormGroup;

  private clientInsertSubscription: Subscription = null;

  public client: Client = new Client();

  constructor(
    public dialogRef: MatDialogRef<ModalComponent>,
    public formBuilder: FormBuilder,
    public clientService: ClientService,
    public sweetAlert: SweetAlert
  ) { }

  ngOnInit() {
    this.clientForm = this.formBuilder.group({
      name: [null, Validators.required],
      cnpj: [null, [Validators.required, Validators.maxLength(14), Validators.pattern('([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})')]],
      state: [null, Validators.required]
    })
  }

  public closeModal() {
    this.dialogRef.close();
  }

  public validFields(field: string) {
    if(this.clientForm.get(field)) {
      return this.clientForm.get(field).errors && (this.clientForm.get(field).dirty || this.clientForm.get(field).touched);
    }
  }


  public insertClient() {
    console.log("for.", this.clientForm.valid)
    this.client.id = 0;
    this.client.name = this.clientForm.get('name').value;
    this.client.cnpj = `${this.clientForm.get('cnpj').value}`;
    this.client.state = this.clientForm.get('state').value;

    if (this.clientInsertSubscription) {
      this.clientInsertSubscription.unsubscribe();
      this.clientInsertSubscription = null;
    }

    this.clientInsertSubscription = this.clientService.insert(this.client).subscribe(response => {
      this.sweetAlert.ShowAlert("Sucesso!", "O cliente foi criado com sucesso!", "success");
      this.dialogRef.close();
    },
    error => {
      this.sweetAlert.ShowAlert("Erro!", "O cliente não foi criado, por gentileza tente novamente!", "error");
    })
  }
}

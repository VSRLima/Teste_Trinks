import { Component, OnInit } from '@angular/core';
import { Process } from 'src/app/shared/model/Process/Process';

import {MatTableDataSource} from '@angular/material/table';
import { Router } from '@angular/router';
import { ProcessService } from 'src/app/shared/services/Process/process.service';
import { SweetAlert } from 'src/app/shared/SweetAlert';
import { ClientService } from 'src/app/shared/services/Client/client.service';
import { Client } from 'src/app/shared/model/Client/Client';
import { ProcessWithNameClient } from 'src/app/shared/model/Process/ProcessWithNameClient';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  displayedColumns: string[] = ['active', 'processNumber', 'state', 'monetaryValue', 'startDate', 'clientName', 'edit'];
  dataSource: ProcessWithNameClient[];
  saveAll: ProcessWithNameClient[];

  loadingCard: boolean = false;

  clients: Client[];
  clientId: number;

  state: string;

  constructor(
    private processService: ProcessService,
    private router: Router,
    public sweetAlert: SweetAlert,
    private clientService: ClientService
  ) {

  }

  ngOnInit(): void {
    this.getAllProcess();
    this.getAllClients();
  }

  public getAllProcess():void {
    this.processService.getAllProcess().subscribe((el: ProcessWithNameClient[]) => {
      this.dataSource = el;
      this.saveAll = el;
    });
  }

  public getAllClients() {
    this.clientService.getAllClient().subscribe(el => {
      this.clients = el;
    })
  }

  public sumAllActiveProcess() {
    this.loadingCard = true;
    this.processService.sumAllActiveProcess().subscribe(el => {
      this.loadingCard = false;
      this.sweetAlert.ShowAlert("Sucesso!", `O valor dos processos ativos é: R$${el}`, "success");
    },
    error => {
      this.loadingCard = false;
      this.sweetAlert.ShowAlert("Erro!", "Não foi possível somar o valor dos processos ativos", "error");
    })
  }

  public calcAverage() {
    console.log("state", this.state);
    console.log("clientId", this.clientId);
  }

  public goToEdit(processId: number) {
    this.router.navigate([`/editProcess/${processId}`])
  }

  public applyFilter(event: Event, field: string) {
    const filterValue = (event.target as HTMLInputElement).value;

    if(filterValue.length >= 2) {
      switch (field) {
        case "processNumber":
          this.dataSource = this.dataSource.filter((s) => s.processNumber.toLowerCase().indexOf(filterValue.toLowerCase()) !== -1);
          break;

        case "monetaryValue":
          this.dataSource = this.dataSource.filter((s) => s.monetaryValue.toString().indexOf(filterValue.toLowerCase()) !== -1);
          break;

        case "state":
          this.dataSource = this.dataSource.filter((s) => s.state.indexOf(filterValue.toUpperCase()) !== -1);
          break;

        case "clientName":
          this.dataSource = this.dataSource.filter((s) => s.clientName.toLowerCase().indexOf(filterValue.toLowerCase()) !== -1);
          break;

        case "startDate":
          this.dataSource = this.dataSource.filter((s) => s.startDate.toString().indexOf(filterValue.toLowerCase()) !== -1);
          break;

        default:
          this.dataSource = this.saveAll;
          break;
      }

    } else {
      this.dataSource = this.saveAll;
    }
  }
}

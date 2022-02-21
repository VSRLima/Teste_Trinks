import { Component, OnInit } from '@angular/core';
import { Process } from 'src/app/shared/model/Process/Process';

import {MatTableDataSource} from '@angular/material/table';
import { Router } from '@angular/router';
import { ProcessService } from 'src/app/shared/services/Process/process.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  displayedColumns: string[] = ['active', 'processNumber', 'state', 'monetaryValue', 'startDate', 'clientName', 'edit'];
  dataSource: Process[];
  saveAll: Process[]

  constructor(
    private processService: ProcessService,
    private router: Router
  ) {

  }

  ngOnInit(): void {
    this.getAllProcess();
  }

  public getAllProcess():void {
    this.processService.getAllProcess().subscribe((el: Process[]) => {
      this.dataSource = el;
      this.saveAll = el;
      console.log("data source", this.dataSource);
    });
  }

  public goToEdit(processId: number) {
    console.log("processId",processId);
    this.router.navigate([`/editProcess/${processId}`])
  }

  public applyFilter(event: Event, field: string) {
    const filterValue = (event.target as HTMLInputElement).value;

    if(filterValue.length > 3) {
      switch (field) {
        case "processNumber":
          this.dataSource = this.dataSource.filter((s) => s.processNumber.toLowerCase().indexOf(filterValue.toLowerCase()) !== -1);
          break;

        case "monetaryValue":
          this.dataSource = this.dataSource.filter((s) => s.monetaryValue.toString().indexOf(filterValue.toLowerCase()) !== -1);
          break;

        case "state":
          this.dataSource = this.dataSource.filter((s) => s.state.indexOf(filterValue.toLowerCase()) !== -1);
          break;

        case "clientName":
          this.dataSource = this.dataSource.filter((s) => s.clientName.indexOf(filterValue.toLowerCase()) !== -1);
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

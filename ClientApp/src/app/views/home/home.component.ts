import { Component, OnInit } from '@angular/core';
import { Process } from 'src/app/shared/model/Process/Process';
import { ProcessService } from 'src/app/shared/services/process.service';
import * as moment from "../../../../node_modules/moment";

export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  {position: 1, name: 'Hydrogen', weight: 1.0079, symbol: 'H'},
  {position: 2, name: 'Helium', weight: 4.0026, symbol: 'He'},
  {position: 3, name: 'Lithium', weight: 6.941, symbol: 'Li'},
  {position: 4, name: 'Beryllium', weight: 9.0122, symbol: 'Be'},
  {position: 5, name: 'Boron', weight: 10.811, symbol: 'B'},
  {position: 6, name: 'Carbon', weight: 12.0107, symbol: 'C'},
  {position: 7, name: 'Nitrogen', weight: 14.0067, symbol: 'N'},
  {position: 8, name: 'Oxygen', weight: 15.9994, symbol: 'O'},
  {position: 9, name: 'Fluorine', weight: 18.9984, symbol: 'F'},
  {position: 10, name: 'Neon', weight: 20.1797, symbol: 'Ne'},
];

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  dateTime = new Date();
  renderCal: boolean = false;
  displayedColumns: string[] = ['position', 'name', 'weight', 'symbol'];
  dataSource = ELEMENT_DATA;

  constructor(
    private processService: ProcessService
  ) {}

  ngOnInit(): void {
    console.log("aq")
    // this.getAllProcess();
  }

  // private getAllProcess(): void {
  //   this.processService.getAllProcess().subscribe((el: Process[]) => {
  //     this.dataSource = el;
  //   });
  // }

  dateVerify() {
    if(moment().format('YYYY/MM/DD') == moment(this.dateTime).format('YYYY/MM/DD')) {

    }
  }

  dateFromCalendar(date) {
    this.dateTime = date.value;
  }

  renderCalendar(): void {
    this.renderCal = !this.renderCal;
  }
}

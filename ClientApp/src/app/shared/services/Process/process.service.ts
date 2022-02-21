import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Process } from '../../model/Process/Process';


@Injectable({
  providedIn: 'root'
})
export class ProcessService {

  constructor(
    private http: HttpClient
  ) { }

  public getAllProcess(): Observable<Process[]> {
    return this.http.get<Process[]>(`${environment.baseAPI}/api/process/GetAllProcess`);
  }

  public getProcessById(processId: number): Observable<Process> {
    return this.http.get<Process>(`${environment.baseAPI}/api/process/GetProcessById/${processId}`);
  }

  public sumAllActiveProcess(): Observable<number> {
    return this.http.get<number>(`${environment.baseAPI}/api/process/SumAllActiveProcess`);
  }

  public sumActiveProcessByClient(clientId: number): Observable<number> {
    return this.http.get<number>(`${environment.baseAPI}/api/process/SumActiveProcessByClient/${clientId}`);
  }

  public CalcAverageProcessByClient(clientId: number, monetaryValue: number): Observable<number> {
    const requestProcessMoney = {
      clientId: clientId,
      monetaryValue: monetaryValue
    };

    return this.http.post<number>(`${environment.baseAPI}/api/process/CalcAverageProcessByClient`, requestProcessMoney);
  }

  public getProcessByDate(date: Date): Observable<number> {
    return this.http.post<number>(`${environment.baseAPI}/api/process/GetProcessByDate`, date);
  }

  public getProcessByStateClient(state: string): Observable<number> {
    return this.http.post<number>(`${environment.baseAPI}/api/process/GetProcessByStateClient`, state);
  }

  public processContains(acronym: string): Observable<number> {
    return this.http.post<number>(`${environment.baseAPI}/api/process/ProcessContains`, acronym);
  }

  public insert(process: Process): Observable<any> {

    return this.http.post(`${environment.baseAPI}/api/process/Insert`, process);
  }

  public update(process: Process): Observable<any> {
    return this.http.post<number>(`${environment.baseAPI}/api/process/Update`, process);
  }

  public delete(process: Process): Observable<any> {
    return this.http.delete<number>(`${environment.baseAPI}/api/process/Delete/${process.id}`);
  }
}

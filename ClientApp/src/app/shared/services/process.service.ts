import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Process } from '../model/Process/Process';

@Injectable({
  providedIn: 'root'
})
export class ProcessService {

  constructor(
    private http: HttpClient
  ) { }

  public getAllProcess(): Observable<Process[]> {
    return this.http.get<Process[]>(`${environment.baseAPI}/api/GetAllProcess`);
  }

  public getProcessById(processId: number): Observable<Process> {
    return this.http.get<Process>(`${environment.baseAPI}/api/GetProcessById/${processId}`);
  }

  public sumAllActiveProcess(): Observable<number> {
    return this.http.get<number>(`${environment.baseAPI}/api/SumAllActiveProcess`);
  }

  public sumActiveProcessByClient(clientId: number): Observable<number> {
    return this.http.get<number>(`${environment.baseAPI}/api/SumActiveProcessByClient/${clientId}`);
  }

  public CalcAverageProcessByClient(clientId: number, monetaryValue: number): Observable<number> {
    const requestProcessMoney = {
      clientId: clientId,
      monetaryValue: monetaryValue
    };

    return this.http.post<number>(`${environment.baseAPI}/api/CalcAverageProcessByClient`, requestProcessMoney);
  }

  public getProcessByDate(date: Date): Observable<number> {
    return this.http.post<number>(`${environment.baseAPI}/api/GetProcessByDate`, date);
  }

  public getProcessByStateClient(state: string): Observable<number> {
    return this.http.post<number>(`${environment.baseAPI}/api/GetProcessByStateClient`, state);
  }

  public processContains(acronym: string): Observable<number> {
    return this.http.post<number>(`${environment.baseAPI}/api/ProcessContains`, acronym);
  }

  public insert(process: Process): Observable<any> {
    return this.http.post<number>(`${environment.baseAPI}/api/Insert`, process);
  }

  public update(process: Process): Observable<any> {
    return this.http.post<number>(`${environment.baseAPI}/api/Update`, process);
  }

  public delete(process: Process): Observable<any> {
    return this.http.delete<number>(`${environment.baseAPI}/api/Delete/${process.id}`);
  }
}

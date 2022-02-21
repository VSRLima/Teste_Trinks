import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Client } from '../../model/Client/Client';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  constructor(
    private http: HttpClient
  ) { }

  public getAllClient(): Observable<Client[]> {
    return this.http.get<Client[]>(`${environment.baseAPI}/api/client/GetAllClient`);
  }

  public getClientById(clientId: number): Observable<Client> {
    return this.http.get<Client>(`${environment.baseAPI}/api/client/GetClientById/${clientId}`);
  }

  public insert(client: Client): Observable<any> {
    return this.http.post(`${environment.baseAPI}/api/client/Insert`, client);
  }

  public update(client: Client): Observable<any> {
    return this.http.post(`${environment.baseAPI}/api/client/Update`, client);
  }

  public delete(client: Client): Observable<any> {
    return this.http.delete(`${environment.baseAPI}/api/client/Delete/${client.id}`);
  }
}

import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { AccountStatement } from '../models/accountstatement';


@Injectable({
  providedIn: 'root'
})
export class AccountstatementService {
  _baseUrl: string;
  _http: HttpClient;
  public statements: AccountStatement[] = [];
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
    this._http = http;
  }


   getStatements(statementRequestModel: any): Observable<AccountStatement[]> {
    const statementRequestJson = JSON.parse(JSON.stringify(statementRequestModel));
    return this.http.post<AccountStatement[]>(this._baseUrl + 'api/statements/FetchStatement', statementRequestJson);
  }
 
}


 




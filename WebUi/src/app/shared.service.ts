import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SortingModel } from './sorting/model/SortingModel'

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  readonly APIUrl = "https://localhost:44300/api";

  constructor(private http:HttpClient) { }

  GetSorting():Observable<SortingModel> {
  return this.http.get<SortingModel>(this.APIUrl + '/sorting')
  }
}

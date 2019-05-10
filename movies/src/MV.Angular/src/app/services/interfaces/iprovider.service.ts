import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class IProvider {

  constructor() { }

  public get(url: string): Observable<any> {
    return Observable.create();
  }

  public getByFilter(url: string, obj: object): Observable<any> {
    return Observable.create();
  }

  public getByQueryString(url: string, queryString: object): Observable<any> {
    return Observable.create();
  }

  public post(url: string, body: any, options?: any): Observable<any> {
    return Observable.create();
  }

  public put(url: string, id: string, body: any): Observable<any> {
    return Observable.create();
  }

  public delete(url: string, id: string): Observable<any> {
    return Observable.create();
  }

}

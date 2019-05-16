import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { environment } from '@environments/environment.dev';
import { IProvider } from '@services/interfaces/iprovider.service';
import { INotification } from '@services/interfaces/inotification.service';
import { Observable } from 'rxjs';

const apiBaseURL = environment.baseURL;
const httpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });
let httpOptions = { headers: httpHeaders };

@Injectable({
  providedIn: 'root'
})

export class HttpService implements IProvider {

  constructor(private http: HttpClient, private notification: INotification) { }

  public get(url: string): Observable<any> {
    console.log('GET: ' + apiBaseURL + url);

    return Observable.create(observer => {
      this.http
        .get<any>(apiBaseURL + url)
        .subscribe(
          response => {
            observer.next(response);
          },
          error => {
            this.notification.showError('An error occour trying to get data', `Status: ${error.status} Text: ${error.statusText}`);
          },
          () => {
            observer.complete();
          }
        );
    });
  }

  public getByFilter(url: string, filter: object): Observable<any> {

    let fullURL = apiBaseURL + url;
    Object.keys(filter).forEach(key => {
      fullURL += `/${filter[key]}`;
    });

    console.log('GET: ' + fullURL);
    return Observable.create(observer => {
      this.http
        .get<any>(fullURL)
        .subscribe(
          response => {
            observer.next(response);
          },
          error => {
            this.notification.showError('An error occour trying to get data', `Status: ${error.status} Text: ${error.statusText}`);
          },
          () => {
            observer.complete();
          }
        );
    });
  }

  public getByQueryString(url: string, queryString: object): Observable<any> {

    let fullURL = apiBaseURL + url + '?';
    Object.keys(queryString).forEach(key => {
      fullURL += `${key}=${queryString[key]}&`;
    });

    console.log('GET: ' + fullURL);

    return Observable.create(observer => {
      this.http
        .get<any>(fullURL)
        .subscribe(
          response => {
            observer.next(response);
          },
          error => {
            this.notification.showError('An error occour trying to get data', `Status: ${error.status} Text: ${error.statusText}`);
          },
          () => {
            observer.complete();
          }
        );
    });
  }

  public post(url: string, data: any, options?: any): Observable<any> {
    console.log('POST: ' + apiBaseURL + url);
    if (options !== undefined) {
      httpOptions = options;
    } else {
      httpOptions = { headers: httpHeaders };
    }
    return Observable.create(observer => {
      this.http
        .post(apiBaseURL + url, data, httpOptions)
        .subscribe(
          response => {
            observer.next(response);
          },
          error => {
            observer.next(error.error);
            // this.notification.showError('An error occour trying to get data', `Status: ${error.status} Text: ${error.statusText}`);
          },
          () => {
            observer.complete();
          }
        );
    });
  }

  public put(url: string, id: string, data: any, options?: any): Observable<any> {
    console.log('PUT: ' + apiBaseURL + url);
    if (options !== undefined) {
      httpOptions = options;
    } else {
      httpOptions = { headers: httpHeaders };
    }
    return Observable.create(observer => {
      this.http
        .put(`${apiBaseURL}${url}/${id}`, data, httpOptions)
        .subscribe(
          response => {
            observer.next(response);
          },
          error => {
            this.notification.showError('An error occour trying to get data', `Status: ${error.status} Text: ${error.statusText}`);
          },
          () => {
            observer.complete();
          }
        );
    });
  }

  public delete(url: string, id: string): Observable<any> {
    const fullURL = `${apiBaseURL}${url}/${id}`;
    console.log('DELETE: ' + fullURL);
    return Observable.create(observer => {
      this.http
        .delete(fullURL, httpOptions)
        .subscribe(
          response => {
            observer.next(response);
          },
          error => {
            this.notification.showError('An error occour trying to get data', `Status: ${error.status} Text: ${error.statusText}`);
          },
          () => {
            observer.complete();
          }
        );
    });
  }
}


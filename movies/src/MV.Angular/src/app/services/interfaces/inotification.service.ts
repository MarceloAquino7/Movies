import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class INotification {

  constructor() { }
  showError(title: string, message: string): void {
    throw new Error('Method not implemented.');
  }
  showSuccess(title: string, message: string): void {
    throw new Error('Method not implemented.');
  }
  showInfo(title: string, message: string): void {
    throw new Error('Method not implemented.');
  }

}

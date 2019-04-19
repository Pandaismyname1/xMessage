import { Injectable } from '@angular/core';
import {AuthService} from '../auth/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AppStateService {
  loggedIn = false;
  accountId: number;
  authKey: string;
  constructor(private authService: AuthService) { }

  async login(username: string, password: string) {
    const response = await this.authService.login(username, password);
    if (response.success) {
      this.accountId = response.accountId;
      this.authKey = response.authKey;
      this.loggedIn = true;
    } else {
      console.log(response.errors);
      this.loggedIn = false;
    }
    console.log(this.loggedIn);
  }
  async register(username: string, password: string) {
    const response = await this.authService.register(username, password);
    if (response.success) {
      // this.loggedIn = true;
      console.log('Account Created');
    } else {
      // this.loggedIn = false;
      console.log('Account Not Created');
    }
  }
}

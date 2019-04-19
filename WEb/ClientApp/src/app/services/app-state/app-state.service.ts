import { Injectable } from '@angular/core';
import {AuthService} from '../auth/auth.service';
import { MatSnackBar} from '@angular/material';

@Injectable({
  providedIn: 'root'
})
export class AppStateService {
  loggedIn = false;
  accountId: number;
  authKey: string;
  constructor(private authService: AuthService,
              private snackBar: MatSnackBar) { }

  async login(username: string, password: string) {
    const response = await this.authService.login(username, password);
    if (response.success) {
      this.accountId = response.accountId;
      this.authKey = response.authKey;
      this.loggedIn = true;
      this.snackBar.open('Login successful');
    } else {
      console.log(response.errors);
      for (const error of response.errors) {
        this.snackBar.open(error);
      }
      this.loggedIn = false;
    }
    console.log(this.loggedIn);
  }
  async register(username: string, password: string) {
    const response = await this.authService.register(username, password);
    if (response.success) {
      // this.loggedIn = true;
      this.snackBar.open('Account Created, please Log in');
      console.log('Account Created');
    } else {
      // this.loggedIn = false;
      for (const error of response.errors) {
        this.snackBar.open(error);
      }
      console.log('Account Not Created');
    }
  }
}

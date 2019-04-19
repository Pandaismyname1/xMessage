import {Injectable} from '@angular/core';
import {ServerService} from '../server/server.service';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {RegisterResponse} from '../../models/responses/registerResponse';
import {RegisterRequest} from '../../models/requests/registerRequest';
import {AuthResponse} from '../../models/responses/authResponse';
import {AuthRequest} from '../../models/requests/authRequest';

@Injectable({
    providedIn: 'root'
})
export class AuthService {

    registerUrl = 'api/accounts';
    loginUrl = 'api/auth';

    constructor(private serverService: ServerService,
                private http: HttpClient) {
    }

    async login(email: string, password: string) {
        const request = new AuthRequest();
        request.email = email;
        request.password = password;

        return this.http.get<AuthResponse>(this.serverService.serverUrl + this.loginUrl, {
            params: request as any,
            headers: this.serverService.requestHeaders
        }).toPromise();
    }

    async register(email: string, password: string) {
        const request = new RegisterRequest();
        request.email = email;
        request.password = password;
        return this.http.post<RegisterResponse>(this.serverService.serverUrl + this.registerUrl, request, {headers: this.serverService.requestHeaders}).toPromise();
    }

}

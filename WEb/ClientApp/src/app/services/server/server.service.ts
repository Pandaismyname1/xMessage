import {Injectable} from '@angular/core';
import {HttpHeaders} from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class ServerService {

    serverUrl = 'https://xmessage20190419031736.azurewebsites.net/';
    requestHeaders = new HttpHeaders({'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*',
        'Access-Control-Allow-Methods': 'DELETE, POST, PUT, GET',
        'Access-Control-Allow-Headers': 'Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With'});

    constructor() {
    }
}

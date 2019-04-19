import {Component, OnInit} from '@angular/core';
import {AppStateService} from '../../services/app-state/app-state.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

    registerEmailAddress: string;
    registerPassword: string;
    loginEmailAddress: string;
    loginPassword: string;

    constructor(public appStateService: AppStateService) {
    }

    ngOnInit() {
    }

}

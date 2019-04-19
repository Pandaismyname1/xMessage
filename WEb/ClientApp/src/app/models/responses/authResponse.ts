import {GenericResponse} from './genericResponse';

export class AuthResponse extends GenericResponse {
    accountId: number;
    authKey: string;
}

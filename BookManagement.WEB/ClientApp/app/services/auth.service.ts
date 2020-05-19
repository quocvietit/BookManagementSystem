import { Injectable } from '@angular/core';
import { Login } from "../models/login.model";
import { Http } from '@angular/http';
import { Utilities } from './utilities';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';



@Injectable()

export class AuthenticationService {

    private url = Utilities.baseUrl() + '/api/account';

    constructor( private http: Http) { }

    check(model: Login) {

        return this.http.post(this.url, model)
            .map(res => {
                console.log(res.json());
                return res.json();
            });
    }


    logout(): void {
        console.log("-------------dwad");
        localStorage.removeItem('currentUser');
    }

}
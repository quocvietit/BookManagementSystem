import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthenticationService } from "../../services/auth.service";
import { Message } from "primeng/primeng";
import { Login } from "../../models/login.model";

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
    returnUrl: string;
    loginForm: FormGroup;
    msgs: Message[] = [];
    loading: boolean = false;

    constructor(
        private router: Router,
        private route: ActivatedRoute,
        private authenService: AuthenticationService
    ) { }



    ngOnInit(): void {
        this.loginForm = new FormGroup({
            UserName: new FormControl(),
            Password: new FormControl()
        });
        if (localStorage.getItem('currentUser') != null) {
            this.router.navigate([this.route.snapshot.queryParams['returnUrl'] || '/home']);
        }
        this.authenService.logout();
        if (this.route.snapshot.queryParams['returnUrl'] == '/') {
            this.returnUrl = '/home';
        } else {
            this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/home';
        }
    }


    login(): void {
        this.loading = true;
        console.log(this.loginForm.value);
        this.authenService.check(this.loginForm.value)
            .subscribe(data => {
            console.log(data);
            if (data) {
                localStorage.setItem('currentUser', this.loginForm.value.UserName);
                this.router.navigate([this.returnUrl]);
            }
            else {
                this.msgs = [];
                this.msgs.push({ severity: 'error', summary: 'Error Message', detail: 'Username and password incorrect' });
            }
            this.loading = false;
        })
    }
}
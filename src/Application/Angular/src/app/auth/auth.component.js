var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from '@angular/core';
import { Validators, FormControl } from '@angular/forms';
import { HttpService } from '../http.service';
let AuthComponent = class AuthComponent {
    constructor(httpService, fb) {
        this.httpService = httpService;
        this.fb = fb;
        this.submitted = false;
        this.LoginForm = fb.group({
            Email: new FormControl('', [Validators.required]),
            Password: new FormControl('', [Validators.required])
        });
    }
    ngOnInit() {
    }
    get f() {
        return this.LoginForm.controls;
    }
    SignIn() {
        this.submitted = true;
        if (this.LoginForm.invalid) {
            return;
        }
        console.log(this.LoginForm);
        this.httpService.postData('https://localhost:5001/Account/LoginPost', this.LoginForm.value).subscribe();
    }
};
AuthComponent = __decorate([
    Component({
        selector: 'app-auth',
        templateUrl: './auth.component.html',
        styleUrls: ['./auth.component.scss'],
        providers: [HttpService]
    })
], AuthComponent);
export { AuthComponent };
//# sourceMappingURL=auth.component.js.map
import { __decorate } from "tslib";
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
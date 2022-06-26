var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from '@angular/core';
import { Validators, FormControl, FormGroup } from '@angular/forms';
import { HttpService } from '../http.service';
import { CustomValidators } from './CustomValidators';
let CreateComponent = class CreateComponent {
    constructor(httpService, fb) {
        this.httpService = httpService;
        this.fb = fb;
        this.submitted = false;
        this.formCreate = new FormGroup({
            fio: new FormControl('', [Validators.required]),
            email: new FormControl('', [Validators.required]),
            phone: new FormControl('', [Validators.pattern("[+][0-9][(][0-9]{3}[)][0-9]{3}[-][0-9]{2}[-][0-9]{2}")]),
            password: new FormControl('', [Validators.required]),
            confirmPassword: new FormControl('', [Validators.required])
        }, CustomValidators.mustMatch('password', 'confirmPassword'));
    }
    get f() {
        return this.formCreate.controls;
    }
    onSubmit() {
        this.submitted = true;
        if (this.formCreate.invalid) {
            return;
        }
        console.log(this.formCreate);
        this.httpService.postData('https://localhost:5001/Account/RegisterPost', this.formCreate.value).subscribe();
    }
    ngOnInit() {
    }
};
CreateComponent = __decorate([
    Component({
        selector: 'app-create',
        templateUrl: './create.component.html',
        styleUrls: ['./create.component.scss'],
        providers: [HttpService]
    })
], CreateComponent);
export { CreateComponent };
//# sourceMappingURL=create.component.js.map
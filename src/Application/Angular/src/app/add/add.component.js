var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from '@angular/core';
import { Validators, FormControl, FormGroup } from '@angular/forms';
import { HttpService } from '../http.service';
let AddComponent = class AddComponent {
    constructor(httpService, fb) {
        this.httpService = httpService;
        this.fb = fb;
        this.categories = [
            { id: 1, name: "Категория 1" },
            { id: 2, name: "Подкатегория 1" },
            { id: 3, name: "Подкатегория 2" },
            { id: 4, name: "Категория 2" },
            { id: 5, name: "Подкатегория 1" },
            { id: 6, name: "Подкатегория 2" },
            { id: 7, name: "Категория 3" },
            { id: 8, name: "Подкатегория 1" },
            { id: 9, name: "Подкатегория 2" },
        ];
        this.submitted = false;
        this.addPost = new FormGroup({
            name: new FormControl('', [Validators.required]),
            description: new FormControl('', [Validators.required]),
            category: new FormControl('', [Validators.required]),
            cost: new FormControl('', [Validators.required]),
            city: new FormControl('', [Validators.required])
        });
    }
    get f() {
        return this.addPost.controls;
    }
    onSubmit() {
        this.submitted = true;
        if (this.addPost.invalid) {
            return;
        }
        console.log(this.addPost);
        this.httpService.postData('https://localhost:5001/Account/New', this.addPost.value).subscribe();
    }
    ngOnInit() {
    }
};
AddComponent = __decorate([
    Component({
        selector: 'app-add',
        templateUrl: './add.component.html',
        styleUrls: ['./add.component.scss'],
        providers: [HttpService]
    })
], AddComponent);
export { AddComponent };
//# sourceMappingURL=add.component.js.map
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from '@angular/core';
import { HttpService } from '../http.service';
let AccComponent = class AccComponent {
    constructor(httpService) {
        this.httpService = httpService;
        this.posts = [];
    }
    ngOnInit() {
        this.httpService.getData("http://localhost:5000/Post/GetNumber?number=2147483647").subscribe((data) => {
            this.posts = data;
            this.posts.forEach(element => {
                element.date = new Date(element.dateOfCreate);
                element.dateOfCreate = element.dateOfCreate.slice(0, 10);
            });
        });
    }
};
AccComponent = __decorate([
    Component({
        selector: 'app-acc',
        templateUrl: './acc.component.html',
        styleUrls: ['./acc.component.scss'],
        providers: [HttpService]
    })
], AccComponent);
export { AccComponent };
//# sourceMappingURL=acc.component.js.map
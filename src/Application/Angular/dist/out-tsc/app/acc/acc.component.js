import { __decorate } from "tslib";
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
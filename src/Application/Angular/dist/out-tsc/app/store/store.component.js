import { __decorate } from "tslib";
import { Component } from '@angular/core';
import { HttpService } from '../http.service';
let StoreComponent = class StoreComponent {
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
StoreComponent = __decorate([
    Component({
        selector: 'app-store',
        templateUrl: './store.component.html',
        styleUrls: ['./store.component.scss'],
        providers: [HttpService]
    })
], StoreComponent);
export { StoreComponent };
//# sourceMappingURL=store.component.js.map
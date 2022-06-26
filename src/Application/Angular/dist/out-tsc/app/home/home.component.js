import { __decorate } from "tslib";
import { Component } from '@angular/core';
let HomeComponent = class HomeComponent {
    constructor(accountService) {
        this.accountService = accountService;
        this.user = this.accountService.userValue;
    }
};
HomeComponent = __decorate([
    Component({ templateUrl: 'home.component.html', styleUrls: ['./home.component.scss'] })
], HomeComponent);
export { HomeComponent };
//# sourceMappingURL=home.component.js.map
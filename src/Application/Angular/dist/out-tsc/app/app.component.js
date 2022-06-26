import { __decorate } from "tslib";
import { Component } from '@angular/core';
let AppComponent = class AppComponent {
    constructor(accountService) {
        this.accountService = accountService;
        this.accountService.user.subscribe(x => this.user = x);
    }
    logout() {
        this.accountService.logout();
    }
};
AppComponent = __decorate([
    Component({ selector: 'app', templateUrl: 'app.component.html', styleUrls: ['./app.component.scss'] })
], AppComponent);
export { AppComponent };
//# sourceMappingURL=app.component.js.map
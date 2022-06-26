import { __decorate } from "tslib";
import { Component } from '@angular/core';
let LayoutComponent = class LayoutComponent {
    constructor(router, accountService) {
        this.router = router;
        this.accountService = accountService;
        // redirect to home if already logged in
        if (this.accountService.userValue) {
            this.router.navigate(['/']);
        }
    }
};
LayoutComponent = __decorate([
    Component({ templateUrl: 'layout.component.html' })
], LayoutComponent);
export { LayoutComponent };
//# sourceMappingURL=layout.component.js.map
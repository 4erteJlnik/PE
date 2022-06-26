import { __decorate } from "tslib";
import { Component, Input } from '@angular/core';
let HelloComponent = class HelloComponent {
};
__decorate([
    Input()
], HelloComponent.prototype, "name", void 0);
HelloComponent = __decorate([
    Component({
        selector: 'hello',
        template: `<h1>Hello {{name}}!</h1>`,
        styles: [`h1 { font-family: Lato; }`]
    })
], HelloComponent);
export { HelloComponent };
//# sourceMappingURL=hello.component.js.map
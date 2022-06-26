import { __decorate } from "tslib";
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AccountRoutingModule } from './account-routing.module';
import { LayoutComponent } from './layout.component';
import { LoginComponent } from './login.component';
import { RegisterComponent } from './register.component';
let AccountModule = class AccountModule {
};
AccountModule = __decorate([
    NgModule({
        imports: [
            CommonModule,
            ReactiveFormsModule,
            AccountRoutingModule
        ],
        declarations: [
            LayoutComponent,
            LoginComponent,
            RegisterComponent
        ]
    })
], AccountModule);
export { AccountModule };
//# sourceMappingURL=account.module.js.map
import { __decorate } from "tslib";
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { UsersRoutingModule } from './users-routing.module';
import { LayoutComponent } from './layout.component';
import { ListComponent } from './list.component';
import { AddEditComponent } from './add-edit.component';
let UsersModule = class UsersModule {
};
UsersModule = __decorate([
    NgModule({
        imports: [
            CommonModule,
            ReactiveFormsModule,
            UsersRoutingModule
        ],
        declarations: [
            LayoutComponent,
            ListComponent,
            AddEditComponent
        ]
    })
], UsersModule);
export { UsersModule };
//# sourceMappingURL=users.module.js.map
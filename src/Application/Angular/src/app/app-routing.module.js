var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './home';
import { LoginComponent } from './account/login.component';
import { RegisterComponent } from './account/register.component';
import { StoreComponent } from './store/store.component';
import { AddComponent } from './add/add.component';
import { AccComponent } from './acc/acc.component';
import { EditComponent } from './edit/edit.component';
import { LayoutComponent } from './account/layout.component';
const accountModule = () => import('./account/account.module').then(x => x.AccountModule);
const routes = [
    { path: '', component: HomeComponent },
    {
        path: 'account', component: LayoutComponent,
        children: [
            { path: 'login', component: LoginComponent },
            { path: 'register', component: RegisterComponent }
        ]
    },
    { path: 'store', component: StoreComponent },
    { path: 'acc', component: AccComponent },
    { path: 'add', component: AddComponent },
    { path: 'edit', component: EditComponent },
    
];
let AppRoutingModule = class AppRoutingModule {
};
AppRoutingModule = __decorate([
    NgModule({
        imports: [RouterModule.forRoot(routes)],
        exports: [RouterModule]
    })
], AppRoutingModule);
export { AppRoutingModule };
//# sourceMappingURL=app-routing.module.js.map
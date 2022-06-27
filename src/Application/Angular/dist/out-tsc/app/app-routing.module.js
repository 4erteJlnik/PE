import { __decorate } from "tslib";
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AuthGuard } from './_helpers';
import { HomeComponent } from './home';
import { StoreComponent } from './store/store.component';
import { AddComponent } from './add/add.component';
import { AccComponent } from './acc/acc.component';
import { EditComponent } from './edit/edit.component';
import { ViewComponent } from './view/view.component';
const accountModule = () => import('./account/account.module').then(x => x.AccountModule);
const usersModule = () => import('./users/users.module').then(x => x.UsersModule);
const routes = [
    { path: '', component: HomeComponent },
    { path: 'account', loadChildren: accountModule },
    { path: 'store', component: StoreComponent },
    { path: 'acc', component: AccComponent },
    { path: 'add', component: AddComponent },
    { path: 'edit', component: EditComponent },
    { path: 'view', component: ViewComponent },
    { path: 'users', loadChildren: usersModule, canActivate: [AuthGuard] },
    // otherwise redirect to home
    { path: '**', redirectTo: '' }
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
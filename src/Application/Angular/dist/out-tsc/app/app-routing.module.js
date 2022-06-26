import { __decorate } from "tslib";
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './home';
import { StoreComponent } from './store/store.component';
import { AddComponent } from './add/add.component';
import { AccComponent } from './acc/acc.component';
import { EditComponent } from './edit/edit.component';
const accountModule = () => import('./account/account.module').then(x => x.AccountModule);
const routes = [
    { path: '', component: HomeComponent },
    { path: 'account', loadChildren: accountModule },
    { path: 'store', component: StoreComponent },
    { path: 'acc', component: AccComponent },
    { path: 'add', component: AddComponent },
    { path: 'edit', component: EditComponent },
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
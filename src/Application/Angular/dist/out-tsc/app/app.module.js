import { __decorate } from "tslib";
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AddComponent } from './add/add.component';
import { AccComponent } from './acc/acc.component';
import { StoreComponent } from './store/store.component';
import { EditComponent } from './edit/edit.component';
import { ViewComponent } from './view/view.component';
// used to create fake backend
import { fakeBackendProvider } from './_helpers';
import { AppRoutingModule } from './app-routing.module';
import { JwtInterceptor, ErrorInterceptor } from './_helpers';
import { AppComponent } from './app.component';
import { AlertComponent } from './_components';
import { HomeComponent } from './home';
let AppModule = class AppModule {
};
AppModule = __decorate([
    NgModule({
        imports: [
            BrowserModule,
            ReactiveFormsModule,
            HttpClientModule,
            AppRoutingModule
        ],
        declarations: [
            AppComponent,
            AlertComponent,
            StoreComponent,
            AddComponent,
            AccComponent,
            EditComponent,
            ViewComponent,
            HomeComponent
        ],
        providers: [
            { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
            { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
            // provider used to create fake backend
            fakeBackendProvider
        ],
        bootstrap: [AppComponent]
    })
], AppModule);
export { AppModule };
;
//# sourceMappingURL=app.module.js.map
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { Routes, RouterModule } from '@angular/router';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { GeneralComponent } from './general/general.component';
import { AddComponent } from './add/add.component';
import { CreateComponent } from './create/create.component';
import { StoreComponent } from './store/store.component';
import { AuthComponent } from './auth/auth.component';

import { HttpClientModule }   from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
    imports: [
	BrowserModule,
    	FormsModule, 
	AppRoutingModule,
    	HttpClientModule,
    	ReactiveFormsModule
    ],
    declarations: [
	AppComponent, 
	GeneralComponent,
	StoreComponent,
	AuthComponent,
	AddComponent,
	CreateComponent
	],
    bootstrap: [AppComponent]
})
export class AppModule { }
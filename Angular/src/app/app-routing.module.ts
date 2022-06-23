import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthComponent } from './auth/auth.component';
import { GeneralComponent } from './general/general.component';
import { StoreComponent } from './store/store.component';
import { AddComponent } from './add/add.component';
import { CreateComponent } from './create/create.component';

const routes: Routes = [
  { path: 'auth', component: AuthComponent },
  { path: '', component:  GeneralComponent},
  { path: 'store', component:  StoreComponent},
  { path: 'add', component: AddComponent},
  { path: 'create', component:  CreateComponent}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
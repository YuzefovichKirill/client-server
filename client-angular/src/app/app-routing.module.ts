import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './home';
import { FridgeModelComponent } from './fridge-model'

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'fridge-model', component: FridgeModelComponent},

  {path: '**', redirectTo: ''}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

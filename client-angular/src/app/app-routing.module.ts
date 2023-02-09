import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './components/home';
import { FridgeModelListComponent } from './components/fridge-model/fridge-model-list'
import { FridgeModelCreateComponent } from './components/fridge-model/fridge-model-create/fridge-model-create.component';
import { FridgeModelEditComponent } from './components/fridge-model/fridge-model-edit/fridge-model-edit.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'fridge-model', component: FridgeModelListComponent},
  {path: 'fridge-model/create', component: FridgeModelCreateComponent},
  {path: 'fridge-model/edit/:id', component: FridgeModelEditComponent},

  {path: '**', redirectTo: ''}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

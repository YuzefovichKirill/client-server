import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './components/home';
import {FridgeModelCreateComponent, FridgeModelEditComponent, 
  FridgeModelListComponent} from './components/fridge-model'
import { FridgeCreateComponent, FridgeEditComponent, 
  FridgeListComponent } from './components/fridge';
import { ProductListComponent, ProductCreateComponent,
        ProductEditComponent } from './components/product';
  
const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'fridge-model', component: FridgeModelListComponent},
  {path: 'fridge-model/create', component: FridgeModelCreateComponent},
  {path: 'fridge-model/edit/:id', component: FridgeModelEditComponent},
  {path: 'fridge', component: FridgeListComponent},
  {path: 'fridge/create', component: FridgeCreateComponent},
  {path: 'fridge/edit/:id', component: FridgeEditComponent},
  {path: 'product', component: ProductListComponent},
  {path: 'product/create', component: ProductCreateComponent},
  {path: 'product/edit/:id', component: ProductEditComponent},

  {path: '**', redirectTo: ''}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

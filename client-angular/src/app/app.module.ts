import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home';
import { FormsModule } from '@angular/forms';

import { FridgeModelCreateComponent, FridgeModelEditComponent, 
        FridgeModelListComponent } from './components/fridge-model'
import { FridgeCreateComponent, FridgeListComponent,
        FridgeEditComponent } from './components/fridge';
import { ProductCreateComponent, ProductEditComponent, 
        ProductListComponent } from './components/product';
import { FridgeProductCreateComponent, FridgeProductEditComponent, FridgeProductListComponent } from './components/fridge-product';

@NgModule({
  declarations: [			
    AppComponent,
    HomeComponent,
    
    FridgeModelListComponent,
    FridgeModelCreateComponent,
    FridgeModelEditComponent,

    FridgeListComponent,
    FridgeCreateComponent,
    FridgeEditComponent,
    
    ProductListComponent,
    ProductCreateComponent,
    ProductEditComponent,

    FridgeProductListComponent,
    FridgeProductCreateComponent,
    FridgeProductEditComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home';
import { AuthComponent } from './components/auth/auth/auth.component';
import { AuthInterceptorService } from './shared/services/auth-interceptor.service';

import { FridgeModelCreateComponent, FridgeModelEditComponent, 
        FridgeModelListComponent } from './components/fridge-model'
import { FridgeCreateComponent, FridgeListComponent,
        FridgeEditComponent } from './components/fridge';
import { ProductCreateComponent, ProductEditComponent, 
        ProductListComponent } from './components/product';
import { FridgeProductCreateComponent, FridgeProductEditComponent,
        FridgeProductListComponent } from './components/fridge-product';


@NgModule({
  declarations: [			
    AppComponent,
    HomeComponent,
    AuthComponent,
    
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
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: AuthInterceptorService, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

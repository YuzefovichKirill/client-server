import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home';
import { FridgeModelListComponent } from './components/fridge-model/fridge-model-list';
import { FridgeModelCreateComponent } from './components/fridge-model/fridge-model-create';
import { FormsModule } from '@angular/forms';
import { FridgeModelEditComponent } from './components/fridge-model/fridge-model-edit';

@NgModule({
  declarations: [			
    AppComponent,
    HomeComponent,
    FridgeModelListComponent,
    FridgeModelCreateComponent,
    FridgeModelEditComponent
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

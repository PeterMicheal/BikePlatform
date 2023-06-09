import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './route/app-routing.module';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { RepairRequestComponent } from './repair-request/repair-request.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    RepairRequestComponent
  ],
  imports: [
    FormsModule,
    BrowserModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CoreModule } from '@core';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';

import { GreenwayCommonModule, GUIModule } from '@shared';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    GUIModule,
    GreenwayCommonModule,
    CoreModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule { }

import { NgModule,Component } from '@angular/core';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './home/app.home';
import { approutes, RouterApp} from './routes';
import { HomeService } from './home/Services/home.services'




@NgModule({
    imports: [BrowserModule, HttpModule, FormsModule,
        RouterModule.forRoot(approutes, { useHash: true })],
    //RouterModule.forRoot(appRoutes)],
    declarations: [RouterApp, AppComponent],//, routingComponents
    providers: [HomeService],
    //    //  OfferingIndexComponent,
    //],
    bootstrap: [RouterApp]
})

export class AppModule { }
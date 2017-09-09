import { Router, RouterModule, Routes, ActivatedRoute } from '@angular/router';
import { Component } from '@angular/core';
import { AppComponent} from './home/app.home'
@Component({
    selector: "main-app",
    templateUrl: "./app/route.index.tpl.html"
})
export class RouterApp {
}

export const approutes: Routes = [
    { path: 'home', component: AppComponent, data: { preload: true }, },
   { path: '**', pathMatch: 'full', component: AppComponent } 
]
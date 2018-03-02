import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: 'home',
    loadChildren: '@features/dashboard/dashboard.module#DashboardModule'
  },
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'myfeature'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

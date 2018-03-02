# Routing
Angular provides a powerful routing framework, enabling us to lazy-load modules and reduce our initial page load times.

In this lab, we will focus on moving our feature module into the routing framework.

## Step 1
Update our `app.component.html` template to use a `router-outlet` element. Be sure to mark it with the `guiContent` directive.

```html
<!--The content below is only a placeholder and can be replaced.-->
<gui-root>
  <div guiSidebar></div>
  <div guiBanner></div>
  <router-outlet guiContent></router-outlet>
</gui-root>
```

## Step 2
Remove all references to the `MyFeatureModule` from the `AppModule`.

```typescript
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
  exports: []
})
export class AppModule { }
```

## Step 3
Update our `app-routing.module.ts` to lazy load our feature module.

```typescript
import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: 'home',
    loadChildren: '@features/dashboard/dashboard.module#DashboardModule'
  },
  {
    path: 'myfeature',
    loadChildren: '@features/my-feature/my-feature.module#MyFeatureModule'
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
```

# Step 4
Create a routing ngModule for our feature. In the `/features/my-feature` folder, create a new file called `my-feature-routing.module.ts`.

You can add the following code.

```typescript
import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MyFeatureComponent } from './my-feature/my-feature.component';

const routes: Routes = [
  {
    path: '',
    component: MyFeatureComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MyFeatureRoutingModule { }
```

# Step 5
Now we can import our routing ngModule into `my-feature.module.ts`.

```typescript
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GUIModule } from '@shared';
import { MyFeatureComponent } from './my-feature/my-feature.component';
import { MyFeatureRoutingModule } from './my-feature-routing.module';

@NgModule({
  imports: [
    CommonModule,
    GUIModule,
    MyFeatureRoutingModule
  ],
  declarations: [MyFeatureComponent],
  exports: [MyFeatureComponent]
})
export class MyFeatureModule { }
```

At this point, the application should look identical to what we started with, but now we are using Angular's routing framework to load in our feature module.

## Step 6
Create a home button so we can always route back to our `home` route.

Navigate to the `app.component.html` and add a button, with a `routerLink` directive on it, in the `guiSidebar`. Set the routerLink to `"/home"`.

```html
<gui-root>
  <div guiSidebar>
    <button class="icon icon--home--lightWhite u-flex--bottom" routerLink="/home">Home</button>
  </div>
  <div guiBanner></div>
  <router-outlet guiContent></router-outlet>
</gui-root>
```

When you click the home button, you should be taken to a dashboard with a widget that, when clicked, routes to your feature page.
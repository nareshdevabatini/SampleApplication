# Feature Modules
You will often here the word *module* thrown around haphazardly. Do they mean ECMAscript modules, ngModules, or high-level product feature modules? In this workshop, we have referred to our Angular ngModules as `ngModule`, and we will refer to product modules as `feature modules`.

Looking at our project structure, we can see we have a folder for `/features`. The purpose for this folder is to organize  `ngModules` that correspond to high-level product features.

## Step 1
We will use the CLI to generate our ngModule. Open bash or console at the root of the project and execute the following command:

`yarn ng generate module features/my-feature`

## Step 2
Import the `GUIModule` from `@shared` in the `my-feature.module.ts`

```typescript
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GUIModule } from '@shared'; // add me

@NgModule({
  imports: [
    CommonModule,
    GUIModule // add me
  ],
  declarations: []
})
export class MyFeatureModule { }
```

## Step 3
Now import our new ngModule into `app.module.ts`, you should use the reference `@features`.

```typescript
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CoreModule } from '@core';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';

import { GreenwayCommonModule, GUIModule } from '@shared';
import { MyFeatureModule } from '@features/my-feature/my-feature.module'; // add me

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
    MyFeatureModule, // add me
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
```

# Step 4
Create another page component, similar to our `debug-page.component.ts`. You can use the following CLI command.

`yarn ng generate component features/my-feature/my-feature --export=true`

You can also update the `app.component.html`  to use your new component.

```html
<!--The content below is only a placeholder and can be replaced.-->
<gui-root>
  <div guiSidebar></div>
  <div guiBanner></div>
  <div guiContent>
    <!-- Add me -->
    <app-my-feature></app-my-feature>
  </div>
</gui-root>
```

# Step 5
Jump to our new component template `my-feature.component.html`, and create the basic structure for a full layout.

```html
<gui-page>
  <!-- bind the local layout to our banner -->
  <gui-secondary-banner [layout]="layout">
    <div guiTitles>
      <div guiTitle>My Feature</div>
      <div guiSubtitle>It Does Nothing</div>
    </div>
  </gui-secondary-banner>
  <!-- get a local template reference using #layout -->
  <gui-full-layout #layout>
    <gui-stack>
      <gui-card active="true">
        <div guiBody class="margin">My Feature content</div>
      </gui-card>
    </gui-stack>
  </gui-full-layout>
</gui-page>
```

We should have something like the following.


![alt text][demo]

[demo]: assets/5-my-feature.png
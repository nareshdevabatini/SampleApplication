# Modals
Often we need to create popups and modal components. The GUI library provides a service for dynamically instantiating modals without the need for a routing backend.

## Step 1
We will use the CLI to generate our component. Open bash or console at the root of the project and execute the following command:

`yarn ng generate component features/my-feature/feature-modal`

Then, in order to dynamically create the component, we need to add it to our ngModules `entryComponents` array.

```typescript
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GUIModule } from '@shared';
import { MyFeatureComponent } from './my-feature/my-feature.component';
import { MyFeatureRoutingModule } from './my-feature-routing.module';
import { FeatureModalComponent } from './feature-modal/feature-modal.component';

@NgModule({
  imports: [
    CommonModule,
    GUIModule,
    MyFeatureRoutingModule
  ],
  declarations: [MyFeatureComponent, FeatureModalComponent],
  entryComponents: [FeatureModalComponent],
  exports: [MyFeatureComponent]
})
export class MyFeatureModule { }
```

## Step 2
Before we can use the service, we need to make sure we import `GuiModalModule` into our app.

Navigate to our `shared/gui.module.ts`, and it to the array.

```typescript
import { NgModule } from '@angular/core';

import {
  GuiCommonModule,
  GuiFlexGridModule,
  GuiLayoutsModule,
  GuiModalModule, // add me
  GuiWidgetModule,
} from 'greenway-angular-ui';

const GUI_MODULES = [
  GuiCommonModule,
  GuiFlexGridModule,
  GuiLayoutsModule,
  GuiModalModule, // add me
  GuiWidgetModule,
];

/**
 * Bundle all the greenway-angular-ui ngModules into a single, shared ngModule.
 *
 * Import this ngModule into any feature module that needs to use GUI components.
 */
@NgModule({
  imports: [GUI_MODULES],
  exports: [GUI_MODULES]
})
export class GUIModule { }
```

## Step 3
Navigate to the `feature-modal.component.ts`, and inject a `GuiModalRef` into our constructor. Then, create a function for closing the modal on a click;

```typescript
import { Component, OnInit } from '@angular/core';
import { GuiModalRef } from 'greenway-angular-ui';

@Component({
  selector: 'app-feature-modal',
  templateUrl: './feature-modal.component.html',
  styleUrls: ['./feature-modal.component.css']
})
export class FeatureModalComponent implements OnInit {

  constructor(private modalRef: GuiModalRef<FeatureModalComponent>) { }

  ngOnInit() {
  }

  onClose() {
    this.modalRef.close();
  }
}
```

Open up the `feature-modal.component.html`.

Throw in the following modal elements to get us started.

```html
<gui-modal>
  <gui-modal-header>My Modal</gui-modal-header>
  <gui-modal-body guiPadding>A demonstration of the GUI modal. We can dynamically instantiate modals using the GuiModalService.</gui-modal-body>
  <gui-modal-footer>
    <button (click)="onClose()">Close</button>
  </gui-modal-footer>
</gui-modal>
```

### Step 4
Now add functionality to open the modal in `my-feature.component.ts`.

```typescript
import { Component, OnInit } from '@angular/core';
import { GuiModalService } from 'greenway-angular-ui';
import { FeatureModalComponent } from '../feature-modal/feature-modal.component';

@Component({
  selector: 'app-my-feature',
  templateUrl: './my-feature.component.html',
  styleUrls: ['./my-feature.component.css']
})
export class MyFeatureComponent implements OnInit {

  constructor(private modalService: GuiModalService) { }

  ngOnInit() {
  }

  onOpenModal() {
    const modalRef = this.modalService.open(FeatureModalComponent);
  }
}
```

And in the template.

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
        <div guiBody class="margin">
          My Feature content
          <button (click)="onOpenModal()">Open Modal</button>
        </div>
      </gui-card>
    </gui-stack>
  </gui-full-layout>
</gui-page>
```
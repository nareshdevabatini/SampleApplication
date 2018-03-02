# Component
Branching off from our Directive, we will now create a Component. Components are essentially Directives with a template/html attached to it.

See [Angular's Component Documentation](https://angular.io/api/core/Component)

## Step 1
We will use the CLI to generate our component. Open bash or console at the root of the project and execute the following command:

`yarn ng generate component shared/common/debug-page --export=true`

If you want to understand the command, read the following, else you can move on.
  - `yarn` - we want to use the project's local Angular CLI package. In our `package.json` we have a script called `ng` which will use the local CLI instead of a globally installed CLI.
  - `ng` - this is Angular CLI's command interface.
  - `generate | g` - generates the following object.
  - `component | c` - the object to generate is a component.
  - `shared/common/debug-page` - the destination for the generated object, using the last hash as the name for the file, folder and component.
  - `--export` - tells the CLI to export the object from the most relatively scoped ngModule which, in this case, is the `common.module.ts`.

## Step 2
Currently, we only import the `GuiCommonModule` into our application, but we want to use more specific elements from the `GuiLayoutsModule` and the `GuiWidgetModule`.

In `app/shared/gui.module.ts`, add the following:

```typescript
import { NgModule } from '@angular/core';

import {
  GuiCommonModule,
  GuiFlexGridModule, // Add me
  GuiLayoutsModule, // Add me
  GuiWidgetModule, // Add me
} from 'greenway-angular-ui';

const GUI_MODULES = [
  GuiCommonModule,
  GuiFlexGridModule, // Add me
  GuiLayoutsModule, // Add me
  GuiWidgetModule, // Add me
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
We want to use the GUI elements in our new component, but it's container ngModule, `common.module.ts`, does not import any of the GUI library modules.

Import our application's `GUIModule` that just updated in the previous step as well as Angular's `CommonModule` 

```typescript
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common'; //Add me
import { GUIModule} from '../gui.module'; // Add me

import { ClickDebugDirective } from './click-debug/click-debug.directive';
import { DebugPageComponent } from './debug-page/debug-page.component';


@NgModule({
  imports: [GUIModule, CommonModule], // Add me
  declarations: [ClickDebugDirective, DebugPageComponent],
  exports: [ClickDebugDirective, DebugPageComponent]
})
export class GreenwayCommonModule { }
```

## Step 4
Update the `app.component.html` template to display our new component.

```html
<!--The content below is only a placeholder and can be replaced.-->
<gui-root>
  <div guiSidebar></div>
  <div guiBanner></div>
  <div guiContent>
    <app-debug-page></app-debug-page>
  </div>
</gui-root>
```

## Step 5
Navigate to `app/shared/common/debug-page/debug-page.component.html` template.

We can use the `gui-page` and `gui-dashboard-layout` components to provide structure to our component's template.

```html
<gui-page>
  <gui-dashboard-layout>
    <!-- we can add content here -->
  </gui-dashboard-layout>
</gui-page>
```

It's important to recognize that `gui-page` and `gui-dashboard-layout` are components in the GUI library, they are *NOT* directives.

## Step 6
For now, we can add a basic widget into the layout.

```html
<gui-page>
  <gui-dashboard-layout>
    <div guiWidgetContainer guiGrid="1 2 3 3">
      <div guiWidgetColumn>
        <div guiWidget class="padding">
          My widget
        </div>
      </div>
    </div>
  </gui-dashboard-layout>
</gui-page>
```

## Step 7
Lets augment our widget definition by first creating an array of strings, called `widgets`, in our component class.

```typescript
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-debug-page',
  templateUrl: './debug-page.component.html',
  styleUrls: ['./debug-page.component.css']
})
export class DebugPageComponent implements OnInit {
  widgets: string[] = [
    'My Plan ol Widget',
    'Is this really necessary?',
    'How many should I make?'
  ];

  constructor() { }

  ngOnInit() {
  }
}
```

Then, using Angular's `ngFor` directive, we can loop through our `widgets` array and create a widget for each string.

Just use Angular's interpolation `{{widget}}` to display the string as text in the widget.

```html
<gui-page>
  <gui-dashboard-layout>
    <div guiWidgetContainer guiGrid="1 2 3 3">
      <div guiWidgetColumn>
        <div guiWidget class="padding" *ngFor="let widget of widgets">
          {{widget}}
        </div>
      </div>
    </div>
  </gui-dashboard-layout>
</gui-page>
```

Our final widgets should look like the following.

![alt text][demo]

[demo]: assets/3-component.png
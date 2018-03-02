# Directives
`Directives` are the fundamental unit of behavior in the Angular architecture. They allow you to attach functionality to an element in the DOM.

See [Angular's Directive Documentation](https://angular.io/api/core/Directive)

Later, we'll see how to attach a template, or html code, using a `component` which is a implementation of `directive`.

Let's build a directive that will print a message to the console on click events.

## Step 1
We will use the CLI to generate our directive. Open bash or console at the root of the project and execute the following command:

`yarn ng generate directive shared/common/click-debug --export`

If you want to understand the command, read the following, else you can move on.
  - `yarn` - we want to use the project's local Angular CLI package. In our `package.json` we have a script called `ng` which will use the local CLI instead of a globally installed CLI.
  - `ng` - this is Angular CLI's command interface.
  - `generate | g` - generates the following object.
  - `directive | d` - the object to generate is a directive.
  - `shared/common/click-debug` - the destination for the generated object, using the last hash as the name for the file, folder and directive.
  - `--export` - tells the CLI to export the object from the most relatively scoped ngModule which, in this case, is the `common.module.ts`.

## Step 2
Navigate to `src/app/share/common`. You will see a folder `click-debug`, and the `common.module.ts` below it.

Inspect the `common.module.ts`. Notice how the CLI has already imported the new directive. Later, we'll do this manually so we can understand everything.

```typescript
import { NgModule } from '@angular/core';
import { ClickDebugDirective } from './click-debug/click-debug.directive';

@NgModule({
  declarations: [ClickDebugDirective],
  exports: [ClickDebugDirective]
})
export class GreenwayCommonModule { }

```

# Step 3
Navigate into the `click-debug` folder, and open `click-debug.directive.ts`.

When the element that the directive is attached to is clicked, we want to toggle  the css class `u-bold` (a class provided by GUI).

Start by importing the `HostListener` decorator from `@angular/core`, and then create a *private* method called `onDebugClick()` decorated by `HostListener`.

```typescript
import {
  Directive,
  HostListener, // Add me
} from '@angular/core';

@Directive({
  selector: '[appClickDebug]'
})
export class ClickDebugDirective {
  constructor() { }

  @HostListener('click') private onDebugClick() {
    // I'm useless, but not for long...
  }
}
```

The `Host` refers to the element that this directive will be attached to. The `Listener` refers to *listening for events* such as, in our case, the `'click'` event.

# Step 4
In order to safely add classes to our `Host` element, we'll need to use our `ElementRef`, an object that gives us a reference to the actual DOM element, and the `Renderer2` service, a utility for safely manipulating the DOM.

Import them from `@angular/core`, and, using Angular's Dependency Injection, we can place them in the contructor to use them within our directive.

```typescript
import {
  Directive,
  HostListener,
  ElementRef, // Add me
  Renderer2, // Add me
} from '@angular/core';

@Directive({
  selector: '[appClickDebug]'
})
export class ClickDebugDirective {
  constructor(
    private elRef: ElementRef, // Add me
    private renderer: Renderer2, // Add me
  ) { }

  @HostListener('click') private onDebugClick() {
    // I'm useless, but not for long...
  }
}
```

# Step 5
Now we can create a property, `isBoldApplied`, to track the state of the styling.

Using the `Renderer2` reference, we can call `addClass(el, class)`, passing in the `nativeElement` property of our `ElementRef` and the string `u-bold`.

```typescript
import {
  Directive,
  HostListener,
  ElementRef,
  Renderer2
} from '@angular/core';

@Directive({
  selector: '[appClickDebug]'
})
export class ClickDebugDirective {
  private isBoldApplied = false;

  constructor(
    private elRef: ElementRef,
    private renderer: Renderer2
  ) { }

  @HostListener('click') private onDebugClick() {
    if (this.isBoldApplied)
      this.renderer.removeClass(this.elRef.nativeElement, 'u-bold');
    else
      this.renderer.addClass(this.elRef.nativeElement, 'u-bold');

    this.isBoldApplied = !this.isBoldApplied;
  }
}
```

# Step 6
Finally, apply the directive to an element in our app component template.

```html
<!--The content below is only a placeholder and can be replaced.-->
<div class="margin-top" style="text-align:center">
  <img width="400px" src="https://www.greenwayhealth.com/wp-content/themes/greenway_responsive/images/logo.svg">
  <h1 class="margin-top">Welcome to Greenway's Master Class</h1>
</div>

<!-- appClickDebug on this element! -->
<div appClickDebug class="margins" style="margin: 0 auto; width: 600px">
  <p>If you're seeing this page, then you have successfully started the Master Class App. Now we can begin exploring Angular and all the wonderful chaos involved.</p>
</div>
```

You should be able to toggle the text from bold and back by clicking it.

![alt text][demo]

[demo]: assets/1-click-debug.gif

# External Directives
Taking a look at the GUI Library, we have access to dozens of prebuilt Directives and Components. We will use some of them to quickly scaffold out our application's structure.

## Step 1
Lets try using some of the GUI library's directives to add some Greenway styling.

Start by wrapping every thing in the `app.component.html` template into a `guiBody` element.

```html
<!--The content below is only a placeholder and can be replaced.-->
<div guiBody>
  <div class="margin-top" style="text-align:center">
    <img width="400px" src="https://www.greenwayhealth.com/wp-content/themes/greenway_responsive/images/logo.svg">
    <h1 class="margin-top">Welcome to Greenway's Master Class</h1>
  </div>

  <div appClickDebug class="margins" style="margin: 0 auto; width: 600px">
    <p>If you're seeing this page, then you have successfully started the Master Class App. Now we can begin exploring Angular
      and all the wonderful chaos involved.</p>
  </div>
</div>
```

Hopefully, every looks exactly the same as before.

The `guiBody` directive will apply flexible, responsive column styling to any child elements.

## Step 2
We can add Greenway's typical app structure by using the `<gui-root>` element. Furthermore, we can place `guiSidebar`, `guiBanner`, and `guiContent` elements inside of the root.

You can then copy your existing code into the `guiContent` element.

*NOTE: Don't copy and paste the code below, use it as a reference.*
```html
<!--The content below is only a placeholder and can be replaced.-->
<gui-root>
  <div guiSidebar></div>
  <div guiBanner></div>
  <div guiContent>
    <!-- put your guiBody element here, including the stuff inside of it! -->
  </div>
</gui-root>
```

It should look similar to the image below.

![alt text][demo]

[demo]: assets/2-gui-root.png

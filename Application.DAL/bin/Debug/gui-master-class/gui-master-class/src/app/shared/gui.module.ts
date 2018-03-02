import { NgModule } from '@angular/core';

import {
  GuiCommonModule
} from 'greenway-angular-ui';

const GUI_MODULES = [
  GuiCommonModule
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

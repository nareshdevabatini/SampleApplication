import {Component} from "@angular/core";
import { HomeService } from './Services/home.services'
@Component({
    selector: 'home-app',
    templateUrl: './app/home/home.tpl.html'
})
export class AppComponent {
    constructor(private _homeService: HomeService)
    {
        this._homeService.getData().subscribe((data: any) => {
            this.bindData(data)
        })
    }
    bindData: any = (data: any): void => {
        debugger;
    }
}
import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
//import 'rxjs/rxjs'
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class HomeService {
    constructor(private _http: Http) { }
    private _url: string = "api/customers/customer/getall";
    private extractData(res: Response) {
        let body = res.json();
        return body || {};
    }
    private handleError(error: any) {
        console.error(error);
        return Observable.throw(error || "Server Error");
    }
    getData(): Observable<any> {
        
        let personReq = {};
        let body = JSON.stringify(personReq);
        let header = new Headers({ 'content-type': 'application/json' });
        let options = new RequestOptions({ headers: header });
        return this._http.get(this._url).map(this.extractData).catch(this.handleError);
    }
}
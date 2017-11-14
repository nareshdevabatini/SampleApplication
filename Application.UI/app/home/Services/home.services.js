"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var http_1 = require("@angular/http");
//import 'rxjs/rxjs'
var Observable_1 = require("rxjs/Observable");
require("rxjs/add/operator/map");
require("rxjs/add/operator/catch");
var HomeService = /** @class */ (function () {
    function HomeService(_http) {
        this._http = _http;
        this._url = "api/customers/customer/getall";
    }
    HomeService.prototype.extractData = function (res) {
        var body = res.json();
        return body || {};
    };
    HomeService.prototype.handleError = function (error) {
        console.error(error);
        return Observable_1.Observable.throw(error || "Server Error");
    };
    HomeService.prototype.getData = function () {
        var personReq = {};
        var body = JSON.stringify(personReq);
        var header = new http_1.Headers({ 'content-type': 'application/json' });
        var options = new http_1.RequestOptions({ headers: header });
        return this._http.get(this._url).map(this.extractData).catch(this.handleError);
    };
    HomeService = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [http_1.Http])
    ], HomeService);
    return HomeService;
}());
exports.HomeService = HomeService;
//# sourceMappingURL=home.services.js.map
import { __decorate } from "tslib";
import { Component } from '@angular/core';
import { HttpService } from '../http.service';
import { Injectable } from '@angular/core';
let DataService = class DataService {
    constructor(http) {
        this.http = http;
        this.url = "/api/products";
    }
    getProducts() {
        return this.http.get(this.url);
    }
    getProduct(id) {
        return this.http.get(this.url + '/' + id);
    }
    createProduct(product) {
        return this.http.post(this.url, product);
    }
    updateProduct(product) {
        return this.http.put(this.url, product);
    }
    deleteProduct(id) {
        return this.http.delete(this.url + '/' + id);
    }
};
DataService = __decorate([
    Component({
        selector: 'app-store',
        templateUrl: './store.component.html',
        styleUrls: ['./store.component.scss'],
        providers: [HttpService]
    }),
    Injectable()
], DataService);
export { DataService };
//# sourceMappingURL=data.service.js.map
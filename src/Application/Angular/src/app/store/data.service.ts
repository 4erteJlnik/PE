import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Post } from './Post';


@Component({
    selector: 'app-store',
    templateUrl: './store.component.html',
    styleUrls: ['./store.component.scss'],
    providers: [HttpService]
})
@Injectable()
export class DataService {

    private url = "/api/products";

    constructor(private http: HttpClient) {
    }

    getProducts() {
        return this.http.get(this.url);
    }

    getProduct(id: number) {
        return this.http.get(this.url + '/' + id);
    }

    createProduct(product: Post) {
        return this.http.post(this.url, product);
    }
    updateProduct(product: Post) {

        return this.http.put(this.url, product);
    }
    deleteProduct(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}
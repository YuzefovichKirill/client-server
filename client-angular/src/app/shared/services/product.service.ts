import { Injectable } from '@angular/core';
import { Product, ProductCreate } from '../models';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class ProductService {

    readonly baseUrl: string = environment.apiUrl + 'api/Product/'

    constructor(private http: HttpClient) {}

    getProductList(): Observable<Product[]> {
        return this.http.get<Product[]>(this.baseUrl)
    }

    getProduct(id: string): Observable<Product> {
        return this.http.get<Product>(this.baseUrl + id)
    }

    postProduct(productCreate: ProductCreate): Observable<ProductCreate> {
        return this.http.post<ProductCreate>(this.baseUrl, productCreate)
    }

    putProduct(product: Product): Observable<Product> {
        return this.http.put<Product>(this.baseUrl, product)
    }

    deleteProduct(id: string): Observable<Product> {
        return this.http.delete<Product>(this.baseUrl + id)
    }
}

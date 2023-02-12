import { Injectable } from '@angular/core';
import { FridgeProduct, FridgeProductCreate } from '../models';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class FridgeProductService {

    readonly baseUrl: string = environment.apiUrl + 'api/FridgeProduct/'

    constructor(private http: HttpClient) {}

    getFridgeProductList(fridgeId: string): Observable<FridgeProduct[]> {
        return this.http.get<FridgeProduct[]>(this.baseUrl + fridgeId)
    }

    getFridgeProduct(fridgeId: string, productId: string): Observable<FridgeProduct> {
        return this.http.get<FridgeProduct>(this.baseUrl + fridgeId + '&' + productId)
    }

    postFridgeProduct(fridgeProductCreate: FridgeProductCreate): Observable<FridgeProductCreate> {
        return this.http.post<FridgeProductCreate>(this.baseUrl, fridgeProductCreate)
    }

    putFridgeProduct(fridgeProduct: FridgeProduct): Observable<FridgeProduct> {
        return this.http.put<FridgeProduct>(this.baseUrl, fridgeProduct)
    }

    deleteFridgeProduct(id: string): Observable<FridgeProduct> {
        return this.http.delete<FridgeProduct>(this.baseUrl + id)
    }
}
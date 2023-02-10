import { Injectable } from '@angular/core';
import { Fridge, FridgeCreate } from '../models';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class FridgeService {

    readonly baseUrl: string = environment.apiUrl + 'api/Fridge/'

    constructor(private http: HttpClient) {}

    getFridgeList(): Observable<Fridge[]> {
        return this.http.get<Fridge[]>(this.baseUrl)
    }

    getFridge(id: string): Observable<Fridge> {
        return this.http.get<Fridge>(this.baseUrl + id)
    }

    postFridge(fridgeModelCreate: FridgeCreate): Observable<FridgeCreate> {
        return this.http.post<FridgeCreate>(this.baseUrl, fridgeModelCreate)
    }

    putFridge(fridgeModel: Fridge): Observable<Fridge> {
        return this.http.put<Fridge>(this.baseUrl, fridgeModel)
    }

    deleteFridge(id: string): Observable<Fridge> {
         return this.http.delete<Fridge>(this.baseUrl + id)
    }
}
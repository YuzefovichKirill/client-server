import { Injectable } from '@angular/core';
import { FridgeModel, FridgeModelCreate } from '../models';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class FridgeModelService {

    readonly baseUrl: string = environment.apiUrl + 'api/FridgeModel/'

    constructor(private http: HttpClient) {}

    getFridgeModelList(): Observable<FridgeModel[]> {
        return this.http.get<FridgeModel[]>(this.baseUrl)
    }

    getFridgeModel(id: string): Observable<FridgeModel> {
        return this.http.get<FridgeModel>(this.baseUrl + id)
    }

    postFridgeModel(fridgeModelCreate: FridgeModelCreate): Observable<FridgeModelCreate> {
        return this.http.post<FridgeModelCreate>(this.baseUrl, fridgeModelCreate)
    }

    putFridgeModel(fridgeModel: FridgeModel): Observable<FridgeModel> {
        return this.http.put<FridgeModel>(this.baseUrl, fridgeModel)
    }

    deleteFridgeModel(id: string): Observable<FridgeModel> {
        return this.http.delete<FridgeModel>(this.baseUrl + id)
    }
}

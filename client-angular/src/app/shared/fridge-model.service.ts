import { Injectable } from '@angular/core';
import { FridgeModel } from './fridge-model.model';
import { HttpClient } from "@angular/common/http";

@Injectable({
    providedIn: 'root'
})
export class FridgeModelService {

    readonly baseUrl = 'api/FridgeModel'
    formData: FridgeModel = new FridgeModel();
    list: FridgeModel[] = [];

    constructor(private http: HttpClient) {}

    getFridgeModelList() {
        this.http.get('${config.apiUrl}' + this.baseUrl)
            .toPromise().then(res => this.list = res as FridgeModel[]);
    }

    getFridgeModel(id: string) {
        this.http.get('${config.apiUrl}' + this.baseUrl + '/{id}')
    }

    postFridgeModel() {
        return this.http.post('${config.apiUrl}' + this.baseUrl, this.formData);
    }

    patchFridgeModel() {
        return this.http.patch('${config.apiUrl}' + this.baseUrl, this.formData)
    }

    deleteFridgeModel(id: string) {
         return this.http.delete('${config.apiUrl}' + this.baseUrl + '/{id}')
    }

}
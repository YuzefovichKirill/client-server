import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FridgeProduct } from '../../../shared/models';
import { FridgeProductService } from '../../../shared/services/fridge-product.service';

@Component({
  selector: 'app-fridge-product-edit',
  templateUrl: './fridge-product-edit.component.html',
  styleUrls: ['./fridge-product-edit.component.css']
})
export class FridgeProductEditComponent implements OnInit {

  fridgeProduct: FridgeProduct = {
    id: '',
    fridgeId: '',
    productId: '',
    quantity: 0
  }

  constructor(private route: ActivatedRoute,
              private fridgeProductService: FridgeProductService,
              private router: Router,
              private location: Location) { }

  ngOnInit() {
    this.route.paramMap.subscribe({
      next: (params) => {
        const fridgeId = params.get('fridgeId')
        const productId = params.get('productId')

        if(fridgeId && productId) {
          this.fridgeProductService.getFridgeProduct(fridgeId, productId)
            .subscribe({
              next: (response) => {
                this.fridgeProduct = response
              }
            })
        }
      }
    })
  }

  editFridgeProduct() {
    this.fridgeProductService.putFridgeProduct(this.fridgeProduct)
      .subscribe({
        next: (response) => {
          this.location.back()
        }
      })
  }
}

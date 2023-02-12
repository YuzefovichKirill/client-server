import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FridgeProductCreate } from '../../../shared/models';
import { FridgeProductService } from '../../../shared/services/fridge-product.service';

@Component({
  selector: 'app-fridge-product-create',
  templateUrl: './fridge-product-create.component.html',
  styleUrls: ['./fridge-product-create.component.css']
})
export class FridgeProductCreateComponent implements OnInit {

  fridgeProductCreate: FridgeProductCreate = {
    fridgeId: '',
    productId: '',
    quantity: 1
  }

  constructor(private route: ActivatedRoute,
              private fridgeProductService: FridgeProductService,
              private router: Router,
              private location: Location) { }

  ngOnInit() {
    this.route.paramMap.subscribe({
      next: (params) => {
        const fridgeId = params.get('fridgeId')

        if (fridgeId) {
          this.fridgeProductCreate.fridgeId = fridgeId
        }
      }
    })
  }

  createFridgeProduct() {
    this.fridgeProductService.postFridgeProduct(this.fridgeProductCreate)
      .subscribe({
        next: (fridgeProductGuid) => {
          this.location.back()
          //this.router.navigate(['../../../product', this.fridgeProductCreate.fridgeId])
        }
      })
  }
}

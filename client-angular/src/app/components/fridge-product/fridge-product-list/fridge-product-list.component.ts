import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FridgeProduct } from '../../../shared/models';
import { FridgeProductService } from '../../../shared/services/fridge-product.service';

@Component({
  selector: 'app-fridge-product-list',
  templateUrl: './fridge-product-list.component.html',
  styleUrls: ['./fridge-product-list.component.css']
})
export class FridgeProductListComponent implements OnInit {

  fridgeId: string = ''
  fridgeProducts: FridgeProduct[] = [];

  constructor(private route: ActivatedRoute,
              private fridgeProductService: FridgeProductService,
              private router: Router) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const fridgeId = params.get('fridgeId')

        if (fridgeId) {
          this.fridgeId = fridgeId

          this.fridgeProductService.getFridgeProductList(fridgeId)
            .subscribe({
              next: (response) => {
                this.fridgeProducts = response
              }
            })
        }
      }
    })
  }

  deleteFridgeProduct(id: string, fridgeId: string) {
    if (confirm('Are you sure to delete this record?'))
    {
      this.fridgeProductService.deleteFridgeProduct(id)
        .subscribe()

      this.fridgeProductService.getFridgeProductList(fridgeId)
        .subscribe({
          next: (fridgeProducts) => {
            this.fridgeProducts = fridgeProducts
          },
          error: (response) => {
            console.log(response)
          }
        });

      window.location.reload();
    }
  }
}

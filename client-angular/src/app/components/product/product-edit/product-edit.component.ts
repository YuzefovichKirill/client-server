import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../../../shared/models';
import { ProductService } from '../../../shared/services/product.service';

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html',
  styleUrls: ['./product-edit.component.css']
})
export class ProductEditComponent implements OnInit {

  product: Product = {
    id: '',
    name: '',
    defaultQuantity: 0
  }
  constructor(private route: ActivatedRoute, 
              private productService: ProductService,
              private router: Router) { }

  ngOnInit() {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id')

        if (id) {
          this.productService.getProduct(id)
            .subscribe({
              next: (response) => {
                this.product = response
              }
            })
        } 
      }
    })
  }

  editProduct() {
    this.productService.putProduct(this.product)
      .subscribe({
        next: (response) => {
          this.router.navigate(['product'])
        }
      })
  }
}

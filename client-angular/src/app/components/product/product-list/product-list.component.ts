import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from '../../../shared/models';
import { ProductService } from '../../../shared/services/product.service'

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  products: Product[] = [];
  constructor(private productService: ProductService,
              private router: Router) { }

  ngOnInit(): void {
    this.productService.getProductList()
      .subscribe({
        next: (products) => {
          this.products = products
        },
        error: (response) => {
          console.log(response)
        }
      })
  }

  deleteProduct(id:string) {
    if(confirm('Are you sure to delete this record?'))
    {
      this.productService.deleteProduct(id)
        .subscribe({
          next: (res) => {
            console.log(res)
          }
        })


      this.productService.getProductList()
        .subscribe({
          next: (products) => {
            
            this.products = products
            this.router.navigate(['product'])
          },
          error: (response) => {
            console.log(response)
          }
        })

      window.location.reload()       
    }
  }
}

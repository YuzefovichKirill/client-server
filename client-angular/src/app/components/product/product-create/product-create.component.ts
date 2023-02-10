import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProductCreate } from '../../../shared/models';
import { ProductService } from '../../../shared/services/product.service';

@Component({
  selector: 'app-product-create',
  templateUrl: './product-create.component.html',
  styleUrls: ['./product-create.component.css']
})
export class ProductCreateComponent implements OnInit {

  productCreate: ProductCreate = {
    name: '',
    defaultQuantity: 0
  }

  constructor(private productService: ProductService,
              private router: Router) { }

  ngOnInit() {
  }

  createProduct() {
    this.productService.postProduct(this.productCreate)
      .subscribe({
        next: (productGuid) => {
          this.router.navigate(['product'])
        }
      })
  }

}

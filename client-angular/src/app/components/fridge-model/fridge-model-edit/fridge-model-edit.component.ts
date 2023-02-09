import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FridgeModel } from '../../../shared/models';
import { FridgeModelService } from '../../../shared/services/fridge-model.service';

@Component({
  selector: 'app-fridge-model-edit',
  templateUrl: './fridge-model-edit.component.html',
  styleUrls: ['./fridge-model-edit.component.css']
})
export class FridgeModelEditComponent implements OnInit {

  fridgeModel: FridgeModel= {
    id: '',
    name: '',
    year: 0
  };

  constructor(private route: ActivatedRoute, 
              private fridgeModelService: FridgeModelService,
              private router: Router) { }

  ngOnInit() {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id')

        if (id) {
          this.fridgeModelService.getFridgeModel(id)
            .subscribe({
              next: (responce) => {
                this.fridgeModel = responce
              }
            })
        }
      }
    })
  }

  editFridgeModel() {
    this.fridgeModelService.putFridgeModel(this.fridgeModel)
      .subscribe({
        next: (response) => {
          this.router.navigate(['fridge-model'])
        }
      })
  }

}

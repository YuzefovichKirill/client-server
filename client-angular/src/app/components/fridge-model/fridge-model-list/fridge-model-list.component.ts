import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FridgeModel } from '../../../shared/models/fridge-model/fridge-model.model';
import { FridgeModelService } from '../../../shared/services/fridge-model.service';

@Component({
  selector: 'app-fridge-model-list',
  templateUrl: './fridge-model-list.component.html',
  styleUrls: ['./fridge-model-list.component.css']
})
export class FridgeModelListComponent implements OnInit {

  fridgeModels: FridgeModel[] = [];
  constructor(private fridgeModelService: FridgeModelService,
              private router: Router) { }

  ngOnInit(): void {
    this.fridgeModelService.getFridgeModelList()
      .subscribe({
        next: (fridgeModels) => {
          this.fridgeModels = fridgeModels
        },
        error: (response) => {
          console.log(response)
        }
      })
  }

  deleteFridgeModel(id:string) {
    if(confirm('Are you sure to delete this record?'))
    {
      this.fridgeModelService.deleteFridgeModel(id)
      .subscribe({
        next: () => {
          
        }
      })

      this.fridgeModelService.getFridgeModelList()
      .subscribe({
        next: (fridgeModels) => {
          this.fridgeModels = fridgeModels
          this.router.navigate(['/fridge-model'])
        },
        error: (response) => {
          console.log(response)
        }
      })

      window.location.reload();
    }


  }

}

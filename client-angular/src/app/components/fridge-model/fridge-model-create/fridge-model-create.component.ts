import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FridgeModelCreate } from '../../../shared/models';
import { FridgeModelService } from '../../../shared/services/fridge-model.service';

@Component({
  selector: 'app-fridge-model-create',
  templateUrl: './fridge-model-create.component.html',
  styleUrls: ['./fridge-model-create.component.css']
})
export class FridgeModelCreateComponent implements OnInit {

  fridgeModelCreate: FridgeModelCreate = {
    name: '',
    year: 0
  };

  constructor(private fridgeModelService: FridgeModelService,
              private router: Router) { }

  ngOnInit() {
  }

  createFridgeModel() {
    this.fridgeModelService.postFridgeModel(this.fridgeModelCreate)
      .subscribe({
        next: (fridgeModelGuid) => {
          //console.log(fridgeModelGuid)
          this.router.navigate(['/fridge-model']);
        }
      })
  }
}

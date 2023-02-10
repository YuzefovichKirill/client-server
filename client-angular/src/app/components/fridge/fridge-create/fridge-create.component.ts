import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FridgeCreate } from '../../../shared/models';
import { FridgeService } from '../../../shared/services/fridge.service';

@Component({
  selector: 'app-fridge-create',
  templateUrl: './fridge-create.component.html',
  styleUrls: ['./fridge-create.component.css']
})
export class FridgeCreateComponent implements OnInit {

fridgeCreate: FridgeCreate = {
  name: '',
  ownerName: '',
  fridgeModelId: ''
}

  constructor(private fridgeService: FridgeService,
              private router: Router) { }

  ngOnInit() {
  }


  createFridge() {
    this.fridgeService.postFridge(this.fridgeCreate)
      .subscribe({
        next: (fridgeGuid) => {
          this.router.navigate(['fridge']);
        }
      })
  }
}

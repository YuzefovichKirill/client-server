import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Fridge } from '../../../shared/models';
import { FridgeService } from '../../../shared/services/fridge.service';

@Component({
  selector: 'app-fridge-edit',
  templateUrl: './fridge-edit.component.html',
  styleUrls: ['./fridge-edit.component.css']
})
export class FridgeEditComponent implements OnInit {

  fridge: Fridge = {
    id: '',
    name: '',
    ownerName: '',
    fridgeModelId: ''
  }

  constructor(private route: ActivatedRoute,
              private fridgeService: FridgeService,
              private router: Router) { }

  ngOnInit() {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id')

        if(id) {
          this.fridgeService.getFridge(id)
            .subscribe({
              next: (responce) => {
                this.fridge = responce
              }
            })
        }
      }
    })
  }

  editFridge() {
    this.fridgeService.putFridge(this.fridge)
      .subscribe({
        next: (response) => {
          this.router.navigate(['fridge'])
        }
      })
  }
}

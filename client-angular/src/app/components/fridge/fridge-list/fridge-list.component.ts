import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Fridge } from '../../../shared/models';
import { FridgeService } from '../../../shared/services/fridge.service';

@Component({
  selector: 'app-fridge-list',
  templateUrl: './fridge-list.component.html',
  styleUrls: ['./fridge-list.component.css']
})
export class FridgeListComponent implements OnInit {

  fridges: Fridge[] = [];
  constructor(private fridgeService: FridgeService,
              private router: Router) { }

  ngOnInit(): void {
    this.fridgeService.getFridgeList()
      .subscribe({
        next: (fridges) => {
          this.fridges = fridges
        }
      })
  }

deleteFridge(id:string) {
  if(confirm('Are you sure to delete this record?'))
  {
    this.fridgeService.deleteFridge(id)
      .subscribe()

    this.fridgeService.getFridgeList()
      .subscribe({
        next: (fridges) => {
          this.fridges = fridges
          this.router.navigate(['fridge'])
        },
        error: (response) => {
          console.log(response)
        }
      })

      window.location.reload()
  }
}

}

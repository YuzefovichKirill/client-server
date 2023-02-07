import { Component } from '@angular/core';

interface Book {
  id: number
  name: string
  genre: string
  isFree: boolean
  isStylish: boolean
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'client-angular';

  books: Book[] = [{
    id: 1,
    name: "book1",
    genre: "detective",
    isFree: true,
    isStylish: false
  },
  {
    id: 2,
    name: "book2",
    genre: "drama",
    isFree: false,
    isStylish: true
  },
  {
    id: 3,
    name: "book3",
    genre: "fantasy",
    isFree: true,
    isStylish: true
}]

  constructor() {}

  handleChange(event: any) {
    this.title = event?.target.value
  }
}

import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { LibraryService } from './services/library.service';
import { Book, Genre } from './models/book.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HttpClientModule, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'AngularFront';
  http = inject(HttpClient);
  libraryService = inject(LibraryService);

  books: Book[] = [];
  book: Book ={
    id: 0,
    title: '',
    author:'',
    description:'',
    publishedYear: 0,
    isAvailable: false,
    genre:Genre.Children,
};
  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.getAllBooks();
  }


  getAllBooks() {
   this.libraryService.getAllBooks().subscribe(response => {this.books = response});
  }

  getsingelbook(id:number){
    this.libraryService.getOneBook(id).subscribe(
      response=> {
        this.book = response});
      }

}

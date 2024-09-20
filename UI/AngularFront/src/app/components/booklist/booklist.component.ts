import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { LibraryService } from '../../services/library.service';
import { BookDto} from '../../models/bookDto';
import { Router, RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Genre } from '../../models/genre.enum';

@Component({
  selector: 'app-booklist',
  standalone: true,
  imports: [HttpClientModule, RouterOutlet, CommonModule],
  templateUrl: './booklist.component.html',
  styleUrl: './booklist.component.css'
})
export class BooklistComponent {
 http = inject(HttpClient);
  libraryService = inject(LibraryService);
  router= inject(Router);
  books: BookDto[] = [];
  book: BookDto ={
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
    console.log(id);
    this.router.navigateByUrl('/details/'+ id);
      }

      deleteBook(id:number){
        console.log(id);
        this.libraryService.deleteBook(id).subscribe(
         response => this.getAllBooks()
        );
      }
      goedit(id:number){
        console.log(id);
        this.router.navigateByUrl('/edit/'+id);
      }
}

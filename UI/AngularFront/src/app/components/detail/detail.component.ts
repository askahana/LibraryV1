import { Component, Inject, inject } from '@angular/core';
import { BookDto} from '../../models/bookDto';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { LibraryService } from '../../services/library.service';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { Genre } from '../../models/genre.enum';

@Component({
  selector: 'app-detail',
  standalone: true,
  imports: [HttpClientModule, CommonModule],
  templateUrl: './detail.component.html',
  styleUrl: './detail.component.css'
})
export class DetailComponent {
 
  bookId! :number;
  image: string = ''; 

  http = inject(HttpClient)
  libraryService = inject(LibraryService)
  route= inject(ActivatedRoute)

  book: BookDto ={
    id: 0,
    title: '',
    author:'',
    description:'',
    publishedYear: 0,
    isAvailable: false,
    genre:Genre.Comedy,
};



ngOnInit(): void {
  //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
  //Add 'implements OnInit' to the class.
 this.bookId = this.route.snapshot.params['id'];
 if(this.bookId){
  this.getSingelBook(this.bookId);
 }
 
}


getSingelBook(id:number) {
  this.libraryService.getOneBook(id).subscribe(response => 
    {this.book = response
     /* if(!`assets/images/book${id}.jpg`){
        this.image = 'assets/images/no-image.png' ;
      }
      this.image = `assets/images/book${id}.jpg`;*/
      this.image = id ? `assets/images/book${id}.jpg` : 'assets/images/no-image.png';
     
      // <img [src]="`assets/images/book${id}.jpg`" (error)="this.src='assets/images/no-image.png'" alt="Book Image">
      // this.image = `assets/images/book${id}.jpg`;
      console.log(this.book.genre);
  });
 }

 getGenre():string{
  return this.genreToString(this.book.genre);
 }



 private genreToString(genre: Genre): string {
  switch (genre) {
    case Genre.Mystery:
      return 'Mystery';
    case Genre.Fantasy:
      return 'Fantasy';
    case Genre.Horror:
      return 'Horror';
    case Genre.Romance:
      return 'Romance';
    case Genre.ScienceFiction:
      return 'SF';
    case Genre.Classics:
      return 'Classics';
    case Genre.Children:
      return 'Children';
    case Genre.Comedy:
      return 'Comedy';
    default:
      return 'Unknown';
  }
 }


}

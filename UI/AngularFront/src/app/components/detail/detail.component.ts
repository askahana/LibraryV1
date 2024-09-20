import { Component, Inject, inject } from '@angular/core';
import { BookDto} from '../../models/bookDto';
import {  HttpClientModule } from '@angular/common/http';
import { LibraryService } from '../../services/library.service';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { Genre } from '../../models/genre.enum';

@Component({
  selector: 'app-detail',
  standalone: true,
  imports: [HttpClientModule, CommonModule, RouterLink],
  templateUrl: './detail.component.html',
  styleUrl: './detail.component.css'
})
export class DetailComponent {
 
  bookId! :number;
  image: string = ''; 
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
   
      this.image = id ? `assets/images/book${id}.jpg` : 'assets/images/no-image.png';
     
      console.log(this.book.genre);
  });
 }



 onImageError(event:any){
  event.target.src = '/assets/images/no-image.png'; 
 }

 
 }




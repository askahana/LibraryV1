import { Component, inject } from '@angular/core';
import { LibraryService } from '../../services/library.service';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Genre, GenreValues } from '../../models/genre.enum';
import { BookDto } from '../../models/bookDto';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-edit',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, RouterLink],
  templateUrl: './edit.component.html',
  styleUrl: './edit.component.css'
})
export class EditComponent {
  libraryService = inject(LibraryService);
  formBuilder = inject(FormBuilder);
  bookId! :number;
  router = inject(Router);
  route = inject(ActivatedRoute)
  
 
  book: BookDto = {
    id: 0,
    title: '',
    author:'',
    description:'',
    publishedYear: 0,
    isAvailable: false,
    genre:Genre.Comedy,
  }


  editForm = this.formBuilder.group({
    id:[this.book.id],
    title: ['', [Validators.required]],
    author:['', [Validators.required]],
    description:['', [Validators.required]],
    publishedYear: [0, [Validators.required]],
    isAvailable: [false],
    genre:[Genre.Children, [Validators.required]]
  });
  genreOptions = GenreValues;

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.bookId = this.route.snapshot.params['id'];
    this.getSingleBook(this.bookId);
  }

  getSingleBook(id:number){
    this.libraryService.getOneBook(id).subscribe(response =>{
      this.book = response
      console.log(response)
      console.log(this.book.genre);
      this.editForm.patchValue(this.book);
    }
    )};

    

    onSubmit(){
      console.log(this.editForm.value);
      const newBook:BookDto = {
        id:this.book.id,
        title: this.editForm.value.title!,
        author:this.editForm.value.author!,
        publishedYear:this.editForm.value.publishedYear!,
        genre: this.editForm.value.genre!,
        description: this.editForm.value.description!,
        isAvailable: this.editForm.value.isAvailable ?? false,
      };
      
      this.libraryService.uppdateBook(newBook).subscribe(response =>{
        this.router.navigateByUrl('/booklist');
        console.log(this.editForm.value);
      })
    };

}

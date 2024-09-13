import { Component, inject } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { LibraryService } from '../../services/library.service';
import { ActivatedRoute, Router } from '@angular/router';
import { BookDto} from '../../models/bookDto';
import { Genre } from '../../models/genre.enum';
import { BookCreateDto } from '../../models/bookCreateDto';

@Component({
  selector: 'app-bookform',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule],
  templateUrl: './bookform.component.html',
  styleUrl: './bookform.component.css'
})
export class BookformComponent {
  libraryService = inject(LibraryService);
  router = inject(Router);
  formBuilder= inject(FormBuilder);
  route= inject(ActivatedRoute)
 
  isEdit = false;

  registerForm = this.formBuilder.group({
    title: ['', [Validators.required]],
    author:['', [Validators.required]],
    description:['', [Validators.required]],
    publishedYear: [0, [Validators.required]],
    isAvailable: [false],
    genre:[0, [Validators.required]]
  })


  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    
  this.registerForm = this.formBuilder.group({
    title: ['', [Validators.required]],
    author:['', [Validators.required]],
    description:['', [Validators.required]],
    publishedYear: [0, [Validators.required]],
    isAvailable: [false],
    genre:[0, [Validators.required]]
  })
  }

  onSubmit(){
    console.log(this.registerForm.value);
    const newBook:BookCreateDto = {
     
      title: this.registerForm.value.title!,
      author:this.registerForm.value.author!,
      publishedYear:this.registerForm.value.publishedYear!,
      genre: this.registerForm.value.genre!,
      description: this.registerForm.value.description!,
      isAvailable: this.registerForm.value.isAvailable ?? false,
    };

    this.libraryService.addNewBook(newBook).subscribe(
      response => {
        this.router.navigateByUrl('/booklist');
      }
    );

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

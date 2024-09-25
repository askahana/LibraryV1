import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { LibraryService } from '../../services/library.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Genre, GenreValues } from '../../models/genre.enum';
import { BookCreateDto } from '../../models/bookCreateDto';


@Component({
  selector: 'app-register',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  libraryService = inject(LibraryService);
  router = inject(Router);
  formBuilder= inject(FormBuilder);
  route= inject(ActivatedRoute)

  registerForm = this.formBuilder.group({
    title: ['', [Validators.required]],
    author:['', [Validators.required]],
    description:['', [Validators.required]],
    publishedYear: [0, [Validators.required]],
    isAvailable: [false],
    genre:[Genre.Uncategorized, [Validators.required]]
  })

  genreOptions = GenreValues;

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
        console.log(this.registerForm.value);
        this.router.navigateByUrl('/booklist');
      }
    );
}

}
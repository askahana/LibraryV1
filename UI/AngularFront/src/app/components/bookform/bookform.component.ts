import { Component,  } from '@angular/core';
import {  FormsModule, ReactiveFormsModule} from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RegisterComponent } from "../register/register.component";
import { DetailComponent } from "../detail/detail.component";
import { EditComponent } from "../edit/edit.component";

@Component({
  selector: 'app-bookform',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule, CommonModule, RegisterComponent, DetailComponent, EditComponent],
  templateUrl: './bookform.component.html',
  styleUrl: './bookform.component.css'
})
export class BookformComponent {

  isEdit = false;
  
}

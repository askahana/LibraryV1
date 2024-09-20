import { Routes } from '@angular/router';
import { BooklistComponent } from './components/booklist/booklist.component';
import { DetailComponent } from './components/detail/detail.component';
import { HomeComponent } from './components/home/home.component';
import { BookformComponent } from './components/bookform/bookform.component';
import { RegisterComponent } from './components/register/register.component';
import { EditComponent } from './components/edit/edit.component';


export const routes: Routes = [
 {
path: '',
component: HomeComponent
 }, 

    {
        path:'booklist',
        component: BooklistComponent
    },
    {
        path: 'details/:id',
        component: DetailComponent
    },
    {
        path: 'form',
        component: BookformComponent
    },
 
    {
        path:'edit/:id',
        component:EditComponent
    },
    {
        path:'register',
        component:RegisterComponent
    }
   




];

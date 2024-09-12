import { Routes } from '@angular/router';
import { BooklistComponent } from './components/booklist/booklist.component';
import { DetailComponent } from './components/detail/detail.component';
import { HomeComponent } from './components/home/home.component';

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
    }





];


import { inject, Inject, Injectable } from "@angular/core";
import { Book, Genre } from "../models/book.model";
import { map, Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { ApiResponse } from "../models/apiResponse";
import { BookDto } from "../models/bookDto";


@Injectable({
    providedIn: 'root'
})

export class LibraryService{
    constructor(){}
    http = inject(HttpClient);
    baseUrl = 'https://localhost:7157/api/books';
    
   
    // Get APIReponse.
   /* getAllBooks():Observable<ApiResponse>{
        return this.http.get<ApiResponse>(this.baseUrl);
    }

    // get result from APIResponse!
    getBooks(): Observable<Book[]> {
        return this.getAllBooks().pipe(
            map((response: ApiResponse) => response.result as Book[])
        );
    }*/

    getAllBooks():Observable<BookDto[]>{
        return this.http.get<ApiResponse>(this.baseUrl).pipe(
            map((response:ApiResponse) => response.result as BookDto[])
        )
    }

    // get one singel book
    getOneBook(id:number):Observable<Book>{
        return this.http.get<ApiResponse>(this.baseUrl + '/' + id).pipe(
            map((response:ApiResponse) => response.result as Book)
        )
    }

    
  
    // update
    uppdateBook(book: Book): Observable<Book>{
        return this.http.put<Book>(this.baseUrl + '/' + book.id, book);
    }

    //add new, Create
    addNewBook(book:Book): Observable<Book>{
        return this.http.post<Book>(this.baseUrl, book);
    }

    // Delete
    deleteBook(id:number):Observable<Book>{
        return this.http.delete<Book>(this.baseUrl + '/' + id);
    }

}

import { inject, Inject, Injectable } from "@angular/core";

import { map, Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { ApiResponse } from "../models/apiResponse";
import { BookDto } from "../models/bookDto";
import { BookCreateDto } from "../models/bookCreateDto";


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

        //Observable <Book> is return type
    getAllBooks():Observable<BookDto[]>{
        return this.http.get<ApiResponse>(this.baseUrl).pipe(
            map((response:ApiResponse) => response.result as BookDto[])
        )
    }

    // get one singel book
    getOneBook(id:number):Observable<BookDto>{
        return this.http.get<ApiResponse>(this.baseUrl + '/' + id).pipe(
            map((response:ApiResponse) => response.result as BookDto)
        )
    }
// Delete
    deleteBook(id:number):Observable<BookDto>{
    return this.http.delete<ApiResponse>(this.baseUrl + '/' + id).pipe(
        map((response:ApiResponse) => response.result as BookDto)
    )
}
    
  
    // update
    uppdateBook(book: BookDto): Observable<BookDto>{
        return this.http.put<ApiResponse>(this.baseUrl + '/' + book.id, book).pipe(
            map((response: ApiResponse) =>
            response.result as BookDto)
        );
    }

    //add new, Create
    addNewBook(book:BookCreateDto): Observable<BookCreateDto>{
        return this.http.post<ApiResponse>(this.baseUrl, book).pipe(
            map((response: ApiResponse) =>
            response.result as BookCreateDto)
        );
    }

    

}
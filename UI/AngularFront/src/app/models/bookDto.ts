import { Genre } from "./genre.enum";

export interface BookDto{
    id: number;
    title: string;
    author:string;
    description:string;
    publishedYear: number;
    isAvailable: boolean;
    genre:Genre;
}


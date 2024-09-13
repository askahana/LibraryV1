import { Genre } from "./genre.enum";

export interface BookCreateDto{
    title: string;
    author:string;
    description:string;
    publishedYear: number;
    isAvailable: boolean;
    genre:Genre;
}


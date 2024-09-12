export interface Book{
    id: number;
    title: string;
    author:string;
    description:string;
    publishedYear: number;
    isAvailable: boolean;
    genre:Genre;
}

export enum Genre {
    Mystery = 'Mystery',
    Fantasy = 'Fantasy',
    Horror = 'Horrar',
    Romance = 'Romance',
    ScienceFiction = 'ScienceFiction',
    Classics = 'Classics',
    Children = 'Children',
    Comedy = 'Comedy'
}
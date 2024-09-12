import { Book } from "./book.model";

export interface ApiResponse{
    result: object;
    isSuccess: boolean;
    httpstatucCode: number;
    errorMessage: string[]    
}
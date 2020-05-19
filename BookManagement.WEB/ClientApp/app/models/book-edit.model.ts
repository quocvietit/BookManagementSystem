import { Author } from "./author.model";
import { Category } from "./category.model";
import { Publisher } from "./publisher.model";

export class BookEdit {
    constructor(values: Object = {}) {
        Object.assign(this, values);
    }

    public bookId: number;
    public title: string;
    public imgUrl: string;
    public summary: string;
    public price: number;
    public quantity: number
    public isActive: number;
    public authorId: number;
    public cateId: number;
    public pubId: number; 
}
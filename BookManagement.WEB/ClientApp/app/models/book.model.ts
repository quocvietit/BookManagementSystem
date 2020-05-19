export class Book {
    constructor(values: Object = {}) {
        Object.assign(this, values);
    }

    public bookId: number;
    public title: string;
    public imgUrl: string;
    public price: number;
    public quantity: number
    public isActive: boolean;
}
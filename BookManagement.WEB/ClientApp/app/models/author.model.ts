export class Author {
    constructor(values: Object = {}) {
        Object.assign(this, values);
    }

    public authorId: number;
    public authorName: string;
    public history: string;
}
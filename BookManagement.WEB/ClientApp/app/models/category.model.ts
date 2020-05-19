export class Category {
    constructor(values: Object = {}) {
        Object.assign(this, values);
    }

    public cateId: number;
    public cateName: string;
    public description: string;  
}
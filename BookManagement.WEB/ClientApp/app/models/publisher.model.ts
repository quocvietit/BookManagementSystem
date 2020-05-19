export class Publisher {
    constructor(values: Object = {}) {
        Object.assign(this, values);
    }

    public pubId: number;
    public name: string;
    public description: string;
}
import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';

import { Category } from './../models/category.model';
import { Utilities } from './utilities';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';



@Injectable()
export class CategoryService {

    private url = Utilities.baseUrl() + '/api/category';

    constructor(private http: Http) { }

    getCategories(){
        return this.http.get(this.url)
            .map(res => res.json());
    }

    getCategory(id: number) {
        return this.http.get(this.getUrl(id))
            .map(res => res.json());
    }

    addCategory(category: Category) {
        return this.http.post(this.url, category)
            .map(res => res.json());
    }

    updateCategory(category: Category) {
        return this.http.put(this.url, category)
            .map(res => res.json());
    }

    deleteCategory(id: number) {
        return this.http.delete(this.getUrl(id))
            .map(res => res.json());
    }

    private getUrl(id: number) {
        return this.url + '/' + id;
    }
}

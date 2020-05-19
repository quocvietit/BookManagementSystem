import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';

import { Book } from './../models/book.model';
import { Utilities } from './utilities';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import { BookEdit } from '../models/book-edit.model';



@Injectable()
export class BookService {

    private url = Utilities.baseUrl() + '/api/book';

    private getUrl(id: number) { return this.url + '/' + id; }
    private getUrlBookDetail(id: number) { return this.url+'/detail'+'/'+id}

    constructor(private http: Http) { }

    getBooks() {
        return this.http.get(this.url)
            .map(res => res.json());
    }

    getBook(id: number) {
        return this.http.get(this.getUrl(id))
            .map(res => res.json());
    }

    getBookDetail(id: number) {
        return this.http.get(this.getUrlBookDetail(id))
            .map(res => res.json())
    }

    addBook(bookEdit: BookEdit) {
        console.log(bookEdit)
        return this.http.post(this.url, bookEdit)
            .map(res => res.json());
    }

    updateBook(bookEdit: BookEdit) {
        return this.http.put(this.url, bookEdit)
            .map(res => res.json());
    }

    deleteBook(id: number) {
        return this.http.delete(this.getUrl(id))
            .map(res => res.json());
    }
}

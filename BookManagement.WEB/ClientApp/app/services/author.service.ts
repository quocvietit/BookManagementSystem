import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';

import { Author } from './../models/author.model';
import { Utilities } from './utilities';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';



@Injectable()
export class AuthorService {

    private url = Utilities.baseUrl() + '/api/author';

    constructor(private http: Http) { }

    getAuthors(){
        return this.http.get(this.url)
            .map(res => res.json());
    }

    getAuthor(id: number) {
        return this.http.get(this.getUrl(id))
            .map(res => res.json());
    }

    addAuthor(author: Author) {
        return this.http.post(this.url, author)
            .map(res => res.json());
    }

    updateAuthor(author: Author) {
        return this.http.put(this.url, author)
            .map(res => res.json());
    }

    deleteAuthor(id: number) {
        return this.http.delete(this.getUrl(id))
            .map(res => res.json());
    }

    private getUrl(id: number) {
        return this.url + '/' + id;
    }
}

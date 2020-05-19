import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';

import { Publisher } from './../models/publisher.model';
import { Utilities } from './utilities';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';



@Injectable()
export class PublisherService {

    private url = Utilities.baseUrl() + '/api/publisher';

    constructor(private http: Http) { }

    getPublishers() {
        return this.http.get(this.url)
            .map(res => res.json());
    }

    getPublisher(id: number) {
        return this.http.get(this.getUrl(id))
            .map(res => res.json());
    }

    addPublisher(publisher: Publisher) {
        return this.http.post(this.url, publisher)
            .map(res => res.json());
    }

    updatePublisher(publisher: Publisher) {
        return this.http.put(this.url, publisher)
            .map(res => res.json());
    }

    deletePublisher(id: number) {
        return this.http.delete(this.getUrl(id))
            .map(res => res.json());
    }

    private getUrl(id: number) {
        return this.url + '/' + id;
    }
}

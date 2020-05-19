﻿import { Injectable } from '@angular/core';


@Injectable()
export class Utilities {

    public static baseUrl() {
        return 'http://localhost:49532';
    }

    public static getBaseUrl() {
        let base = '';

        if (window.location.origin)
            base = window.location.origin;
        else
            base = window.location.protocol + "//" + window.location.hostname + (window.location.port ? ':' + window.location.port : '');
        return base.replace(/\/$/, '');
    }

}
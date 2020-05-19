import { Component, OnInit } from "@angular/core";


@Component({
    selector: 'top-bar',
    templateUrl: './top-bar.component.html',
    styleUrls: ['./top-bar.component.css']
})

export class TopbarComponent implements OnInit {
    item = "Book Management System";

    ngOnInit() {
    }
}
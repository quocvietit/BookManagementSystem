import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

import { Message, ConfirmationService } from 'primeng/primeng';

import { AuthorService } from './../../../services/author.service';
import { Author } from './../../../models/author.model';



@Component({
    selector: 'author-edit',
    templateUrl: './author-edit.component.html',
    styleUrls: ['./author-edit.component.css']
})


export class AuthorEditComponent {
    title: string = 'Thêm tác giả mới';
    btnAction: string = 'Tạo';
    form: FormGroup;
    author: Author = new Author();
    msgs: Message[] = [];
    loading: boolean = true;

    constructor(
        formBuilder: FormBuilder,
        private router: Router,
        private route: ActivatedRoute,
        private servicer: AuthorService
    ) { }

    ngOnInit() {
        this.form = new FormGroup({
            AuthorName: new FormControl(),
            History: new FormControl()
        });

        this.loadData();
    }

    loadData() {
        this.route.params.subscribe(params => {
            const id = params['id'];
            if (!id) return;
            this.btnAction = 'Sửa'
            this.title = 'Sửa tác giả'
            this.servicer.getAuthor(id)
                .subscribe(
                data => {
                    this.author = data;
                },
                response => {
                    if (response.status === 404) {
                        this.router.navigate(['NotFound']);
                    }
                });
        });
        this.loading = false;
    }

    edit() {
        this.loading = true;
        let result;
        const authorValue = this.form.value;
        if (this.author.authorId) {
            result = this.servicer.updateAuthor(this.author);
        } else {
            result = this.servicer.addAuthor(authorValue);
        }
        result.subscribe(data => this.router.navigate(['author']));
    }

    back(): void {
        this.router.navigate(['author']);
    }
}
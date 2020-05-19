import { Component, OnInit } from '@angular/core';

import { Message, ConfirmationService } from 'primeng/primeng';

import { AuthorService } from './../../services/author.service';
import { Author } from './../../models/author.model';



@Component({
    selector: 'author',
    templateUrl: './author.component.html',
    styleUrls: ['./author.component.css']
})

export class AuthorComponent implements OnInit{
    authors: Author[] = [];
    author: Author = new Author();
    res: boolean = true;
    msgs: Message[] = [];
    columns: any[] = [];
    display: boolean = false;
    loading: boolean = true;

    constructor(private service: AuthorService, private confirmService: ConfirmationService) { }

    ngOnInit() {
       this.loadData();
       this.columns = [
            { field: 'authorName', header: 'Tên tác giả' },
            { field: 'history', header: 'Tiểu sử' }
        ];
    }

    loadData() {
        this.service.getAuthors()
            .subscribe(data => this.authors = data);
        this.loading = false;
    }

    detail(item: Author) {
        this.author = item;
        this.display = true;
    }

    delete(item: Author) {
        this.confirmService.confirm({
            message: 'Xóa tác giả "' + item.authorName + '"?',
            header: 'Xác nhận xóa',
            icon: 'fa fa-trash',
            accept: () => {
                this.loading = true;
                this.service.deleteAuthor(item.authorId)
                    .subscribe(data => {
                        this.res = data;
                        if (this.res)
                            this.msgs = [{ severity: 'success', summary: 'Confirmed', detail: 'Xóa thành công!' }];
                        else
                            this.msgs = [{ severity: 'warn', summary: 'Warnning', detail: 'Có lỗi xảy ra!' }];
                        this.loadData();
                    });
            },
            reject: () => {
                this.msgs = [{ severity: 'error', summary: 'Rejected', detail: 'Xóa không thành công!' }];
            }
        });
    }
}

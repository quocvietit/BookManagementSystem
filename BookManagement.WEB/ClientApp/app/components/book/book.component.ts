import { Component, OnInit } from '@angular/core';

import { Message, ConfirmationService, OverlayPanel } from 'primeng/primeng';

import { BookService } from './../../services/book.service';
import { Book } from './../../models/book.model';
import { BookEdit } from '../../models/book-edit.model';
import { Author } from '../../models/author.model';
import { Category } from '../../models/category.model';
import { Publisher } from '../../models/publisher.model';
import { AuthorService } from '../../services/author.service';
import { PublisherService } from '../../services/publisher.service';
import { CategoryService } from '../../services/category.service';



@Component({
    selector: 'book',
    templateUrl: './book.component.html',
    styleUrls: ['./book.component.css']
})

export class BookComponent implements OnInit {
    books: Book[] = [];
    book: Book = new Book();
    loading: boolean = true;
    loadingImg: boolean;

    bookDetails: BookEdit = new BookEdit();
    author: Author = new Author();
    category: Category = new Category();
    publisher: Publisher = new Publisher();

    res: boolean = true;
    msgs: Message[] = [];
    columns: any[] = [];
    display: boolean = false;
    displayImg: boolean = false;

    constructor(
        private service: BookService,
        private authorService: AuthorService,
        private publisherService: PublisherService,
        private categoryService: CategoryService,
        private confirmService: ConfirmationService
    ) { }

    ngOnInit() {
        this.loadData();
        this.columns = [
            { field: 'title', header: 'Tựa sách' },
            { field: 'price', header: 'Giá' },
            { field: 'quantity', header: 'Số lượng' }
        ];
    }

    loadData() {
        this.service.getBooks()
            .subscribe(data => {
                this.books = data;
            });
        this.loading = false;
    }

    detail(item: Book) {
        this.service.getBookDetail(item.bookId)
            .subscribe(data => {
                this.bookDetails = data;
                this.authorService.getAuthor(this.bookDetails.authorId)
                    .subscribe(data => this.author = data);
                this.categoryService.getCategory(this.bookDetails.cateId)
                    .subscribe(data => this.category = data);
                this.publisherService.getPublisher(this.bookDetails.pubId)
                    .subscribe(data => this.publisher = data);
                this.display = true;
        });
    }

    delete(item: Book) {
        this.confirmService.confirm({
            message: 'Xóa sách "' + item.title + '"?',
            header: 'Xác nhận xóa',
            icon: 'fa fa-trash',
            accept: () => {
                this.loading = true;
                this.service.deleteBook(item.bookId)
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
    showImage(book: Book) {
        this.displayImg = true;
        this.book = book;
    }
}

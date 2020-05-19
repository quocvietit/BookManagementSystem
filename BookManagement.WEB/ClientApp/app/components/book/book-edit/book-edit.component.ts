import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

import { Message, ConfirmationService } from 'primeng/primeng';

import { BookService } from './../../../services/book.service';
import { BookEdit } from './../../../models/book-edit.model';
import { Category } from '../../../models/category.model';
import { Author } from '../../../models/author.model';
import { Publisher } from '../../../models/publisher.model';
import { AuthorService } from '../../../services/author.service';
import { PublisherService } from '../../../services/publisher.service';
import { CategoryService } from '../../../services/category.service';



@Component({
    selector: 'book-edit',
    templateUrl: './book-edit.component.html',
    styleUrls: ['./book-edit.component.css']
})


export class BookEditComponent implements OnInit {
    title: string = 'Thêm sách mới';
    btnAction: string = 'Tạo';
    form: FormGroup;
    bookEdit: BookEdit = new BookEdit();
    msgs: Message[] = [];
    imgName: string = 'Choose image.';
    loading: boolean = true;
    url: string = '';
    categories: Category[] = [];
    authors: Author[] = [];
    publishers: Publisher[] = [] 

    constructor(
        formBuilder: FormBuilder,
        private router: Router,
        private route: ActivatedRoute,
        private bookService: BookService,
        private authorService: AuthorService,
        private publisherService: PublisherService,
        private categoryService: CategoryService,
    ) { }

    ngOnInit() {
        this.form = new FormGroup({
            Title: new FormControl(),
            Summary: new FormControl(),
            CateId: new FormControl(),
            AuthorId: new FormControl(),
            PubId: new FormControl(),
            Price: new FormControl(),
            Quantity: new FormControl(),
            IsActive: new FormControl()
        });

        this.loadData();
    }

    loadData() {
        this.bookEdit.authorId = 0;
        this.bookEdit.cateId = 0;
        this.bookEdit.pubId = 0;
        this.bookEdit.isActive = 0;
        this.authorService.getAuthors()
            .subscribe(data => this.authors = data);

        this.publisherService.getPublishers()
            .subscribe(data => this.publishers = data);

        this.categoryService.getCategories()
            .subscribe(data => {
                this.categories = data;
                console.log(data);
            });
        
        this.route.params.subscribe(params => {
            const id = params['id'];
            if (!id)
                return;
            this.btnAction = 'Sửa'
            this.title = 'Sửa sách'
            this.bookService.getBookDetail(id)
                .subscribe(
                data => {
                    this.bookEdit = data;
                    if (this.bookEdit.imgUrl != null) {
                        this.url = this.bookEdit.imgUrl;
                    }
                },
                response => {
                    if (response.status == 404) {
                        this.router.navigate(['/not-found']);
                    }
                });
        });
        this.loading = false;
    }

    edit() {
        this.loading = true;
        let result;
        if (this.bookEdit.bookId) {
            this.bookEdit.imgUrl = this.url;
            result = this.bookService.updateBook(this.bookEdit);
        } else {
            const bookValue: BookEdit = this.form.value;
            this.bookEdit.imgUrl = this.url;
            result = this.bookService.addBook(bookValue);
        }
        result.subscribe(data => this.router.navigate(['book']),
            err => {
                this.loadData();
                alert("Có lỗi xảy ra!");
            }
        );
    }

    readUrl(event: any) {
        if (event.target.files && event.target.files[0]) {
            var reader = new FileReader();
            reader.onload = (event: any) => {
                this.url = event.target.result;
            }
            reader.readAsDataURL(event.target.files[0]);
        }
    }

    back(): void {
        this.router.navigate(['book']);
    }
}
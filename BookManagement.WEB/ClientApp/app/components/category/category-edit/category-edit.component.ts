import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

import { Message, ConfirmationService } from 'primeng/primeng';

import { CategoryService } from './../../../services/category.service';
import { Category } from './../../../models/category.model';



@Component({
    selector: 'category-edit',
    templateUrl: './category-edit.component.html',
    styleUrls: ['./category-edit.component.css']
})


export class CategoryEditComponent {
    title: string = 'Thêm danh mục sách mới';
    btnAction: string = 'Tạo';
    form: FormGroup;
    category: Category = new Category();
    msgs: Message[] = [];
    loading: boolean = false;

    constructor(
        formBuilder: FormBuilder,
        private router: Router,
        private route: ActivatedRoute,
        private servicer: CategoryService
    ) { }

    ngOnInit() {
        this.form = new FormGroup({
            CateName: new FormControl(),
            Description: new FormControl()
        });

        this.loadData();
    }

    loadData() {
        this.route.params.subscribe(params => {
            const id = params['id'];
            if (!id) return;
            this.btnAction = 'Sửa'
            this.title = 'Sửa danh mục sách'
            this.servicer.getCategory(id)
                .subscribe(
                data => {
                    this.category= data;
                },
                response => {
                    if (response.status === 404) {
                        this.router.navigate(['NotFound']);
                    }
                });
        });
    }

    edit() {
        this.loading = true;
        let result;
        const cateValue = this.form.value;
        if (this.category.cateId) {
            console.log(this.category)
            result = this.servicer.updateCategory(this.category);
        } else {
            result = this.servicer.addCategory(cateValue);
        }
        this.msgs = [{ severity: 'success', summary: 'Confirmed', detail: this.btnAction + ' thành công!' }];
        result.subscribe(data => {
            
            this.router.navigate(['category']);
        });
    }

    back(): void {
        this.router.navigate(['category']);
    }
}
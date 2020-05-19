import { Component, OnInit } from '@angular/core';

import { Message, ConfirmationService } from 'primeng/primeng';

import { CategoryService } from './../../services/category.service';
import { Category } from './../../models/category.model';



@Component({
    selector: 'category',
    templateUrl: './category.component.html',
    styleUrls: ['./category.component.css']
})

export class CategoryComponent implements OnInit{
    categories: Category[] = [];
    category: Category = new Category();
    res: boolean = true;
    msgs: Message[] = [];
    columns: any[] = [];
    display: boolean = false;
    loading: boolean = true;

    constructor(private service: CategoryService,private confirmService: ConfirmationService) { }

    ngOnInit() {
       this.loadData();
       this.columns = [
            { field: 'cateName', header: 'Tên danh mục' },
            { field: 'description', header: 'Mô tả' }
       ];
    }

    loadData() {
        this.service.getCategories()
            .subscribe(data => {
                this.categories = data;
            });
        this.loading = false;
    }

    detail(item: Category) {
        this.category = item;
        this.display = true;
    }

    delete(item: Category) {
        this.res = false;
        this.confirmService.confirm({
            message: 'Xóa danh mục "' + item.cateName + '"?',
            header: 'Xác nhận xóa',
            icon: 'fa fa-trash',
            accept: () => {
                this.loading = true;
                this.service.deleteCategory(item.cateId)
                    .subscribe(data => {
                        this.res = data
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

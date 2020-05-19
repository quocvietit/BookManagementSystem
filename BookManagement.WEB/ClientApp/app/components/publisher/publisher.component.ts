import { Component, OnInit } from '@angular/core';

import { Message, ConfirmationService } from 'primeng/primeng';

import { PublisherService } from './../../services/publisher.service';
import { Publisher } from './../../models/publisher.model';



@Component({
    selector: 'publisher',
    templateUrl: './publisher.component.html',
    styleUrls: ['./publisher.component.css']
})

export class PublisherComponent implements OnInit{
    publishers: Publisher[] = [];
    publisher: Publisher = new Publisher();
    res: boolean = true;
    msgs: Message[] = [];
    columns: any[] = [];
    display: boolean = false;
    loading: boolean = true;

    constructor(private service: PublisherService,private confirmService: ConfirmationService) { }

    ngOnInit() {
       this.loadData();
       this.columns = [
            { field: 'name', header: 'Tên nhà xuất bản' },
            { field: 'description', header: 'Mô tả' }
       ];
    }

    loadData() {
        this.service.getPublishers()
            .subscribe(data => this.publishers = data);
        this.loading = false;
    }

    detail(item: Publisher) {
        this.publisher = item;
        this.display = true;
    }

    delete(item: Publisher) {
        this.res = false;
        this.confirmService.confirm({
            message: 'Xóa danh mục "' + item.name + '"?',
            header: 'Xác nhận xóa',
            icon: 'fa fa-trash',
            accept: () => {
                this.loading = true;
                this.service.deletePublisher(item.pubId)
                    .subscribe(data => {
                        this.res = data
                        if (this.res)
                            this.msgs = [{ severity: 'success', summary: 'Confirmed', detail: 'Xóa thành công!' }];
                        else
                            this.msgs = [{ severity: 'warn', summary: 'Warnning', detail: 'Có lỗi xảy ra!' }];
                    });
                this.loadData();
            },
            reject: () => {
                this.msgs = [{ severity: 'error', summary: 'Rejected', detail: 'Xóa không thành công!' }];
            }
        });
    }
}

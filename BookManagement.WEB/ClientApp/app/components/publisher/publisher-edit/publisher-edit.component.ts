import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

import { Message, ConfirmationService } from 'primeng/primeng';

import { PublisherService } from './../../../services/publisher.service';
import { Publisher } from './../../../models/publisher.model';



@Component({
    selector: 'publisher-edit',
    templateUrl: './publisher-edit.component.html',
    styleUrls: ['./publisher-edit.component.css']
})


export class PublisherEditComponent {
    title: string = 'Thêm nhà sản xuất mới';
    btnAction: string = 'Tạo';
    form: FormGroup;
    publisher: Publisher = new Publisher();
    msgs: Message[] = [];
    loading: boolean = true;

    constructor(
        formBuilder: FormBuilder,
        private router: Router,
        private route: ActivatedRoute,
        private servicer: PublisherService
    ) { }

    ngOnInit() {
        this.form = new FormGroup({
            Name: new FormControl(),
            Description: new FormControl()
        });

        this.loadData();
    }

    loadData() {
        this.route.params.subscribe(params => {
            const id = params['id'];
            if (!id) return;
            this.btnAction = 'Sửa'
            this.title = 'Sửa nhà sản xuất'
            this.servicer.getPublisher(id)
                .subscribe(
                data => this.publisher = data,
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
        const publValue = this.form.value;
        if (this.publisher.pubId) {
            result = this.servicer.updatePublisher(this.publisher);
        } else {
            result = this.servicer.addPublisher(publValue);
        }
        result.subscribe(data => this.router.navigate(['publisher']));
    }

    back(): void {
        this.router.navigate(['publisher']);
    }
}
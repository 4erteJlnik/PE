import { __decorate } from "tslib";
import { Component } from '@angular/core';
import { Validators, FormControl, FormGroup } from '@angular/forms';
import { HttpService } from '../http.service';
let EditComponent = class EditComponent {
    constructor(httpService, fb) {
        this.httpService = httpService;
        this.fb = fb;
        this.categories = [
            { id: 1, name: "Категория 1" },
            { id: 2, name: "Подкатегория 1" },
            { id: 3, name: "Подкатегория 2" },
            { id: 4, name: "Категория 2" },
            { id: 5, name: "Подкатегория 1" },
            { id: 6, name: "Подкатегория 2" },
            { id: 7, name: "Категория 3" },
            { id: 8, name: "Подкатегория 1" },
            { id: 9, name: "Подкатегория 2" },
        ];
        this.submitted = false;
        this.editPost = new FormGroup({
            name: new FormControl('', [Validators.required]),
            description: new FormControl('', [Validators.required]),
            category: new FormControl('', [Validators.required]),
            cost: new FormControl('', [Validators.required]),
            city: new FormControl('', [Validators.required])
        });
    }
    get f() {
        return this.editPost.controls;
    }
    onSubmit() {
        this.submitted = true;
        if (this.editPost.invalid) {
            return;
        }
        console.log(this.editPost);
        this.httpService.postData('https://localhost:5001/Account/Edit', this.editPost.value).subscribe();
    }
    ngOnInit() {
    }
};
EditComponent = __decorate([
    Component({
        selector: 'app-edit',
        templateUrl: './edit.component.html',
        styleUrls: ['./edit.component.scss'],
        providers: [HttpService]
    })
], EditComponent);
export { EditComponent };
//# sourceMappingURL=edit.component.js.map
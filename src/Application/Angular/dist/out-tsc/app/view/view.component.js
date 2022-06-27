import { __decorate } from "tslib";
import { Component } from '@angular/core';
import { HttpService } from '../http.service';
import { Validators, FormControl, FormGroup } from '@angular/forms';
let ViewComponent = class ViewComponent {
    constructor(httpService, fb, accountService) {
        this.httpService = httpService;
        this.fb = fb;
        this.accountService = accountService;
        this.submitted = false;
        this.accountService.user.subscribe(x => this.user = x);
        this.addCom = new FormGroup({
            description: new FormControl('', [Validators.required])
        });
    }
    get f() {
        return this.addCom.controls;
    }
    onSubmit() {
        this.submitted = true;
        if (this.addCom.invalid) {
            return;
        }
        console.log(this.addCom);
        this.httpService.postData('https://localhost:5001/Account/New', this.addCom.value).subscribe();
    }
    ngOnInit() {
    }
};
ViewComponent = __decorate([
    Component({
        selector: 'app-view',
        templateUrl: './view.component.html',
        styleUrls: ['./view.component.scss'],
        providers: [HttpService]
    })
], ViewComponent);
export { ViewComponent };
//# sourceMappingURL=view.component.js.map
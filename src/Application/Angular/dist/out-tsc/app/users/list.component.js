import { __decorate } from "tslib";
import { Component } from '@angular/core';
import { first } from 'rxjs/operators';
let ListComponent = class ListComponent {
    constructor(accountService) {
        this.accountService = accountService;
        this.users = null;
    }
    ngOnInit() {
        this.accountService.getAll()
            .pipe(first())
            .subscribe(users => this.users = users);
    }
    deleteUser(id) {
        const user = this.users.find(x => x.id === id);
        user.isDeleting = true;
        this.accountService.delete(id)
            .pipe(first())
            .subscribe(() => this.users = this.users.filter(x => x.id !== id));
    }
};
ListComponent = __decorate([
    Component({ templateUrl: 'list.component.html', styleUrls: ['./add-edit.component.scss'] })
], ListComponent);
export { ListComponent };
//# sourceMappingURL=list.component.js.map
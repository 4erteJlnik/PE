import { __decorate } from "tslib";
import { Component } from '@angular/core';
import { Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
let AddEditComponent = class AddEditComponent {
    constructor(formBuilder, route, router, accountService, alertService) {
        this.formBuilder = formBuilder;
        this.route = route;
        this.router = router;
        this.accountService = accountService;
        this.alertService = alertService;
        this.loading = false;
        this.submitted = false;
    }
    ngOnInit() {
        this.id = this.route.snapshot.params['id'];
        this.isAddMode = !this.id;
        // password not required in edit mode
        const passwordValidators = [];
        if (this.isAddMode) {
            passwordValidators.push(Validators.required);
        }
        this.form = this.formBuilder.group({
            firstName: ['', Validators.required],
            lastName: ['', Validators.pattern("[+][0-9][(][0-9]{3}[)][0-9]{3}[-][0-9]{2}[-][0-9]{2}")],
            username: ['', Validators.required],
            password: ['', passwordValidators]
        });
        if (!this.isAddMode) {
            this.accountService.getById(this.id)
                .pipe(first())
                .subscribe(x => this.form.patchValue(x));
        }
    }
    // convenience getter for easy access to form fields
    get f() { return this.form.controls; }
    onSubmit() {
        this.submitted = true;
        // reset alerts on submit
        this.alertService.clear();
        // stop here if form is invalid
        if (this.form.invalid) {
            return;
        }
        this.loading = true;
        if (this.isAddMode) {
            this.createUser();
        }
        else {
            this.updateUser();
        }
    }
    createUser() {
        this.accountService.register(this.form.value)
            .pipe(first())
            .subscribe({
            next: () => {
                this.alertService.success('User added successfully', { keepAfterRouteChange: true });
                this.router.navigate(['../'], { relativeTo: this.route });
            },
            error: error => {
                this.alertService.error(error);
                this.loading = false;
            }
        });
    }
    updateUser() {
        this.accountService.update(this.id, this.form.value)
            .pipe(first())
            .subscribe({
            next: () => {
                this.alertService.success('Update successful', { keepAfterRouteChange: true });
                this.router.navigate(['../../'], { relativeTo: this.route });
            },
            error: error => {
                this.alertService.error(error);
                this.loading = false;
            }
        });
    }
};
AddEditComponent = __decorate([
    Component({ templateUrl: 'add-edit.component.html', styleUrls: ['./add-edit.component.scss'] })
], AddEditComponent);
export { AddEditComponent };
//# sourceMappingURL=add-edit.component.js.map
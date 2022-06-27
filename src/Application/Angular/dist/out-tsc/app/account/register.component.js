import { __decorate } from "tslib";
import { Component } from '@angular/core';
import { Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { CustomValidators } from './CustomValidators';
let RegisterComponent = class RegisterComponent {
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
        this.form = this.formBuilder.group({
            firstName: ['', Validators.required],
            lastName: ['', Validators.pattern("[+][0-9][(][0-9]{3}[)][0-9]{3}[-][0-9]{2}[-][0-9]{2}")],
            username: ['',
                Validators.required
                //, Validators.email]
            ],
            password: ['', Validators.required],
            confirmPassword: ['', Validators.required],
            role: ['']
        }, { validator: CustomValidators.mustMatch('password', 'confirmPassword') });
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
        this.form.patchValue({
            role: '1'
        });
        this.loading = true;
        this.accountService.register(this.form.value)
            .pipe(first())
            .subscribe({
            next: () => {
                this.alertService.success('Registration successful', { keepAfterRouteChange: true });
                this.router.navigate(['../login'], { relativeTo: this.route });
            },
            error: error => {
                this.alertService.error(error);
                this.loading = false;
            }
        });
    }
};
RegisterComponent = __decorate([
    Component({ templateUrl: 'register.component.html', styleUrls: ['./register.component.scss'] })
], RegisterComponent);
export { RegisterComponent };
//# sourceMappingURL=register.component.js.map
import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule, FormControl, FormGroup, FormBuilder, AbstractControl} from '@angular/forms';
import { HttpService } from '../http.service';

@Component({
    selector: 'app-create',
    templateUrl: './create.component.html',
    styleUrls: ['./create.component.scss'],
    providers: [HttpService]
})

export class PasswordValidation {

    static MatchPassword(AC: AbstractControl) {
        let password = AC.get('password').value; // to get value in input tag
        let confirmPassword = AC.get('confirmPassword').value; // to get value in input tag
        if (password != confirmPassword) {
            console.log('false');
            AC.get('confirmPassword').setErrors({ MatchPassword: true })
        } else {
            console.log('true');
            return null
        }
    }
}

export class CreateComponent implements OnInit {
    FormCreate: FormGroup;

    constructor(private httpService: HttpService, private fb: FormBuilder) {
        this.FormCreate = fb.group({
            fio: new FormControl(''),
            email: new FormControl(''),
            password: new FormControl(''),
            confirmPassword: new FormControl(''),
            validator: PasswordValidation.MatchPassword // your validation method
        })
    }

    Add() {
        console.log(this.FormCreate);
        this.httpService.postData('https://localhost:5001/Account/RegisterPost', this.FormCreate.value).subscribe();
    }

    ngOnInit(): void {
    }
}
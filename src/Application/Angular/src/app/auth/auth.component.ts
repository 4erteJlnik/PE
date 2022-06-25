import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule, Validators, FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { HttpService } from '../http.service';

@Component({
    selector: 'app-auth',
    templateUrl: './auth.component.html',
    styleUrls: ['./auth.component.scss'],
    providers: [HttpService]
})

export class AuthComponent implements OnInit {
    LoginForm: FormGroup;
    constructor(private httpService: HttpService, private fb: FormBuilder) {
        this.LoginForm = fb.group({
            Email: new FormControl('', [Validators.required]),
            Password: new FormControl('', [Validators.required])
        })
    }
	
	submitted = false;

    ngOnInit(): void {
    }
	
	get f() {
		return this.LoginForm.controls;
	}
	
    SignIn() {
		this.submitted = true;
		
		if (this.LoginForm.invalid) {
			return;
		}
		
        console.log(this.LoginForm);
        this.httpService.postData('https://localhost:5001/Account/LoginPost', this.LoginForm.value).subscribe();
    }
}

import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule, Validators, FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { HttpService } from '../http.service';
import { CustomValidators } from './CustomValidators';

@Component({
    selector: 'app-create',
    templateUrl: './create.component.html',
    styleUrls: ['./create.component.scss'],
    providers: [HttpService]
})

export class CreateComponent implements OnInit {
	formCreate: FormGroup;
	
    constructor(private httpService: HttpService, private fb: FormBuilder) {
		
		this.formCreate = new FormGroup(
		{
		  fio: new FormControl('', [Validators.required]),
		  email: new FormControl('', [Validators.required]),
		  phone: new FormControl('', [Validators.pattern("[+][0-9][(][0-9]{3}[)][0-9]{3}[-][0-9]{2}[-][0-9]{2}")]),
		  password: new FormControl('', [Validators.required]),
		  confirmPassword: new FormControl('', [Validators.required])
		},

		CustomValidators.mustMatch('password', 'confirmPassword'), // insert here
	  );
	}
	
	get f() {
		return this.formCreate.controls;
	}
	
	submitted = false;
	
    onSubmit() {
		this.submitted = true;
		
		if (this.formCreate.invalid) {
			return;
		}
		
        console.log(this.formCreate);
        this.httpService.postData('https://localhost:5001/Account/RegisterPost', this.formCreate.value).subscribe();
    }

    ngOnInit() {
	}
}
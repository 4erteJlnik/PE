import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule, Validators, FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { HttpService } from '../http.service';

import { AccountService } from '../_services';
import { User } from '../_models';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.scss'],
  providers: [HttpService]
})
export class AddComponent implements OnInit {
	user: User;
	
	categories = [
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
	
	addPost: FormGroup;
	
    constructor(private httpService: HttpService, private fb: FormBuilder, private accountService: AccountService) {
		this.accountService.user.subscribe(x => this.user = x);
		
		this.addPost = new FormGroup(
		{
		  name: new FormControl('', [Validators.required]),
		  description: new FormControl('', [Validators.required]),
		  category: new FormControl('', [Validators.required]),
		  cost: new FormControl('', [Validators.required]),
		  city: new FormControl('', [Validators.required])
		});
	}

	get f() {
		return this.addPost.controls;
	}
	
	submitted = false;

	onSubmit() {
		this.submitted = true;
		
		if (this.addPost.invalid) {
			return;
		}
		
        console.log(this.addPost);
        this.httpService.postData('https://localhost:5001/Account/New', this.addPost.value).subscribe();
    }


	ngOnInit(): void {
	}

}

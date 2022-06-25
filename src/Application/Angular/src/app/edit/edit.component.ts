import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule, Validators, FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { HttpService } from '../http.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss'],
  providers: [HttpService]
})
export class EditComponent implements OnInit {
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
	
	editPost: FormGroup;
	
    constructor(private httpService: HttpService, private fb: FormBuilder) {
		
		this.editPost = new FormGroup(
		{
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
	
	submitted = false;

	onSubmit() {
		this.submitted = true;
		
		if (this.editPost.invalid) {
			return;
		}
		
        console.log(this.editPost);
        this.httpService.postData('https://localhost:5001/Account/Edit', this.editPost.value).subscribe();
    }


	ngOnInit(): void {
	}

}

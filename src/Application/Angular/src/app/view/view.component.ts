import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';

import { AccountService } from '../_services';
import { User } from '../_models';
import { ReactiveFormsModule, Validators, FormControl, FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.scss'],
  providers: [HttpService]
})

export class ViewComponent implements OnInit {
	user: User;
	
	addCom: FormGroup;
	
    constructor(private httpService: HttpService, private fb: FormBuilder, private accountService: AccountService) {
		this.accountService.user.subscribe(x => this.user = x);
		
		this.addCom = new FormGroup(
		{
		  description: new FormControl('', [Validators.required])
		});
	}

	get f() {
		return this.addCom.controls;
	}
	
	submitted = false;

	onSubmit() {
		this.submitted = true;
		
		if (this.addCom.invalid) {
			return;
		}
		
        console.log(this.addCom);
        this.httpService.postData('https://localhost:5001/Account/New', this.addCom.value).subscribe();
    }


	ngOnInit(): void {
	}

}


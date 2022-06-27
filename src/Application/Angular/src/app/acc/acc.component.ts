import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { Post } from './Post';

import { AccountService } from '../_services';
import { User } from '../_models';

@Component({
  selector: 'app-acc',
  templateUrl: './acc.component.html',
  styleUrls: ['./acc.component.scss'],
  providers: [HttpService]
})
export class AccComponent implements OnInit {
	user: User;
	
	posts: Post[] = [];
	data: any;
	constructor(private httpService: HttpService, private accountService: AccountService) {this.accountService.user.subscribe(x => this.user = x); }

	ngOnInit(): void {
		
		this.httpService.getData("http://localhost:5000/Post/GetNumber?number=2147483647").subscribe((data:any) =>{ this.posts = data;
		this.posts.forEach(element => {
		element.date = new Date(element.dateOfCreate);
		element.dateOfCreate = element.dateOfCreate.slice(0,10);
		});
    });
  }
}

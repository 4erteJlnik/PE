import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { Post } from './Post';

@Component({
  selector: 'app-acc',
  templateUrl: './acc.component.html',
  styleUrls: ['./acc.component.scss'],
  providers: [HttpService]
})
export class AccComponent implements OnInit {
	posts: Post[] = [];
	data: any;
	constructor(private httpService: HttpService) { }

	ngOnInit(): void {
		this.httpService.getData("http://localhost:5000/Post/GetNumber?number=2147483647").subscribe((data:any) =>{ this.posts = data;
		this.posts.forEach(element => {
		element.date = new Date(element.dateOfCreate);
		element.dateOfCreate = element.dateOfCreate.slice(0,10);
		});
    });
  }
}

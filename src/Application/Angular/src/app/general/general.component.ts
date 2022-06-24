import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { Post } from '../store/Post';

@Component({
  selector: 'app-general',
  templateUrl: './general.component.html',
    styleUrls: ['./general.component.scss'],
    providers: [HttpService]
})

export class StoreComponent implements OnInit {
    posts: Post[] = [];
    data: any;
    constructor(private httpService: HttpService) { }

    ngOnInit(): void {
        this.httpService.getData("http://localhost:5000/Post/GetNumber?number=2147483647").subscribe((data: any) => {
            this.posts = data;
            this.posts.forEach(element => {
                element.date = new Date(element.dateOfCreate);
                element.dateOfCreate = element.dateOfCreate.slice(0, 10);
            });
        });
    }

}

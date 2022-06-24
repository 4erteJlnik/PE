import { Component, OnInit } from '@angular/core';
import { HttpService } from '../http.service';
import { Post } from './Post';
@Component({
  selector: 'app-store',
  templateUrl: './store.component.html',
  styleUrls: ['./store.component.scss'],
  providers: [HttpService]
})
export class StoreComponent implements OnInit {
  posts: Post[] = [];
  constructor(private httpService: HttpService) { }

  ngOnInit(): void {
    this.httpService.getData("https://localhost:5001/Post/GetNumber?number=2147483647").subscribe((data:any) => this.posts=data);
  }

}

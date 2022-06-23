import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule,FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { HttpService } from '../http.service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss'],
  providers: [HttpService]
})
export class AuthComponent implements OnInit {
  LoginForm :FormGroup;
  constructor(private httpService: HttpService,private fb:FormBuilder) {
    this.LoginForm = fb.group({
      Email: new FormControl(''),
    Password: new FormControl('')
    })
   }

  ngOnInit(): void {
  }
  SignIn()
  {
    console.log(this.LoginForm);
    this.httpService.postData('https://localhost:5001/Account/LoginPost',this.LoginForm.value).subscribe();
  }
  

}

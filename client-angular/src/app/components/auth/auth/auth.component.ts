import { AuthService } from '../../../shared/services/auth.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})
export class AuthComponent implements OnInit {

  public isUserAuthenticated = false;
  
  constructor(private authService: AuthService) {
    this.authService.loginChanged
      .subscribe(userAuthenticated => {
        this.isUserAuthenticated = userAuthenticated;
      })
  }

  ngOnInit(): void {
    // this.authService.isAuthenticated()
    //   .then(userAuthenticated => {
    //     this.isUserAuthenticated = userAuthenticated;
    //   })

    this.authService.loginChanged
      .subscribe(result => {
        this.isUserAuthenticated = result
      })
  }

  public login = () => {
    this.authService.login();
  }

  public logout = () => {
    this.authService.logout();
  }
}

import { Router } from '@angular/router';
import { AuthService } from './../../../shared/services/auth.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-signout-redirect-callback',
  template: '<div></div>',
})
export class SignoutRedirectCallbackComponent implements OnInit {

  constructor(private authService: AuthService,
              private router: Router) { }

  ngOnInit(): void {
    this.authService.finishLogout()
      .then(_ => {
        this.router.navigate(['/'], {replaceUrl: true});
      })
  }
}

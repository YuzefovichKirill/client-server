import { Injectable } from '@angular/core';
import { UserManager, User, UserManagerSettings } from 'oidc-client';
import { Subject } from 'rxjs';
import { environment } from '../../../environments/environment';


@Injectable({
    providedIn: 'root'
})
export class AuthService{
    private userManager: UserManager;
    private user: User;
    private loginChangedSubject = new Subject<boolean>();
    public loginChanged = this.loginChangedSubject.asObservable();

    private get userManagerSettings() : UserManagerSettings {
        return {
            authority: environment.authorityUrl,
            client_id: environment.clientId,
            redirect_uri: environment.clientUrl + 'signin-callback',
            scope: "openid profile ServerWebAPI",
            response_type: 'code',
            post_logout_redirect_uri: environment.clientUrl + 'signout-callback',
        }
    }

    constructor() {
        this.userManager = new UserManager(this.userManagerSettings)
    }

    public login = () => {
        return this.userManager.signinRedirect();
    }

    public finishLogin = (): Promise<User> => {
        return this.userManager.signinRedirectCallback()
            .then(user => {
                this.user = user;
                this.loginChangedSubject.next(this.checkUser(user));
                return user;
            })
    }

    public logout = () => {
        this.userManager.signoutRedirect();
    }

    public finishLogout = () => {
        this.user = null;
        return this.userManager.signoutRedirectCallback();
    }

    public isAuthenticated = (): Promise<boolean> => {
        return this.userManager.getUser()
        .then(user => {
            if(this.user !== user){
                this.loginChangedSubject.next(this.checkUser(user))
            }

            this.user = user;
            return this.checkUser(user);
        })
      }

      private checkUser = (user : User): boolean => {
        return !!user && !user.expired;
      }

      public getAccessToken = (): Promise<string> => {
        return this.userManager.getUser()
            .then(user => {
                return !!user && !user.expired ? user.access_token : null;
            })
      }
}
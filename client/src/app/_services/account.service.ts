import { HttpClient } from '@angular/common/http';
import { Injectable, inject, signal } from '@angular/core';
import { User } from '../_models/user';
import { map } from 'rxjs';
import { environment } from '../../environments/environment';
import { LikesService } from './likes.service';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private http = inject(HttpClient);
  private likeService = inject(LikesService);
  baseUrl = environment.apiUrl;
  currentUser = signal<User | null>(null);

  constructor() { }

  login(model: any) {
    console.log(this.baseUrl + 'account/login');
    return this.http.post<User>(this.baseUrl + 'account/login', model).pipe(
      map(user => {
        localStorage.setItem('user', JSON.stringify(user));
        this.currentUser.set(user);
      })
    ) ;
  }

  register(model: any) {
    console.log(this.baseUrl + 'account/register');
    return this.http.post<User>(this.baseUrl + 'account/register', model).pipe(
      map(user => {
        if (user) {
          this.setCurrentUser(user);
          // localStorage.setItem('user', JSON.stringify(user));
          // this.currentUser.set(user);
        }
        return user;
      })
    )
  }

  setCurrentUser(user: User) {
    localStorage.setItem('user', JSON.stringify(user));
    this.currentUser.set(user);
    this.likeService.getLikeIds();
  }

  logout(){
    localStorage.removeItem('user');
    this.currentUser.set(null);
  }
  

}

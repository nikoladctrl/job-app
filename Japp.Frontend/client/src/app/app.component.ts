import { Component, OnInit } from '@angular/core';
import { Select, Store } from '@ngxs/store';
import { Observable } from 'rxjs';
import { AuthenticationStateModel, AuthStateModule } from './core/store/auth/auth.state';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'client';
  @Select(AuthStateModule.getAuthData) authData$ : Observable<AuthenticationStateModel>;
  
  constructor(private store: Store) { }

  ngOnInit(): void {
    console.log(this.authData$);
  }

}

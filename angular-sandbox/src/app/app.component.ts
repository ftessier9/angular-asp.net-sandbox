import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { UserInfoComponent } from './components/user-info/user-info.component';
import { CreateUserComponent } from './components/create-user/create-user.component';
import { ToolbarComponent } from './components/layout/toolbar/toolbar.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, UserInfoComponent, CreateUserComponent, ToolbarComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'angular-sandbox';
}

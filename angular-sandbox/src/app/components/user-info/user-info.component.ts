import { Component } from '@angular/core';
import { UserService } from '../../services/user.service';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-user-info',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './user-info.component.html',
  styleUrl: './user-info.component.css'
})
export class UserInfoComponent {

  userInfo: any;

  constructor(private userService: UserService) {}

  applyForm = new FormGroup({
    'user-id': new FormControl('')
  })

  getUserInfo(){
    const userId = this.applyForm.value['user-id'] ?? ''
    this.userService.getUserInfoById(userId).subscribe({
      next: (data: any) => {this.userInfo = data},
      error: (error) => {console.error(error)}
      }
    )
  }
}

import { Component } from '@angular/core';
import { UserService } from '../../services/user.service';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { User } from '../../models/user.model';
import {MatButtonModule} from '@angular/material/button';

@Component({
  selector: 'app-user-info',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule, MatButtonModule],
  templateUrl: './user-info.component.html',
  styleUrl: './user-info.component.css'
})
export class UserInfoComponent {

  userInfo: User | null = null;
  userFound: boolean = true;

  constructor(private userService: UserService) {}

  applyForm = new FormGroup({
    'user-id': new FormControl('')
  })

  getUserInfo(){
    const userId = this.applyForm.value['user-id'] ?? ''
    this.userService.getUserInfoById(userId).subscribe({
      next: (data: any) => {
        this.userInfo = data
        this.userFound = true;
      },
      error: (error) => {
        console.error(error)
        this.userInfo = null;
        this.userFound = false;
        }
      }
    )
  }
}

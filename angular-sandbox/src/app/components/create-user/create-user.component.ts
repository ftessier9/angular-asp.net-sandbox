import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { UserService } from '../../services/user.service';
import { User } from '../../models/user.model';
import {MatButtonModule} from '@angular/material/button';


@Component({
  selector: 'app-create-user',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule, MatButtonModule],
  templateUrl: './create-user.component.html',
  styleUrl: './create-user.component.css'
})
export class CreateUserComponent {

  userInfo: User | null = null;

  constructor(private UserService: UserService){}

  applyForm = new FormGroup({
    'name': new FormControl(''),
    'age': new FormControl(''),
    'job': new FormControl('')
  })

  createUser(){
    const body = this.applyForm.value ?? ''
    this.UserService.createUser(body).subscribe({
      next: (data: any) => {this.userInfo = data},
      error: (error) => {console.error(error)}
      }
    )
  }

}

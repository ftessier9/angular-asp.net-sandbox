import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { UserService } from '../../services/user.service';


@Component({
  selector: 'app-create-user',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './create-user.component.html',
  styleUrl: './create-user.component.css'
})
export class CreateUserComponent {

  userInfo: any;

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

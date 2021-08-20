import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { OperationResult } from '@shared/models/operation-result';
import { AuthorizeService, LoginContract, UserContract } from '../../services/authorize.service';

@Component({
  selector: 'app-authorize',
  templateUrl: './authorize.component.html',
  styleUrls: ['./authorize.component.css']
})
export class AuthorizeComponent implements OnInit {

  loginForm = this.fb.group({
    emailAddress: ['', Validators.required],
    password: ['', Validators.required],
    rememberMe: [false]
  });

  operationResult!: OperationResult<UserContract>;

  constructor(private fb: FormBuilder, private authService: AuthorizeService, private router: Router) { }

  ngOnInit(): void {
  }

  public login(model: LoginContract) {
    this.authService.signIn(model).subscribe(result =>
    {
      console.log(result);
      if (result.hasErrors) {
        this.operationResult = result;
        return;
      }
      this.router.navigate(['mailbox']);
    });
  }
}

import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { OperationResult } from '@shared/models/operation-result';
import { AuthorizeService, LoginContract, TokenContract } from '../../services/authorize.service';

@Component({
  selector: 'app-authorize',
  templateUrl: './authorize.component.html',
  styleUrls: ['./authorize.component.css']
})
export class AuthorizeComponent implements OnInit {

  loginForm = this.fb.group({
    emailAddress: ['', [Validators.required, Validators.email]],
    password: ['', Validators.required],
    rememberMe: [false]
  });

  public get emailAddress() { return this.loginForm.controls.emailAddress; }
  public get password() { return this.loginForm.controls.password; }

  loginResult!: OperationResult<TokenContract>;

  submited: boolean = false;

  constructor(private fb: FormBuilder, private authService: AuthorizeService, private router: Router) { }

  ngOnInit(): void {
    this.authService.signOut();
  }

  public login(model: LoginContract) {
    this.submited = true;
    if (this.loginForm.valid) {
      this.authService.signIn(model).subscribe(result => {
        if (result.hasErrors) {
          this.loginResult = result;
          return;
        }
        this.router.navigate(['mailbox']);
      });
    }
  }
}

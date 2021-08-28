import { Component, OnInit } from '@angular/core';
import { AuthorizeService, TokenContract } from '../../../authorization/services/authorize.service';

@Component({
  selector: 'app-application-menu',
  templateUrl: './application-menu.component.html',
  styleUrls: ['./application-menu.component.css']
})
export class ApplicationMenuComponent implements OnInit {

  public get currentUser(): TokenContract | null {
    return this.authService.getUser();
  }
  constructor(private authService: AuthorizeService) { }

  ngOnInit(): void {
  }

}

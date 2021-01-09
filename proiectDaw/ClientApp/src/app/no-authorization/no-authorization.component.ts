import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-no-authorization-component',
  templateUrl: './no-authorization.component.html'
})
export class NoAuthorizationComponent {

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
  }
  }
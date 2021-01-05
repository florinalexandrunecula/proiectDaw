import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-fire-page-component',
  templateUrl: './fire-page.component.html'
})
export class FirePageComponent {

  private readonly httpClient: HttpClient;
  private readonly baseUrl: string;

  public result = "";
  public name = new FormControl(null);
  public email = new FormControl(null);

  public buttonClicked() {
    this.httpClient.post<SoftwareDeveloper>(
      this.baseUrl + "softwareDeveloper/delete",
      {
        name: this.name.value,
        email: this.email.value,
      },
      { headers: { "Content-Type": "application/x-www-form-urlencoded" }}
    )
      .subscribe(
        (result) => {
          console.log("Success");
          this.result = "Successfully fired the employee!";
        },
        (error) => {
          console.error(error);
        }
      )
  }

  constructor(
    http: HttpClient,
    @Inject("BASE_URL") baseUrl: string
  ) {
    this.httpClient = http;
    this.baseUrl = baseUrl;
  }

}

interface SoftwareDeveloper {
  name: string;
  email: string;
}
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
  public authorization: boolean[];
  public authorize = false;

  public buttonClicked() {

    this.httpClient.get<boolean[]>(this.baseUrl + "getUserRole").subscribe(result => {
      this.authorization = result;
      console.log({ result });
      if (this.authorization[0] == true) {
        this.authorize = true;
      }
      if (this.authorize == true) {
        this.httpClient.post<SoftwareDeveloper>(
          this.baseUrl + "softwareDeveloper/delete",
          {
            name: this.name.value,
            email: this.email.value,
          },
          { headers: { "Content-Type": "application/x-www-form-urlencoded" } }
        )
          .subscribe(
            (result) => {
              console.log("Success");
              this.result = "Successfully fired the employee!";
            },
            (error) => {
              console.error(error);
              this.result = "Something went wrong with your request!";
            }
          )
      }
      else {
        this.result = "You are not allowed to do this!";
      }
    }, error => console.error(error));
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
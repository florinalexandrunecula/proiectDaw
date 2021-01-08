import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-update-page-component',
  templateUrl: './update-page.component.html'
})
export class UpdatePageComponent {

  private readonly httpClient: HttpClient;
  private readonly baseUrl: string;

  public result = "";
  public oldname = new FormControl(null);
  public oldemail = new FormControl(null);
  public oldrole = new FormControl(null);
  public newname = new FormControl(null);
  public newemail = new FormControl(null);
  public newrole = new FormControl(null);

  public buttonClicked() {
    this.httpClient.post<SoftwareDeveloper>(
      this.baseUrl + "softwareDeveloper/update",
      {
        oldname: this.oldname.value,
        oldemail: this.oldemail.value,
        oldrole: this.oldrole.value,
        newname: this.newname.value,
        newemail: this.newemail.value,
        newrole: this.newrole.value,
      },
      { headers: { "Content-Type": "application/x-www-form-urlencoded" }}
    )
      .subscribe(
        (result) => {
          console.log("Success");
          this.result = "Successfully updated the employee";
        },
        (error) => {
          this.result = "Something went wrong with your request!";
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
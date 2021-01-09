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
  public oldproject = new FormControl(null);
  public newname = new FormControl(null);
  public newemail = new FormControl(null);
  public newrole = new FormControl(null);
  public newproject = new FormControl(null);
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
          this.baseUrl + "softwareDeveloper/update",
          {
            oldname: this.oldname.value,
            oldemail: this.oldemail.value,
            oldrole: this.oldrole.value,
            oldproject: this.oldproject.value,
            newname: this.newname.value,
            newemail: this.newemail.value,
            newrole: this.newrole.value,
            newproject: this.newproject.value,
          },
          { headers: { "Content-Type": "application/x-www-form-urlencoded" } }
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
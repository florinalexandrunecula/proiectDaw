import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-vacation-component',
  templateUrl: './vacation.component.html'
})
export class VacationComponent {

  private readonly httpClient: HttpClient;
  private readonly baseUrl: string;

  public result = "";
  public annualInput = new FormControl(null);
  public bloodInput = new FormControl(null);
  public hoursInput = new FormControl(null);
  public annual: number;
  public blood: number;
  public hours: number;
  public authorization: boolean[];
  public authorize = false;

  public buttonClicked() {
    this.httpClient.post<SoftwareDeveloper>(
      this.baseUrl + "softwareDeveloper/vacation",
      {
        annual: this.annualInput.value,
        blood: this.bloodInput.value,
        hours: this.hoursInput.value,
      },
      { headers: { "Content-Type": "application/x-www-form-urlencoded" } }
    )
      .subscribe(
        (result) => {
          console.log("Success");
          this.result = "Success!";
        },
        (error) => {
          this.result = "Something went wrong with your request!";
          console.error(error);
        }
      );
    
  }

  constructor(
    http: HttpClient,
    @Inject("BASE_URL") baseUrl: string
  ) {
    this.httpClient = http;
    this.baseUrl = baseUrl;
    this.httpClient.get<number[]>(this.baseUrl + "getQuota").subscribe(result => {
      this.annual = result[0];
      this.blood = result[1];
      this.hours = result[2];
    }, error => console.error(error))
  }

}

interface SoftwareDeveloper {
  name: string;
  email: string;
}
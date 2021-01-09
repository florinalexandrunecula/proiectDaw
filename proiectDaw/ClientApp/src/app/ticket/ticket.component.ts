import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-ticket-component',
  templateUrl: './ticket.component.html'
})
export class TicketComponent {

  private readonly httpClient: HttpClient;
  private readonly baseUrl: string;

  public authorization: boolean[];
  public authorize = false;
  public result = "";
  public title = new FormControl(null);
  public description = new FormControl(null);
  public tickets: Ticket[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private router: Router) {

    this.httpClient = http;
    this.baseUrl = baseUrl;

    http.get<boolean[]>(baseUrl + "getUserRole").subscribe(result => {
      this.authorization = result;
      console.log({ result });
      if (this.authorization[0] == true) {
        this.authorize = true;
      }
      if (this.authorize == true) {
        http.get<Ticket[]>(baseUrl + "tickets").subscribe(result => {
          this.tickets = result;
        })
      }
      else {
        this.router.navigateByUrl('/no-authorization');
      }
    }, error => console.error(error));
  }

  public CreateTicket() {
    this.httpClient.get<boolean[]>(this.baseUrl + "getUserRole").subscribe(result => {
      this.authorization = result;
      console.log({ result });
      if (this.authorization[0] == true) {
        this.authorize = true;
      }
      if (this.authorize == true) {
        this.httpClient.post<Ticket>(
          this.baseUrl + "tickets/create",
          {
            title: this.title.value,
            description: this.description.value,
          },
          { headers: { "Content-Type": "application/x-www-form-urlencoded" } }
        )
          .subscribe(
            (result) => {
              console.log("Success");
              this.result = "Successfully added the ticket";
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
  }

interface Ticket {
  id: number;
  owner: string,
  title: string;
  description: number;
}

interface Project {
  id: number;
  projectname: string;
}

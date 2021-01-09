import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-devlist-component',
  templateUrl: './devlist.component.html'
})
export class DevlistComponent {

  private readonly httpClient: HttpClient;
  private readonly baseUrl: string;

  public developers: SoftwareDeveloper[];
  public projects: Project[];
  public count: number;
  public authorization: boolean[];
  public authorize = false;
  public result = "";
  public name = new FormControl(null);

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
        http.get<SoftwareDeveloper[]>(baseUrl + 'softwareDevelopers').subscribe(result => {
          this.developers = result;
          this.count = this.developers.length;
          console.log({ result });
        }, error => console.error(error));
      }
      else {
        this.router.navigateByUrl('/no-authorization');
      }
    }, error => console.error(error));

    http.get<boolean[]>(baseUrl + "getUserRole").subscribe(result2 => {
      this.authorization = result2;
      console.log({ result2 });
      if (this.authorization[0] == true) {
        this.authorize = true;
      }
      if (this.authorize == true) {
        http.get<Project[]>(baseUrl + "projects").subscribe(result2 => {
          this.projects = result2;
          console.log({ result2 });
        }, error => console.error(error));
      }
      else {
        this.router.navigateByUrl('/no-authorization');
      }
    }, error => console.error(error));
  }

  public CreateProject() {
    this.httpClient.post<Project>(
      this.baseUrl + "projects/create",
      {
        name: this.name.value,
      },
      { headers: { "Content-Type": "application/x-www-form-urlencoded" } }
    )
      .subscribe(
        (result) => {
          console.log("Success");
          this.result = "Successfully added the project!";
        },
        (error) => {
          this.result = "Something went wrong with your request!";
          console.error(error);
        }
      )
  }
  }

interface SoftwareDeveloper {
  id: number;
  name: string;
  email: string,
  hireYear: number;
  role: string;
  projectId: number;
}

interface Project {
  id: number;
  projectname: string;
}

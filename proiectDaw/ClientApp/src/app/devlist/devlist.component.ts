import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-devlist-component',
  templateUrl: './devlist.component.html'
})
export class DevlistComponent {
  public developers: SoftwareDeveloper[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<SoftwareDeveloper[]>(baseUrl + 'softwareDevelopers').subscribe(result => {
      this.developers = result;
      console.log({ result });
    }, error => console.error(error));
  }
  }


interface SoftwareDeveloper {
  id: number;
  name: string;
  hireYear: number;
  projectId: number;
}

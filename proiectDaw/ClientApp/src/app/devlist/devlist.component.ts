import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-devlist-component',
  templateUrl: './devlist.component.html'
})
export class DevlistComponent {
  public developers: SoftwareDeveloper[];
  public count: number;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<SoftwareDeveloper[]>(baseUrl + 'softwareDevelopers').subscribe(result => {
      this.developers = result;
      this.count = this.developers.length;
      console.log({ result });
    }, error => console.error(error));
  }
  }


interface SoftwareDeveloper {
  id: number;
  name: string;
  email: string,
  hireYear: number;
  projectId: number;
}

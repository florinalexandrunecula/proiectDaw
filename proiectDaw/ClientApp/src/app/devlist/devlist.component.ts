import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-devlist-component',
  templateUrl: './devlist.component.html'
})
export class DevlistComponent {
  public developers: SoftwareDeveloper[];
  public test = new FormControl(null);

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<SoftwareDeveloper[]>(baseUrl + 'softwareDevelopers').subscribe(result => {
      this.developers = result;
      console.log({ result });
    }, error => console.error(error));
  }
  public buttonClicked() {
    console.log({ test: this.test.value });
  }
  }


interface SoftwareDeveloper {
  id: number;
  name: string;
  email: string,
  hireYear: number;
  projectId: number;
}

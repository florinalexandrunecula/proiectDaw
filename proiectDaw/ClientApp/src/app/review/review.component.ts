import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-review-component',
  templateUrl: './review.component.html'
})
export class ReviewComponent {

  private readonly httpClient: HttpClient;
  private readonly baseUrl: string;

  public authorization: boolean[];
  public authorize = false;
  public result = "";
  public owner = new FormControl(null);
  public description = new FormControl(null);
  public rating = new FormControl(null);
  public reviews: Review[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private router: Router) {

    this.httpClient = http;
    this.baseUrl = baseUrl;

    http.get<Review[]>(baseUrl + "reviews").subscribe(result => {
      this.reviews = result;
    });

  }

  public CreateReview() {
    this.httpClient.post<Review>(
      this.baseUrl + "reviews/create",
      {
        owner: this.owner.value,
        description: this.description.value,
        rating: this.rating.value,
      },
      { headers: { "Content-Type": "application/x-www-form-urlencoded" } }
    )
      .subscribe(
        (result) => {
          console.log("Success");
          this.result = "Successfully submitted the review";
        },
        (error) => {
          this.result = "Something went wrong with your request!";
          console.error(error);
        }
      );
  }
  }

interface Review {
  id: number;
  owner: string,
  description: number;
  rating: number;
}

interface Project {
  id: number;
  projectname: string;
}

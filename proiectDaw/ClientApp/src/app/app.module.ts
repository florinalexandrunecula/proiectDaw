import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { DevlistComponent } from './devlist/devlist.component';
import { HirePageComponent } from './hire-page/hire-page.component';
import { FirePageComponent } from './fire-page/fire-page.component';
import { NoAuthorizationComponent } from './no-authorization/no-authorization.component';
import { UpdatePageComponent } from './update-page/update-page.component';
import { VacationComponent } from './vacation/vacation.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    DevlistComponent,
    HirePageComponent,
    FirePageComponent,
    NoAuthorizationComponent,
    UpdatePageComponent,
    VacationComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule, 
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthorizeGuard] },
      { path: 'devlist', component: DevlistComponent, canActivate: [AuthorizeGuard] },
      { path: 'hirepage', component: HirePageComponent, canActivate: [AuthorizeGuard] },
      { path: 'firepage', component: FirePageComponent, canActivate: [AuthorizeGuard] },
      { path: 'no-authorization', component: NoAuthorizationComponent },
      { path: 'updatepage', component: UpdatePageComponent, canActivate: [AuthorizeGuard] },
      { path: 'vacation', component: VacationComponent, canActivate: [AuthorizeGuard] },
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

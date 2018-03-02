# Data Service
Most of our data will come from Web APIs. In this lab, we will create a very simple data service in Angular, and create widgets using the results.

## Step 1
We will use the CLI to generate our service. Open bash or console at the root of the project and execute the following command:

`yarn ng generate service core/bacon-api --flat false --module core/core.module`

## Step 2
The CLI generated our service, but we will need to import `HttpClientModule` to make REST calls.

Navigate to `core/core.module.ts`.

```typescript
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http'; // Add me
import { BaconApiService } from './bacon-api/bacon-api.service';

@NgModule({
  imports: [
    CommonModule,
    HttpClientModule, // Add me
  ],
  declarations: [],
  providers: [BaconApiService]
})
export class CoreModule { }
```

Also, update our core folder's `public-api.ts` to export the `bacon-api.service`. This will make it easier to reference the api in our components.

```typescript
export * from './test';
export * from './core.module';
export * from './bacon-api/bacon-api.service';
```

## Step 3
Now let's update our empty `bacon-api.service.ts` to make a GET call to our API.

We will be using the [**Bacon Ipsum JSON API**](https://baconipsum.com/json-api/). Feel free to experiment, but this lab will settle with the following code.

```typescript
import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

/**
 * Using our baconipsum API
 *
 * https://baconipsum.com/json-api/
 */
@Injectable()
export class BaconApiService {
  constructor(private httpClient: HttpClient) { }

  giveBacon(paras = 1): Observable<string[]> {
    // Note: we had to have define the params manually for this API to avoid a CORS redirect issue
    return this.httpClient
      .get<string[]>(`https://baconipsum.com/api/?type=all-meat-and-filler&paras=${paras.toString()}`);
  }
}
```

## Step 4
Update the `debug-page.component.ts` to use our `BaconApiService`.

```typescript
import { Component, OnInit } from '@angular/core';
import { BaconApiService } from '@core';

@Component({
  selector: 'app-debug-page',
  templateUrl: './debug-page.component.html',
  styleUrls: ['./debug-page.component.css']
})
export class DebugPageComponent implements OnInit {
  widgets: string[] = [
    'My Plan ol Widget',
    'Is this really necessary?',
    'How many should I make?'
  ];

  constructor(private baconAPI: BaconApiService) { }

  ngOnInit() {
    this.baconAPI.giveBacon(10).subscribe(paras => this.widgets = paras);
  }
}
```

Now we're getting our widgets from the API!


![alt text][demo]

[demo]: assets/4-with-bacon.png
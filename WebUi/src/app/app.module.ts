import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SharedService} from './shared.service'

import { HttpClientModule } from '@angular/common/http'
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { SortingComponent } from './sorting/sorting.component';
import { NgxChartsModule }  from '@swimlane/ngx-charts';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
 
@NgModule({
  declarations: [
    AppComponent,
    SortingComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgxChartsModule,
    BrowserAnimationsModule 
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }

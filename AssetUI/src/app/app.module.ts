import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { HelloComponent } from './hello.component';
import { AddAssertComponent } from './components/add-assert-component/add-assert.component';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { AssetAPIService } from './services/asset-api.service';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  imports: [BrowserModule, ReactiveFormsModule, CommonModule, HttpClientModule],
  declarations: [AppComponent, HelloComponent, AddAssertComponent],
  providers: [AssetAPIService],
  bootstrap: [AppComponent]
})
export class AppModule {}

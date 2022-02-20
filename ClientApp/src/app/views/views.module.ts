import { MatTableModule } from '@angular/material/table';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormProcessComponent } from './form-process/form-process.component';
import { HomeComponent } from './home/home.component';
import { ViewsRoutingModule } from './views-routing.module';
import { MatButtonModule } from '@angular/material';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatCardModule} from '@angular/material/card';

@NgModule({
  declarations: [
    FormProcessComponent,
    NavMenuComponent,
    HomeComponent
  ],
  imports: [
    CommonModule,

    MatTableModule,
    MatButtonModule,
    MatFormFieldModule,
    MatCardModule,

    ViewsRoutingModule
  ],
  exports: [NavMenuComponent]
})
export class ViewsModule { }

import { NgModule } from '@angular/core';

import { RouterModule, Routes } from '@angular/router';
import { FormProcessComponent } from './form-process/form-process.component';
import { HomeComponent } from './home/home.component';

const routes : Routes = [
  { path: '', component: HomeComponent},
  { path: 'newProcess', component: FormProcessComponent },
  { path: 'editProcess/:id', component: FormProcessComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ViewsRoutingModule { }

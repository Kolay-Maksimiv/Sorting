import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SortingComponent } from './sorting/sorting.component';

const routes: Routes = [
  {path:'',component: SortingComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

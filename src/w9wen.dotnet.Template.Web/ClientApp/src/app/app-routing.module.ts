import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeCreateComponent } from './employee/employee-create/employee-create.component';
import { EmployeeEditComponent } from './employee/employee-edit/employee-edit.component';
import { EmployeePanelComponent } from './employee/employee-panel/employee-panel.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: "", component: HomeComponent },
  {
    path: "",
    children: [
      { path: "employees", component: EmployeePanelComponent },
      { path: "employee/edit", component: EmployeeEditComponent },
      { path: "employees/create", component: EmployeeCreateComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

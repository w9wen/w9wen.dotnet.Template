import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs';
import { UserModel } from 'src/app/_models/user-model';
import { AccountService } from 'src/app/_services/account.service';
import { EmployeeModel } from '../employee.Model';
import { EmployeeService } from '../employee.service';

@Component({
  selector: 'app-employee-edit',
  templateUrl: './employee-edit.component.html',
  styleUrls: ['./employee-edit.component.css']
})
export class EmployeeEditComponent implements OnInit {
  userItem: UserModel;
  employeeItem: EmployeeModel;

  constructor(
    private employeeService: EmployeeService,
    private accountService: AccountService,
    private toastrService: ToastrService) {

    this.accountService.currentUser$.pipe(take(1)).subscribe({
      next: (response) => {
        this.userItem = response;
      },
    });

  }

  ngOnInit(): void {
    this.loadEmployee();
  }

  loadEmployee() {
    this.employeeService.getEmployee(this.userItem.userName).subscribe({
      next: (response) => {
        this.employeeItem = response;
      },
    });
  }

}

import { Component, OnInit, ViewChild, HostListener } from '@angular/core';
import { NgForm } from '@angular/forms';
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
  @ViewChild('editForm') editForm: NgForm;
  userItem: UserModel;
  employeeItem: EmployeeModel;

  @HostListener('window:beforeunload', ['$event']) unloadNotification($event: any) {
    if (this.editForm.dirty) {
      $event.returnValue = true;
    }
  }

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

  updateEmployee() {
    this.employeeService.updateEmployee(this.employeeItem).subscribe({
      complete: () => {
        this.toastrService.success('Profile updated completed');
      },
      next: () => {
        this.toastrService.success('Profile updated successfully');
      },
    });
  }

}

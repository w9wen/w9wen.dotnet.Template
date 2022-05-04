import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { EmployeeService } from '../employee.service';

@Component({
  selector: 'app-employee-create',
  templateUrl: './employee-create.component.html',
  styleUrls: ['./employee-create.component.css']
})
export class EmployeeCreateComponent implements OnInit {
  @Output() cancelCreate = new EventEmitter();
  createForm: FormGroup;
  maxDate: Date;
  validationErrors: string[] = [];


  constructor(
    private employeeService: EmployeeService,
    private formBuilder: FormBuilder,
    private router: Router) { }

  ngOnInit(): void {
    this.initializeForm();
    this.maxDate = new Date();
    this.maxDate.setFullYear(this.maxDate.getFullYear() - 18);
  }

  initializeForm() {
    this.createForm = this.formBuilder.group({
      gender: ["male"],
      userName: ["", Validators.required],
      phoneNumber: [""],
      email: [""],
      dateOfBirth: [""],
      city: [""],
      country: [""]
    });
  }

  createEmployee() {
    this.employeeService.createEmployee(this.createForm.value).subscribe({
      next: (response) => {
        console.log(response);
        this.router.navigateByUrl("/employees");
      },
      error: (errors) => {
        this.validationErrors = errors;
      }
    });
  }

  cancel() {
    this.cancelCreate.emit(false);
  }
}

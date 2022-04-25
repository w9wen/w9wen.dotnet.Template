import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { EmployeeModel } from './employee.Model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getEmployee(userName: string) {
    return this.http.get<EmployeeModel>(this.baseUrl + "Employee/" + userName);
  }

  updateEmployee(employee: EmployeeModel) {
    return this.http.put(this.baseUrl + "Employee", employee).pipe(
      map(() => {
        // Store employee in list here.
      })
    );
  }
}

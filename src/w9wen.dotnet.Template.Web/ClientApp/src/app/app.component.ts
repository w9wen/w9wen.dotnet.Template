import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ProjectListResponse } from './_models/project-list-response.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'W9WEN App';
  projectDto: ProjectListResponse;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getProject();
  }
  
  getProject() {
    this.http.get<ProjectListResponse>("https://localhost:5001/Projects").subscribe({
      complete: () => { },
      error: () => { },
      next: (response) => {
        this.projectDto = response;
      },
    });
  }
}

import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ProjectDto } from './_models/project-dto.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'W9WEN App';
  project: ProjectDto;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getProject();
  }
  
  getProject() {
    this.http.get<ProjectDto>("http://localhost:57679/Projects").subscribe(response => {
      this.project = response;
    }, error => {
      console.log(error);
    })
  }
}

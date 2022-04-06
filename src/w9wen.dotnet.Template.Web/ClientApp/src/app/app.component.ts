import { Component, OnInit } from '@angular/core';
import { Project, ProjectListResponse } from './_models/project-list-response.model';
import { ProjectResponse } from './_models/project-response.model';
import { ConfirmService } from './_services/confirm.service';
import { ProjectService } from './_services/project.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'W9WEN App';
  projectListResponse: ProjectListResponse;
  projectResponse: ProjectResponse;

  constructor(private projectService: ProjectService, private confirmService: ConfirmService) { }

  ngOnInit(): void {
    this.getProjects();
  }

  getProjects() {
    this.projectService.getProjects().subscribe({
      complete: () => { },
      error: () => { },
      next: (response) => {
        this.projectListResponse = response;
      },
    })
  }

  getProject() {
    this.projectService.getProject(5).subscribe({
      complete: () => { },
      error: () => { },
      next: (response) => {
        this.projectResponse = response;
      },
    });
  }

  createProject() {
    var name = "From Code";
    this.projectService.createProject(name).subscribe({
      complete: () => { },
      error: () => { },
      next: (response) => {
        console.log("create success : " + response);
      },
    });
  }

  updateProject() {
    var project: Project = { id: 9, name: "Update From Code" };
    this.projectService.updateProject(project).subscribe({
      complete: () => { },
      error: () => { },
      next: (response) => {
        console.log("update success");
      },
    });
  }

  deleteProject(id: number) {
    this.confirmService.confirm('Confirm delete project', 'This cannot be undone').subscribe(result => {
      if (result) {
        this.projectService.deleteProject(id).subscribe({
          complete: () => { },
          error: () => { },
          next: (response) => {
            console.log(response);
          },
        });
      }

      // if (result) {
      //   this.messageService.deleteMessage(id).subscribe(() => {
      //     this.messages.splice(this.messages.findIndex(m => m.id === id), 1);
      //   })
      // }
    })

  }
}

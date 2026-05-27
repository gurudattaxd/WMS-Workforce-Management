import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { Router } from '@angular/router';
import { DepartmentService } from '../../services/department';

@Component({
  selector: 'app-department-list',
  standalone: true,
  imports: [
    CommonModule, FormsModule, MatTableModule,
    MatCardModule, MatIconModule, MatButtonModule,
    MatInputModule, MatFormFieldModule
  ],
  templateUrl: './department-list.html',
  styleUrl: './department-list.scss'
})
export class DepartmentListComponent implements OnInit {
  departments: any[] = [];
  displayedColumns = ['departmentId', 'departmentName', 'description', 'actions'];
  showForm = false;
  newDepartment = { departmentName: '', description: '' };

  constructor(private departmentService: DepartmentService, private router: Router) {}

  ngOnInit(): void {
    this.loadDepartments();
  }

  loadDepartments(): void {
    this.departmentService.getAll().subscribe({
      next: (data) => this.departments = data,
      error: (err) => console.error(err)
    });
  }

  addDepartment(): void {
    this.departmentService.create(this.newDepartment).subscribe({
      next: () => {
        this.loadDepartments();
        this.showForm = false;
        this.newDepartment = { departmentName: '', description: '' };
      },
      error: (err) => console.error(err)
    });
  }

  deleteDepartment(id: number): void {
    if (confirm('Delete this department?')) {
      this.departmentService.delete(id).subscribe({
        next: () => this.loadDepartments(),
        error: (err) => console.error(err)
      });
    }
  }

  goBack(): void {
    this.router.navigate(['/dashboard']);
  }
}
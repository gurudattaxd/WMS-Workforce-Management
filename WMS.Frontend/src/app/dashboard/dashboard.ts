import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { Router, RouterModule } from '@angular/router';
import { AuthService } from '../services/auth';
import { EmployeeService } from '../services/employee';
import { DepartmentService } from '../services/department';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatIconModule, MatButtonModule, RouterModule],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.scss'
})
export class DashboardComponent implements OnInit {
  username = '';
  role = '';

  stats = [
    { title: 'Total Employees', value: 0, icon: 'people', color: '#1976d2' },
    { title: 'Present Today', value: 0, icon: 'check_circle', color: '#388e3c' },
    { title: 'On Leave', value: 0, icon: 'event_busy', color: '#f57c00' },
    { title: 'Departments', value: 0, icon: 'business', color: '#7b1fa2' },
  ];

  constructor(
    private authService: AuthService,
    private router: Router,
    private employeeService: EmployeeService,
    private departmentService: DepartmentService
  ) {}

  ngOnInit(): void {
    const user = this.authService['currentUserSubject'].value;
    this.username = user?.username ?? '';
    this.role = user?.role ?? '';
    this.loadStats();
  }

  loadStats(): void {
    this.employeeService.getAll().subscribe({
      next: (data) => this.stats[0].value = data.length
    });
    this.departmentService.getAll().subscribe({
      next: (data) => this.stats[3].value = data.length
    });
  }

  navigate(path: string): void {
    this.router.navigate([path]);
  }

  logout(): void {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
}
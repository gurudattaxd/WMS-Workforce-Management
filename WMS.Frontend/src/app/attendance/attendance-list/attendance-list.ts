import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { Router } from '@angular/router';
import { AttendanceService } from '../../services/attendance';

@Component({
  selector: 'app-attendance-list',
  standalone: true,
  imports: [CommonModule, MatTableModule, MatCardModule, MatIconModule, MatButtonModule],
  templateUrl: './attendance-list.html',
  styleUrl: './attendance-list.scss'
})
export class AttendanceListComponent implements OnInit {
  attendances: any[] = [];
  displayedColumns = ['attendanceId', 'employeeName', 'checkIn', 'checkOut', 'totalHours', 'workMode'];

  constructor(private attendanceService: AttendanceService, private router: Router) {}

  ngOnInit(): void {
    this.attendanceService.getAll().subscribe({
      next: (data) => this.attendances = data,
      error: (err) => console.error(err)
    });
  }

  goBack(): void {
    this.router.navigate(['/dashboard']);
  }
}
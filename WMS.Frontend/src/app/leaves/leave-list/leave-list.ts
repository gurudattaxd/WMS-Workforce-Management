import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { Router } from '@angular/router';
import { LeaveService } from '../../services/leave';

@Component({
  selector: 'app-leave-list',
  standalone: true,
  imports: [CommonModule, MatTableModule, MatCardModule, MatIconModule, MatButtonModule],
  templateUrl: './leave-list.html',
  styleUrl: './leave-list.scss'
})
export class LeaveListComponent implements OnInit {
  leaves: any[] = [];
  displayedColumns = ['leaveId', 'employeeName', 'leaveType', 'fromDate', 'toDate', 'status', 'actions'];

  constructor(private leaveService: LeaveService, private router: Router) {}

  ngOnInit(): void {
    this.leaveService.getAll().subscribe({
      next: (data) => this.leaves = data,
      error: (err) => console.error(err)
    });
  }

  approveLeave(id: number): void {
    this.leaveService.updateStatus(id, { status: 'Approved', approvedBy: 1 }).subscribe({
      next: () => this.ngOnInit()
    });
  }

  rejectLeave(id: number): void {
    this.leaveService.updateStatus(id, { status: 'Rejected', approvedBy: 1 }).subscribe({
      next: () => this.ngOnInit()
    });
  }

  goBack(): void {
    this.router.navigate(['/dashboard']);
  }
}
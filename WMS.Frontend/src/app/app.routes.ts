import { Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login';
import { DashboardComponent } from './dashboard/dashboard';
import { EmployeeListComponent } from './employees/employee-list/employee-list';
import { AttendanceListComponent } from './attendance/attendance-list/attendance-list';
import { LeaveListComponent } from './leaves/leave-list/leave-list';
import { DepartmentListComponent } from './departments/department-list/department-list';
import { AuthGuard } from './guards/auth-guard';

export const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard] },
  { path: 'employees', component: EmployeeListComponent, canActivate: [AuthGuard] },
  { path: 'attendance', component: AttendanceListComponent, canActivate: [AuthGuard] },
  { path: 'leaves', component: LeaveListComponent, canActivate: [AuthGuard] },
  { path: 'departments', component: DepartmentListComponent, canActivate: [AuthGuard] },
  { path: '**', redirectTo: 'login' }
];
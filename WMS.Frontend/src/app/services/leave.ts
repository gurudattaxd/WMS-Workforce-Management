import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class LeaveService {
  private apiUrl = 'https://localhost:7231/api/Leave';

  constructor(private http: HttpClient) {}

  getAll(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  getByEmployee(empId: number): Observable<any[]> {
    return this.http.get<any[]>(`${this.apiUrl}/employee/${empId}`);
  }

  create(data: any): Observable<any> {
    return this.http.post<any>(this.apiUrl, data);
  }

  updateStatus(id: number, data: any): Observable<any> {
    return this.http.put<any>(`${this.apiUrl}/${id}/status`, data);
  }

  delete(id: number): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/${id}`);
  }
}
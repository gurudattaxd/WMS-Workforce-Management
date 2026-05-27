SELECT a.AttendanceId, e.FirstName + ' ' + e.LastName as EmployeeName, 
a.CheckIn, a.CheckOut, a.TotalHours, a.WorkMode
FROM Attendances a
JOIN Employees e ON a.EmpId = e.EmployeeId
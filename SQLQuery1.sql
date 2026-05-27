-- Insert Roles (already seeded but let's make sure)
IF NOT EXISTS (SELECT 1 FROM Roles WHERE RoleId = 1)
INSERT INTO Roles (RoleName, Description) VALUES 
('Admin', 'Administrator'),
('Manager', 'Manager'),
('Employee', 'Employee')

-- Insert Departments
IF NOT EXISTS (SELECT 1 FROM Departments WHERE DepartmentName = 'Engineering')
INSERT INTO Departments (DepartmentName, Description, CreatedOn) VALUES 
('Engineering', 'Software Engineering Team', GETDATE()),
('Human Resources', 'HR Department', GETDATE()),
('Finance', 'Finance and Accounts', GETDATE()),
('Marketing', 'Marketing and Sales', GETDATE()),
('Operations', 'Operations Team', GETDATE())

-- Insert Employees
INSERT INTO Employees (FirstName, LastName, Email, PhoneNumber, Gender, DOB, DOJ, DepartmentId, RoleId, Status, CreatedOn) VALUES
('Rahul', 'Sharma', 'rahul.sharma@wms.com', '9876543210', 'M', '1995-05-15', '2022-01-10', 1, 2, 'Active', GETDATE()),
('Priya', 'Patel', 'priya.patel@wms.com', '9876543211', 'F', '1997-08-20', '2022-03-15', 2, 3, 'Active', GETDATE()),
('Amit', 'Kumar', 'amit.kumar@wms.com', '9876543212', 'M', '1994-03-10', '2021-06-01', 1, 3, 'Active', GETDATE()),
('Sneha', 'Desai', 'sneha.desai@wms.com', '9876543213', 'F', '1996-11-25', '2022-07-20', 3, 3, 'Active', GETDATE()),
('Vikram', 'Singh', 'vikram.singh@wms.com', '9876543214', 'M', '1993-07-12', '2020-09-05', 4, 2, 'Active', GETDATE()),
('Anita', 'Joshi', 'anita.joshi@wms.com', '9876543215', 'F', '1998-02-28', '2023-01-15', 2, 3, 'Active', GETDATE()),
('Raj', 'Mehta', 'raj.mehta@wms.com', '9876543216', 'M', '1992-09-18', '2020-04-10', 5, 2, 'Active', GETDATE()),
('Pooja', 'Verma', 'pooja.verma@wms.com', '9876543217', 'F', '1999-04-05', '2023-06-01', 1, 3, 'Active', GETDATE()),
('Suresh', 'Nair', 'suresh.nair@wms.com', '9876543218', 'M', '1991-12-30', '2019-11-20', 3, 3, 'Active', GETDATE()),
('Deepa', 'Rao', 'deepa.rao@wms.com', '9876543219', 'F', '1996-06-14', '2022-09-10', 4, 3, 'Active', GETDATE())

-- Insert Clients
INSERT INTO Clients (ClientName, ClientAddress, ClientPhoneNumber, ClientLocation, Status) VALUES
('TechCorp Solutions', '123 Tech Park, Mumbai', '9000000001', 'Mumbai', 1),
('GlobalSoft Inc', '456 Business Bay, Pune', '9000000002', 'Pune', 1),
('InnovateTech', '789 IT Hub, Bangalore', '9000000003', 'Bangalore', 1)

-- Insert Projects
INSERT INTO Projects (ProjectName, ClientId, StartDate, EndDate, Status) VALUES
('ERP Implementation', 1, '2026-01-01', '2026-12-31', 'Active'),
('Mobile App Development', 2, '2026-02-01', '2026-08-31', 'Active'),
('Cloud Migration', 3, '2026-03-01', '2026-09-30', 'Active')

-- Insert Attendance for multiple employees
INSERT INTO Attendances (EmpId, CheckIn, CheckOut, TotalHours, WorkMode, AttendanceDate) VALUES
(3, '2026-05-27 09:00:00', '2026-05-27 18:00:00', 9.0, 'WFO', '2026-05-27'),
(4, '2026-05-27 09:30:00', '2026-05-27 18:30:00', 9.0, 'WFO', '2026-05-27'),
(5, '2026-05-27 08:45:00', '2026-05-27 17:45:00', 9.0, 'WFH', '2026-05-27'),
(6, '2026-05-27 10:00:00', '2026-05-27 19:00:00', 9.0, 'WFO', '2026-05-27'),
(7, '2026-05-27 09:15:00', '2026-05-27 18:15:00', 9.0, 'WFH', '2026-05-27'),
(3, '2026-05-26 09:00:00', '2026-05-26 18:00:00', 9.0, 'WFO', '2026-05-26'),
(4, '2026-05-26 09:30:00', '2026-05-26 17:30:00', 8.0, 'WFH', '2026-05-26'),
(5, '2026-05-26 08:45:00', '2026-05-26 17:45:00', 9.0, 'WFO', '2026-05-26'),
(8, '2026-05-26 09:00:00', '2026-05-26 18:00:00', 9.0, 'WFO', '2026-05-26'),
(9, '2026-05-26 10:00:00', '2026-05-26 19:00:00', 9.0, 'WFH', '2026-05-26')

-- Insert Leaves
INSERT INTO Leaves (EmpId, LeaveType, Reason, FromDate, ToDate, Status, AppliedOn) VALUES
(3, 'Sick', 'Fever and cold', '2026-05-28', '2026-05-29', 'Pending', GETDATE()),
(4, 'Casual', 'Personal work', '2026-05-30', '2026-05-30', 'Approved', GETDATE()),
(5, 'Earned', 'Family vacation', '2026-06-01', '2026-06-05', 'Pending', GETDATE()),
(6, 'Sick', 'Doctor appointment', '2026-05-28', '2026-05-28', 'Approved', GETDATE()),
(7, 'Casual', 'Personal emergency', '2026-05-29', '2026-05-29', 'Rejected', GETDATE()),
(8, 'Earned', 'Annual leave', '2026-06-10', '2026-06-15', 'Pending', GETDATE())

-- Insert Employee Project Allocations
INSERT INTO EmployeeProjects (EmpId, ProjectId, AssignedOn, CreateDate, CreatedBy, Status) VALUES
(3, 1, '2026-01-01', '2026-01-01', 'admin', 1),
(4, 1, '2026-01-01', '2026-01-01', 'admin', 1),
(5, 2, '2026-02-01', '2026-02-01', 'admin', 1),
(6, 2, '2026-02-01', '2026-02-01', 'admin', 1),
(7, 3, '2026-03-01', '2026-03-01', 'admin', 1),
(8, 3, '2026-03-01', '2026-03-01', 'admin', 1)

-- Insert Announcements
INSERT INTO Announcements (Title, Message, CreatedBy, CreatedOn, IsActive) VALUES
('Welcome to WMS', 'Welcome to the new Workforce Management System!', 1, GETDATE(), 1),
('Holiday Notice', 'Office will be closed on June 15th for a public holiday.', 1, GETDATE(), 1),
('Training Session', 'Mandatory training session on June 20th at 10 AM.', 1, GETDATE(), 1)

-- Insert User Logins for employees
INSERT INTO UserLogins (Username, PasswordHash, RoleId) VALUES
('manager1', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 2),
('employee1', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 3),
('employee2', 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 3)

PRINT 'Data inserted successfully!'
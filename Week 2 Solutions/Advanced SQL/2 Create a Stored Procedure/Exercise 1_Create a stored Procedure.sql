use DeepSkilling;
---Step 1---
Go
create procedure GetEmployeeDetails
	@DepartmentID int
as
begin select * from employees where departmentID=@DepartmentID;
END;
Go

---step2---
exec GetEmployeeDetails @DepartmentID=1;

---step 3---
Go
CREATE PROCEDURE sp_InsertEmployee
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @DepartmentID INT,
    @Salary DECIMAL(10, 2),
    @JoinDate DATE
AS
BEGIN
    INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate)
    VALUES (@FirstName, @LastName, @DepartmentID, @Salary, @JoinDate);
END;






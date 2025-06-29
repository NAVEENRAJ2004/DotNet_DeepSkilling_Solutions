use DeepSkilling;

--Step 1--
Go
create procedure GetEmployeeDetailCount
	@DepartmentID int
as
begin
	select count(*) as EmployeeCount from Employees
	where DepartmentID=@DepartmentID;
end

--Step 2--
exec GetEmployeeDetailCount @DepartmentID=2;
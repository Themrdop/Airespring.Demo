public static class Api
{
    public static void ConfigureApi(this WebApplication app)
    {
        app.MapGet("/api/Employees/", getEmployees);
        app.MapGet("/api/Employee/{id}", getEmployee);
        app.MapDelete("/api/Employee/{id}", DeleteEmployee);
        app.MapPost("/api/Employee/", InsertEmployee);
        app.MapPut("/api/Employee/", updateEmployee);
    }

    private static async Task<IResult> getEmployees(IEmployeeProvider employeeProvider, CancellationToken cancellationToken)
    {
        try
        {
            var response = await employeeProvider.GetEmployees(cancellationToken);

            if (response.Count() > 0)
            {
                return Results.Ok(response);
            }
            else
            {
                return Results.NotFound("No employee found");
            }
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> getEmployee(Guid id, IEmployeeProvider employeeProvider, CancellationToken cancellationToken)
    {
        try
        {
            var response = await employeeProvider.GetEmployee(id,cancellationToken);

            if (response is not null)
            {
                return Results.Ok(response);
            }
            else
            {
                return Results.NotFound("Employee not found");
            }
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> updateEmployee(Employee employee, 
                                                      IEmployeeProvider employeeProvider, 
                                                      CancellationToken cancellationToken)
    {
        try
        {
            await employeeProvider.UpdateEmployee(employee, cancellationToken);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteEmployee(Guid id, 
                                                      IEmployeeProvider employeeProvider, 
                                                      CancellationToken cancellationToken)
    {
        try
        {
            await employeeProvider.DeleteEmployee(id, cancellationToken);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertEmployee(Employee employee,
                                                      IEmployeeProvider employeeProvider,
                                                      CancellationToken cancellationToken)
    {
        try
        {
            await employeeProvider.InsertEmployee(employee, cancellationToken);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}

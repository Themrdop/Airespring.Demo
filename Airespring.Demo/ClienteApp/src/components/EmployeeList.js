import React from 'react'

export const EmployeeList = ({ employees}) => {

    console.log('employee length:::', employees.length)
    if (employees.length === 0) return null

    const EmployeeRow = (employee) => {

        function format(value, pattern) {
            var i = 0,
                v = value.toString();
            return pattern.replace(/#/g, _ => i < v.length ? v[i++] : '');
        }

        return(
              <tr key={employee.id} >
                  <td>{employee.id}</td>
                  <td>{employee.firstName}</td>
                  <td>{employee.lastName}</td>
                  <td>{format(employee.phone,'(###) ###-####')}</td>
                  <td>{employee.zip}</td>
                  <td>{new Date(employee.hireDate).toLocaleDateString("en-US")}</td>
              </tr>
          )
    }

    const employeeTable = employees.map((employee,index) => EmployeeRow(employee,index))

    return(
        <div className="container">
            <h2>Employees</h2>
            <table className="table table-bordered">
                <thead>
                <tr>
                    <th>User Id</th>
                    <th>Firstname</th>
                    <th>Lastname</th>
                    <th>Phone</th>
                    <th>Zip</th>
                    <th>HireDate</th>
                </tr>
                </thead>
                <tbody>
                    {employeeTable}
                </tbody>
            </table>
        </div>
    )
}
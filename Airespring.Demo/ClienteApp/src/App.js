import React, { useState, useEffect } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';
import { EmployeeList } from './components/EmployeeList'
import AddEmployee from './components/AddEmployee'
import { getAllEmployees, createEmployee } from './services/EmployeeService'

function App() {

  const [employee, setEmployee] = useState({})
  const [employees, setEmployees] = useState([])


  const EmployeeCreate = (e) => {

      createEmployee(employee)
        .then(response => {
            fetchAllEmployees();
      });
  }

  const fetchAllEmployees = () => {
      getAllEmployees()
      .then(employee => {
        console.log(employee)
        setEmployees(employee);
      });
  }

  useEffect(() => {
      getAllEmployees()
      .then(employee => {
        console.log(employee)
        setEmployees(employee);
      });
  }, [])

  const onChangeForm = (e) => {
      if (e.target.id === 'FirstName') {
          employee.FirstName = e.target.value;
      } else if (e.target.id === 'LastName') {
          employee.LastName = e.target.value;
      } else if (e.target.id === 'Phone') {
          employee.Phone = e.target.value;
      } else if (e.target.id === 'Zip') {
          employee.Zip = e.target.value;
      } else if (e.target.id === 'HireDate') {
          employee.HireDate = e.target.value;
      }
      console.log(employee);
      setEmployee(employee)
  }
  
    
    return (
        <div className="App">
          <div className="container mrgnbtm">
            <div className="row">
              <div className="col-md-8">
                  <AddEmployee
                    user={employee}
                    onChangeForm={onChangeForm}
                    createEmployee={EmployeeCreate}
                    >
                  </AddEmployee>
              </div>
              <div className="col-md-4">
              </div>
            </div>
          </div>
          <div className="row mrgnbtm">
                <EmployeeList employees={employees}></EmployeeList>
          </div>
        </div>
    );
}

export default App;

import React from 'react'
import { Form } from 'react-bootstrap';


const AddEmployee = ({onChangeForm, createEmployee }) => {


    return(
        <div className="container">
            <div className="row">
                <div className="col-md-7 mrgnbtm">
                <h2>Create Employee</h2>
                <form>
                    <div className="row">
                        <Form.Group className="col-md-6" controlId="FirstName">
                            <Form.Label>First name</Form.Label>
                            <Form.Control type="name" placeholder="Enter first name" onChange={(e) => onChangeForm(e)}/>
                        </Form.Group>
                        <Form.Group className="col-md-6" controlId="LastName">
                            <Form.Label>Last name</Form.Label>
                            <Form.Control type="name" placeholder="Enter last name" onChange={(e) => onChangeForm(e)}/>
                        </Form.Group>
                    </div>
                    <div className="row">
                        <Form.Group className="col-md-6" controlId="Phone">
                            <Form.Label>Phone</Form.Label>
                            <Form.Control type="phone" data-mask="(999) 999-9999" placeholder="(999) 999-9999" onChange={(e) => onChangeForm(e)}/>
                        </Form.Group>
                        <Form.Group className="col-md-6" controlId="Zip">
                            <Form.Label>Zip code</Form.Label>
                            <Form.Control type="zip" placeholder="Enter zip code" onChange={(e) => onChangeForm(e)} />
                        </Form.Group>
                    </div>
                    <div className="row">
                        <Form.Group className="col-md-6" controlId="HireDate">
                            <Form.Label>Hire Date</Form.Label>
                            <Form.Control type="date" placeholder="Enter hire date" onChange={(e) => onChangeForm(e)} />
                        </Form.Group>
                    </div>
                        <div className="row">
                        <button type="button" onClick={(e) => createEmployee()} className="btn btn-danger">Create</button>
                    </div>
                </form>
                </div>
            </div>
        </div>
    )
}

export default AddEmployee;
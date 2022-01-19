
export async function getAllEmployees() {

    try{
        const response = await fetch('http://localhost:5195/api/Employees/');
        if (response.status !== 200) {
            return []
        }
        return await response.json();
    }catch(error) {
        return [];
    }
    
}

export async function createEmployee(data) {
    try {
        console.log('createEmployee');
        console.log(data);
        const response = await fetch('http://localhost:5195/api/Employee/', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });

        if (response.status !== 200) {
            return []
        }

        return await response.json();
    } catch (error) {
        return [];
    }
}
 import { Link } from "react-router-dom";
 import { useFetch } from "../hooks/useFetch"
 import Table from 'react-bootstrap/Table';
 import { URL_DELETE , URL_GET_ALL, enumPlan } from "../utils/config";
import { enumModel } from "../utils/config";
 
const Home = () => {

    const { data: items, loading , error } =  useFetch(URL_GET_ALL);

    const deleteItem = async (id) => {
      debugger
      try {
        const response = await fetch(URL_DELETE +id, {
          method: 'DELETE',
          headers: {
            'Content-Type': 'application/json',
          },
        });
  
        if (!response.ok) {
          throw new Error('Network response was not ok');
        }
  
        const data = await response.json();
        
        window.location.reload();

      } catch (error) {
          console.error('Error deleting the item:', error);
      }
    };    

    return (
      <div>
        {loading && <p>Carregando dados...</p>}
        {error && <p>{error}</p>}
    
          <Table striped bordered hover size="sm">
            <thead>
              <tr>
                <th>Id</th>
                <th>Chassi Code</th>
                <th>Fabricate Year</th>
                <th>Color</th>
                <th>Model</th>
                <th>Plan</th>
                <th>Delete</th>
              </tr>
            </thead>
            <tbody>
              { items && items.map((item, index) => (
                <tr key={index}> 
                  <td><Link to={`/trucks/${item.id}`}>{item.id} </Link></td>
                  <td><Link to={`/trucks/${item.id}`}>{item.chassi_Code} </Link></td>
                  <td>{item.fabricateyear}</td>
                  <td>{item.color}</td>
                  <td>{ enumModel.find(e=>e.id == item.model)?.name}</td>
                  <td>{ enumPlan.find(e => e.id === item.plan)?.name}</td>
                  <td><button class="btn btn-danger  btn-sm" onClick={() => deleteItem(item.id)}> delete </button></td>
                </tr>
              ))}
            </tbody>
          </Table>
        </div>
    );
  };
  
  export default Home;
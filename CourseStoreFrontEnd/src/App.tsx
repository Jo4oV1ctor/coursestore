import { useEffect, useState } from 'react'
import './App.css'
import axios from 'axios';

type Item = {
  id: number;
  name: string;
  price: number;
};

function App() {
  
  const[data, setData] = useState<Item[]>([]as Item[]);
  useEffect(() => {
    axios.get('http://localhost:5087/api/Product/GetAllProducts')
      .then(response => {
        setData(response.data);
      })
      .catch(error => {
        console.error(error);
      });
  }, []);
 return (
  <table>
    <thead>
      <tr>
        <th>ID</th>
        <th>Name</th>
        <th>Price</th>
      </tr>
    </thead>
    <tbody>
      {data.map(item => (
        <tr key={item.id}>
          <td>{item.id}</td>
          <td>{item.name}</td>
          <td>{item.price}</td>
        </tr>
      ))}
    </tbody>
  </table>
);
}

export default App

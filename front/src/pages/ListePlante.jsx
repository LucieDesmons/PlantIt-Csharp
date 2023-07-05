import React, { useState, useEffect } from 'react'
import Navbar from '../components/Navbar'
import ItemPlante from '../components/ItemPlante'
import "../style/ItemPlante.css"
import "../style/ListePlante.css"
//import useApi from './useApi';

function ListePlante({ listePlantes }) {
  listePlantes += [{Id: 1, Name: "Ficus"}, {Id: 2, Name: "Arbre"}, {Id: 3, Name: "Weed"}, {Id: 4, Name: "Swamp Thing"}];
  //const { list, filter } = useApi();  //pour la connexion au backend
  const [plants, setPlants] = useState([])

  //FUCK !!!
  useEffect(() => {
    setPlants(listePlantes);
  },[listePlantes]);

  return (
    <div className='page'>
        <Navbar />
        <ul className='list-container'>
            {plants.map((plant) => (
                <ItemPlante plant={plant} plants={plants} setPlants={setPlants} />
            ))}
        </ul>
    </div>
  )
}

export default ListePlante
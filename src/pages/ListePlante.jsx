import React, { useState } from 'react'
import ItemPlante from '../components/ItemPlante'
import Navbar from '../components/Navbar'

import "../style/ListePlante.css"

function ListePlante() {

  const [plants, setPlants] = useState([1, 2, 3, 4, 5, 6, 7, 8, 9])


  return (
    <div className='page'>
      <h1>Mes plantes</h1>
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

import React, { useState, useEffect } from 'react'
import Navbar from '../components/Navbar'
import ItemPlante from '../components/ItemPlante'
import "../style/ItemPlante.css"
import "../style/ListePlante.css"

function ListePlante({ listePlantes }) {  //virer { listePlantes }
  listePlantes = [
    {imagePlante: "./images/rose.jpg", Name: "Rose"},
    {imagePlante: "./images/tulipe.jpg", Name: "Tulipe"},
    {imagePlante: "./images/baobab.jpg", Name: "Baobab"},
    {imagePlante: "./images/calypso.jpg", Name: "Calypso"},
    {imagePlante: "./images/monstera.jpg", Name: "Monstera Deliciosa"},
];

  //permet de pas tout planter si listePlantes arrive vide
  if (listePlantes == null) {
    listePlantes = [{imagePlante: "", Name: "NOM_PLANTE"}];
  }

  const [plants, setPlants] = useState(listePlantes)

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
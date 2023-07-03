import React from 'react'

import "../style/ItemPlante.css"


function ItemPlante({ plant, plants, setPlants }) {

    return (
        <div className='box-container'>
            <div className="img-container">
                <p style={{ margin: 0, textAlign: 'center' }}>{plant}</p>
            </div>
            <div className="name-container">
                <p style={{ margin: 0, textAlign: 'center', fontSize: "14px" }}>Plante n°666: Xx_Dark_Sasuke_xX</p>
            </div>
            <button className='add' type='button'>+</button>
            <button className='minus' type='button'>-</button>
        </div>
    )
}

export default ItemPlante

import React from 'react'
import "../style/ItemPlante.css"

function ItemPlante({ plant }) {

    return (
        <div className='box-container'>
            <div className="img-container">
                <p style={{ margin: 0, textAlign: 'center' }}>{plant}</p>
            </div>
            <div className="name-container">
                <p style={{ margin: 0, textAlign: 'center', fontSize: "14px" }}>Nom</p>
            </div>
        </div>
    )
}

export default ItemPlante

import React from 'react'
import "../style/navbar.css"

function Navbar() {
    return (
        <nav>
            <ul>
                <li>
                    Profil
                </li>
                <li>
                    Notifs
                </li>
                <li>
                    Messages
                </li>
            </ul>
        </nav>
    )
}

const nav = {
    //stick gauche
    height: 100,
    backgroundColor: "#14FF00"
}

export default Navbar;

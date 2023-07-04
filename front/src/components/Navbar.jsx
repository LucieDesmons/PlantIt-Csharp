import React from 'react'
import "../style/Navbar.css"
import FormInscription from '../pages/Register';

function Navbar() {
    
    const ClicProfil = () => {
        FormInscription();
    };

    return (
        <nav>
            <ul>
                <li onClick={ClicProfil}>
                    Profil
                </li>
                <li>
                    Notifications
                </li>
                <li>
                    Messages
                </li>
            </ul>
        </nav>
    )
}

export default Navbar;

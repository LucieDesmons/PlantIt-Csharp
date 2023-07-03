import React, { useState } from 'react';
import "../style/navbar.css"
import Navbar from '../components/Navbar';

const FormInscription = () => {
  const [prenom, setPrenom] = useState('');
  const [nom, setNom] = useState('');
  const [email, setEmail] = useState('');
  const [tel, setTel] = useState('');
  const [pseudo, setPseudo] = useState('');
  const [password, setPassword] = useState('');

  //envoi la saisie au back
  const handleSubmit = (e) => {
    e.preventDefault();
    //envoyer la saisie au back !!!
  };

  return (
    <div>
      <h1>Inscription</h1>
      <Navbar />
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          placeholder="Prénom"
          value={prenom}
          onChange={(e) => setPrenom(e.target.value)}
        />
        <br />
        <input
          type="text"
          placeholder="Nom"
          value={nom}
          onChange={(e) => setNom(e.target.value)}
        />
        <br />
      <input
          type="email"
          placeholder="Email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
        />
      <br />
      <label>
        Téléphone
        <input //faire un form de num !!!
          type="tel"
          value={tel}
          onChange={(e) => setTel(e.target.value)}
        />
      </label>
      <br />
      <input
          type="text"
          placeholder="Pseudo"
          value={pseudo}
          onChange={(e) => setPseudo(e.target.value)}
        />
      <br />
      <label>
        Mot de passe
        <input
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
        </label>
      <br />
      <button variant="primary" type="valider">
        Valider
      </button>
    </form>
    </div>
  );
};

export default FormInscription;
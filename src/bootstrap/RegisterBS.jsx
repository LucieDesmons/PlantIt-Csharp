import React, { useState } from 'react';
import { Form, Button } from 'react-bootstrap';

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
    <Form onSubmit={handleSubmit}>
      <Form.Group controlId="formPrenom">
        <Form.Control
          type="text"
          placeholder="Prénom"
          value={prenom}
          onChange={(e) => setPrenom(e.target.value)}
        />
      </Form.Group>
      <Form.Group controlId="formNom">
        <Form.Control
          type="text"
          placeholder="Nom"
          value={nom}
          onChange={(e) => setNom(e.target.value)}
        />
      </Form.Group>
      <Form.Group controlId="formEmail">
        <Form.Control
          type="email"
          placeholder="Email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
        />
      </Form.Group>
      <Form.Group controlId="formTel">
        <Form.Label>Téléphone</Form.Label>
        <Form.Control //faire un form de num !!!
          type="tel"
          value={tel}
          onChange={(e) => setTel(e.target.value)}
        />
      </Form.Group>
      <Form.Group controlId="formPseudo">
        <Form.Control
          type="text"
          placeholder="Pseudo"
          value={pseudo}
          onChange={(e) => setPseudo(e.target.value)}
        />
      </Form.Group>
      <Form.Group controlId="formPassword">
        <Form.Control
          type="password"   //!!!
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />
      </Form.Group>

      <Button variant="primary" type="valider">
        Valider
      </Button>
    </Form>
  );
};

export default FormInscription;
import React from 'react';
import { Container, Row, Col, Card } from 'react';
import "../style/navbar.css"
import Navbar from '../components/Navbar';

function Profil ({ user }) {
  return (
    <div>
      <h1>Profil</h1>
      <Navbar />
      <Container>
      <Row className="justify-content-center">
        <Col xs={12} sm={8} md={6}>
          <Card>
            <Card.Body>
              <Card.Title>Profil de {user.pseudo}</Card.Title>
              <Card.Text>
                <strong>Prénom : {user.prenom}</strong>
              </Card.Text>
              <Card.Text>
                <strong>Nom : {user.nom}</strong>
              </Card.Text>
              <Card.Text>
                <strong>Email : {user.mail}</strong>
              </Card.Text>
              <Card.Text>
                <strong>Téléphone : {user.tel}</strong>
              </Card.Text>
            </Card.Body>
          </Card>
        </Col>
      </Row>
    </Container>
    </div>    
  );
};

export default Profil;
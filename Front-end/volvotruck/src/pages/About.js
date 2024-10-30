import React from 'react';
import { Container, Row, Col, Card } from 'react-bootstrap';

const About = () => {
  return (
    <Container className="my-4">
    <Row>
      <Col md={8} className="mx-auto">
        <Card className="p-4">
          <Card.Body>
            <Card.Title as="h3">About</Card.Title>
            <Card.Text>
              This technical assessment aims to objectively and thoroughly evaluate the essential skills 
              and foundational knowledge expected from candidates for the position, ensuring a fair 
              and comprehensive analysis of the professional preparedness needed to make a significant 
              contribution to the team.
            </Card.Text>
            <Card.Title as="h3">LinkedIn</Card.Title>
            <Card.Text>
              <a href="https://www.linkedin.com/in/florisvaldo-santos/" target="_blank" rel="noopener noreferrer">
                https://www.linkedin.com/in/florisvaldo-santos/
              </a>
            </Card.Text>
          </Card.Body>
        </Card>
      </Col>
    </Row>
  </Container>
  );
};

export default About;

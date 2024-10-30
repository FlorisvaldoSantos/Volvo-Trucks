import { Nav , Navbar, Container , NavLink}  from 'react-bootstrap';
 
const MenuNavbar = () => {
  return (
    <div>
        <Navbar bg="dark" data-bs-theme="dark">
          <Container>
            <Navbar.Brand>
                <Nav.Link href="/"> Home </Nav.Link>
            </Navbar.Brand>
            <Nav className="me-auto">
                <NavLink  href="/trucks"> Truck </NavLink>
                <NavLink  href="/about"> About </NavLink>
            </Nav>
          </Container>
        </Navbar>
    </div>
    
  );
};

export default MenuNavbar;

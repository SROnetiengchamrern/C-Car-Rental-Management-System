import { NavLink } from 'react-router-dom';

export default function Navbar() {
  return (
    <header className="site-nav">
      <NavLink to="/" className="brand">
        Drive<span>Khmer</span>
      </NavLink>
      <nav>
        <NavLink to="/" end>
          Home
        </NavLink>
        <NavLink to="/fleet">Fleet</NavLink>
        <NavLink to="/contact">Contact</NavLink>
      </nav>
      <NavLink to="/fleet" className="nav-cta">
        Browse cars
      </NavLink>
    </header>
  );
}

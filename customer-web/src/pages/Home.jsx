import { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { api } from '../api';
import CarCard from '../components/CarCard';

const HERO_IMAGE =
  'https://images.unsplash.com/photo-1492144534655-ae79c964c9d7?auto=format&fit=crop&w=2000&q=80';

export default function Home() {
  const [cars, setCars] = useState([]);
  const [error, setError] = useState('');

  useEffect(() => {
    api
      .getCars({ status: 'Available' })
      .then((data) => setCars(data.slice(0, 6)))
      .catch((err) => setError(err.message));
  }, []);

  return (
    <>
      <section className="hero">
        <div className="hero-media" style={{ backgroundImage: `url(${HERO_IMAGE})` }} />
        <div className="hero-content">
          <p className="brand-mark">DriveKhmer</p>
          <h1>Drive Cambodia with confidence.</h1>
          <p className="hero-lead">
            Pick up in Phnom Penh, Siem Reap, or the coast — modern cars, clear daily rates.
          </p>
          <div className="hero-actions">
            <Link to="/fleet" className="btn-primary">
              Explore fleet
            </Link>
            <Link to="/contact" className="btn-ghost">
              Talk to us
            </Link>
          </div>
        </div>
      </section>

      <section className="section">
        <div className="section-head">
          <h2>Featured cars</h2>
          <p>Available now for your next trip.</p>
        </div>
        {error && <p className="error-banner">{error}. Is the API running on :5263?</p>}
        <div className="car-grid">
          {cars.map((car) => (
            <CarCard key={car.carId} car={car} />
          ))}
        </div>
        <div className="section-cta">
          <Link to="/fleet" className="btn-primary">
            See all cars
          </Link>
        </div>
      </section>
    </>
  );
}

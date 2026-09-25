import { useEffect, useState } from 'react';
import { api } from '../api';
import CarCard from '../components/CarCard';

export default function Fleet() {
  const [cars, setCars] = useState([]);
  const [categories, setCategories] = useState([]);
  const [categoryId, setCategoryId] = useState('');
  const [q, setQ] = useState('');
  const [error, setError] = useState('');
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    api.getCategories().then(setCategories).catch(() => {});
  }, []);

  useEffect(() => {
    setLoading(true);
    api
      .getCars({
        status: 'Available',
        categoryId: categoryId || undefined,
        q: q || undefined,
      })
      .then(setCars)
      .catch((err) => setError(err.message))
      .finally(() => setLoading(false));
  }, [categoryId, q]);

  return (
    <section className="section page-fleet">
      <div className="section-head">
        <h1>Our fleet</h1>
        <p>Filter by category or search make and model.</p>
      </div>

      <div className="fleet-toolbar">
        <input
          type="search"
          placeholder="Search cars…"
          value={q}
          onChange={(e) => setQ(e.target.value)}
        />
        <select value={categoryId} onChange={(e) => setCategoryId(e.target.value)}>
          <option value="">All categories</option>
          {categories.map((c) => (
            <option key={c.categoryId} value={c.categoryId}>
              {c.categoryName}
            </option>
          ))}
        </select>
      </div>

      {error && <p className="error-banner">{error}</p>}
      {loading ? (
        <p className="muted">Loading fleet…</p>
      ) : (
        <div className="car-grid">
          {cars.map((car) => (
            <CarCard key={car.carId} car={car} />
          ))}
        </div>
      )}
      {!loading && cars.length === 0 && <p className="muted">No cars match your filters.</p>}
    </section>
  );
}

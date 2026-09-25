import { useEffect, useState } from 'react';
import { Link, useParams } from 'react-router-dom';
import { api, resolveImage } from '../api';

export default function CarDetail() {
  const { id } = useParams();
  const [car, setCar] = useState(null);
  const [error, setError] = useState('');
  const [success, setSuccess] = useState('');
  const [submitting, setSubmitting] = useState(false);
  const [form, setForm] = useState({
    fullName: '',
    email: '',
    phone: '',
    startDate: '',
    endDate: '',
    notes: '',
  });

  useEffect(() => {
    api
      .getCar(id)
      .then(setCar)
      .catch((err) => setError(err.message));
  }, [id]);

  async function onSubmit(e) {
    e.preventDefault();
    setSubmitting(true);
    setError('');
    setSuccess('');
    try {
      const result = await api.createBooking({
        carId: Number(id),
        ...form,
      });
      setSuccess(`${result.message} Ref: ${result.reference}`);
      setForm((f) => ({ ...f, notes: '' }));
    } catch (err) {
      setError(err.message);
    } finally {
      setSubmitting(false);
    }
  }

  if (!car && !error) return <p className="section muted">Loading…</p>;
  if (!car) return <p className="section error-banner">{error}</p>;

  const image = resolveImage(car.imageUrl);
  const title = `${car.make} ${car.model}`;

  return (
    <section className="section car-detail">
      <Link to="/fleet" className="text-link back-link">
        ← Back to fleet
      </Link>

      <div className="detail-layout">
        <div className="detail-media">
          {image ? (
            <img src={image} alt={title} />
          ) : (
            <div className="car-card-placeholder large">{title}</div>
          )}
        </div>

        <div className="detail-info">
          <p className="car-card-meta">
            {car.categoryName} · {car.branchCity}
          </p>
          <h1>
            {title} <span>{car.year}</span>
          </h1>
          <p className="detail-rate">
            ${Number(car.dailyRate).toFixed(0)} <span>/ day</span>
          </p>
          <ul className="detail-specs">
            <li>{car.seats} seats</li>
            <li>{car.transmission}</li>
            <li>{car.fuelType}</li>
            <li>{car.color || '—'}</li>
            <li>{car.status}</li>
            <li>{car.branchName}</li>
          </ul>

          <form className="booking-form" onSubmit={onSubmit}>
            <h2>Request this car</h2>
            <div className="form-row">
              <label>
                Full name
                <input
                  required
                  value={form.fullName}
                  onChange={(e) => setForm({ ...form, fullName: e.target.value })}
                />
              </label>
              <label>
                Email
                <input
                  required
                  type="email"
                  value={form.email}
                  onChange={(e) => setForm({ ...form, email: e.target.value })}
                />
              </label>
            </div>
            <div className="form-row">
              <label>
                Phone
                <input
                  required
                  value={form.phone}
                  onChange={(e) => setForm({ ...form, phone: e.target.value })}
                />
              </label>
              <label>
                Start date
                <input
                  required
                  type="date"
                  value={form.startDate}
                  onChange={(e) => setForm({ ...form, startDate: e.target.value })}
                />
              </label>
              <label>
                End date
                <input
                  required
                  type="date"
                  value={form.endDate}
                  onChange={(e) => setForm({ ...form, endDate: e.target.value })}
                />
              </label>
            </div>
            <label>
              Notes
              <textarea
                rows={3}
                value={form.notes}
                onChange={(e) => setForm({ ...form, notes: e.target.value })}
              />
            </label>
            {error && <p className="error-banner">{error}</p>}
            {success && <p className="success-banner">{success}</p>}
            <button className="btn-primary" type="submit" disabled={submitting || car.status !== 'Available'}>
              {submitting ? 'Sending…' : 'Send booking request'}
            </button>
          </form>
        </div>
      </div>
    </section>
  );
}

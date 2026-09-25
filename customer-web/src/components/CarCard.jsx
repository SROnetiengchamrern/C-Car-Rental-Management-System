import { Link } from 'react-router-dom';
import { resolveImage } from '../api';

export default function CarCard({ car }) {
  const image = resolveImage(car.imageUrl);
  const title = `${car.make} ${car.model}`;

  return (
    <article className="car-card">
      <Link to={`/cars/${car.carId}`} className="car-card-media">
        {image ? (
          <img src={image} alt={title} loading="lazy" />
        ) : (
          <div className="car-card-placeholder">{title}</div>
        )}
      </Link>
      <div className="car-card-body">
        <p className="car-card-meta">
          {car.categoryName} · {car.branchCity || car.branchName}
        </p>
        <h3>
          <Link to={`/cars/${car.carId}`}>{title}</Link>
        </h3>
        <p className="car-card-specs">
          {car.seats} seats · {car.transmission} · {car.fuelType}
        </p>
        <div className="car-card-foot">
          <strong>${Number(car.dailyRate).toFixed(0)}<span>/day</span></strong>
          <Link to={`/cars/${car.carId}`} className="text-link">
            View details
          </Link>
        </div>
      </div>
    </article>
  );
}

import { useEffect, useState } from 'react';
import { api } from '../api';

export default function Contact() {
  const [branches, setBranches] = useState([]);

  useEffect(() => {
    api.getBranches().then(setBranches).catch(() => {});
  }, []);

  return (
    <section className="section contact-page">
      <div className="section-head">
        <h1>Contact</h1>
        <p>Pick up points across Cambodia — we will help you choose the right car.</p>
      </div>

      <div className="contact-grid">
        <div className="contact-card">
          <h2>DriveKhmer desk</h2>
          <p>hello@drivekhmer.local</p>
          <p>+855 23 111 222</p>
          <p>Daily 8:00 – 20:00</p>
        </div>
        {branches.slice(0, 6).map((b) => (
          <div key={b.branchId} className="contact-card">
            <h3>{b.branchName}</h3>
            <p>
              {b.address}, {b.city}
            </p>
            <p>{b.phone}</p>
          </div>
        ))}
      </div>
    </section>
  );
}

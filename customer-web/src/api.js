const API_BASE = import.meta.env.VITE_API_URL || '';

async function request(path, options = {}) {
  const res = await fetch(`${API_BASE}${path}`, {
    headers: {
      'Content-Type': 'application/json',
      ...(options.headers || {}),
    },
    ...options,
  });

  if (!res.ok) {
    let message = 'Request failed';
    try {
      const data = await res.json();
      message = data.message || message;
    } catch {
      /* ignore */
    }
    throw new Error(message);
  }

  return res.json();
}

export function resolveImage(url) {
  if (!url) return null;
  if (url.startsWith('http://') || url.startsWith('https://')) return url;
  return `${API_BASE}${url.startsWith('/') ? '' : '/'}${url}`;
}

export const api = {
  getCars: (params = {}) => {
    const qs = new URLSearchParams(
      Object.entries(params).filter(([, v]) => v !== undefined && v !== null && v !== '')
    ).toString();
    return request(`/api/customer/cars${qs ? `?${qs}` : ''}`);
  },
  getCar: (id) => request(`/api/customer/cars/${id}`),
  getCategories: () => request('/api/customer/categories'),
  getBranches: () => request('/api/customer/branches'),
  createBooking: (body) =>
    request('/api/customer/booking-requests', {
      method: 'POST',
      body: JSON.stringify(body),
    }),
};

# DriveKhmer customer site

Public React frontend for browsing cars and sending booking requests. Talks to the ASP.NET API at `/api/customer/*`.

## Run

1. Start the API (from the solution root):

```bash
dotnet run --project CarRentalManagementSystem.csproj --urls http://localhost:5263
```

2. Start the customer site:

```bash
cd customer-web
npm install
npm run dev
```

Open [http://localhost:5173](http://localhost:5173). Vite proxies `/api` and `/uploads` to `http://localhost:5263`.

## Pages

| Route | Purpose |
|-------|---------|
| `/` | Hero + featured available cars |
| `/fleet` | Search / filter fleet |
| `/cars/:id` | Car detail + booking request form |
| `/contact` | Branches and desk contact |

## Optional env

Create `customer-web/.env` if you call the API without the Vite proxy:

```
VITE_API_URL=http://localhost:5263
```

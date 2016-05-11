namespace Airport.UnitOfWork
{
    using System;
    using DAL;
    using DAL.DataContext;
    using DAL.Model.Entities;

    public class UnitOfWork : IDisposable
    {
        AirlineDbContext context = new AirlineDbContext();
        GenericRepository<Airline> airlineRepository;
        GenericRepository<Passenger> passengerRepository;
        GenericRepository<Port> portRepository;
        GenericRepository<Flight> flightRepository;
        GenericRepository<FlightPlace> flightPlaceRepository;
        
        public GenericRepository<Airline> AirlineRepository
        {
            get
            {
                if (airlineRepository == null)
                {
                    airlineRepository = new GenericRepository<Airline>(context);
                }
                return airlineRepository;
            }
        }

        public GenericRepository<Passenger> PassengerRepository
        {
            get
            {
                if (passengerRepository == null)
                {
                    passengerRepository = new GenericRepository<Passenger>(context);
                }
                return passengerRepository;
            }
        }

        public GenericRepository<Port> PortRepository
        {
            get
            {
                if (portRepository == null)
                {
                    portRepository = new GenericRepository<Port>(context); 
                }
                return portRepository;
            }
        }

        public GenericRepository<Flight> FlightRepository
        {
            get
            {
                if (flightRepository == null)
                {
                    flightRepository = new GenericRepository<Flight>(context);
                }
                return flightRepository;
            }
        }

        public GenericRepository<FlightPlace> FlightPlacesRepository
        {
            get
            {
                if (flightPlaceRepository == null)
                {
                    flightPlaceRepository = new GenericRepository<FlightPlace>(context);
                }
                return flightPlaceRepository;
            }
        }
        
        public void SaveChanges()
        {
            context.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    context.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UnitOfWork() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}

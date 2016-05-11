namespace Airport.BLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using DAL.Model.Entities;
    using DTO;
    using DTO.EnumsDTO;
    using Infrastructure;
    using Interfaces;
    using UnitOfWork.Catalogs;

    public class PassengerService : IPassengerService, IDisposable
    {
        readonly PassengerUnit passengerUnit;

        public PassengerService()
        {
            passengerUnit = new PassengerUnit();
        }

        public void MakePassenger(PassengerDTO passengerDTO)
        {
            var passenger = new Passenger
            {
                FirstName = passengerDTO.FirstName,
                FlightId = passengerDTO.FlightId,
                LastName = passengerDTO.LastName,
                DateOfBirthday = passengerDTO.DateOfBirthday,
                Nationality = passengerDTO.Nationality,
                Passport = passengerDTO.Passport,
                Sex = (DAL.Model.Enums.Sex)passengerDTO.Sex,
                PlaceClass = (DAL.Model.Enums.PlaceClass)passengerDTO.PlaceClass
            };
            passengerUnit.PassengerRepository.Insert(passenger);
            passengerUnit.SaveChanges();
        }
        
        public PassengerDTO GetPassenger(int? id)
        {
            if (id == null)
                throw new ValidationException("id is null.", "");
            var port = passengerUnit.PassengerRepository.GetByID(id);
            if (port == null)
                throw new ValidationException("Flight not found", "");
            Mapper.CreateMap<Passenger, PassengerDTO>();
            var item = Mapper.Map<Passenger, PassengerDTO>(port);
            item.FlightNumber = port.Flight.FlightNumber;
            return item;

        }

        public IEnumerable<PassengerDTO> OrderByFirstNameDesc(IEnumerable<PassengerDTO> items)
        {
            return items.OrderByDescending(p => p.FirstName);
        }

        public IEnumerable<PassengerDTO> OrderByFirstName(IEnumerable<PassengerDTO> items)
        {
            return items.OrderBy(p => p.FirstName);
        }

        public IEnumerable<PassengerDTO> GetPassengers()
        {
            var collection = passengerUnit.PassengerRepository.Get();
            List<PassengerDTO> list = MappToList(collection);
            return list;
        }

        static List<PassengerDTO> MappToList(IEnumerable<Passenger> collection)
        {
            Mapper.CreateMap<Passenger, PassengerDTO>();
            var list = new List<PassengerDTO>();
            foreach (var item in collection)
            {
                var listItem = Mapper.Map<Passenger, PassengerDTO>(item);
                listItem.FlightNumber = item.Flight.FlightNumber;
                list.Add(listItem);
            }

            return list;
        }

        public void UpdatePassenger(PassengerDTO passengerDTO)
        {
            var passenger = new Passenger
            {
                Id = passengerDTO.Id,
                FirstName = passengerDTO.FirstName,
                FlightId = passengerDTO.FlightId,
                LastName = passengerDTO.LastName,
                DateOfBirthday = passengerDTO.DateOfBirthday,
                Nationality = passengerDTO.Nationality,
                Passport = passengerDTO.Passport,
                Sex = (DAL.Model.Enums.Sex)passengerDTO.Sex,
                PlaceClass = (DAL.Model.Enums.PlaceClass)passengerDTO.PlaceClass
            };
            passengerUnit.PassengerRepository.Update(passenger);
            passengerUnit.SaveChanges();
        }

        public IEnumerable<PassengerDTO> OrderByNationalityDesc(IEnumerable<PassengerDTO> items)
        {
            return items.OrderByDescending(p => p.Nationality);
        }

        public IEnumerable<PassengerDTO> OrderByPassport(IEnumerable<PassengerDTO> items)
        {
            return items.OrderBy(p => p.Passport);
        }

        public IEnumerable<PassengerDTO> OrderByNationality(IEnumerable<PassengerDTO> items)
        {
            return items.OrderByDescending(p => p.Nationality);
        }

        public IEnumerable<PassengerDTO> OrderByPassportDesc(IEnumerable<PassengerDTO> items)
        {
            return items.OrderByDescending(p => p.Passport);
        }

        public IEnumerable<PassengerDTO> OrderByDateOfBirthday(IEnumerable<PassengerDTO> items)
        {
            return items.OrderBy(p => p.DateOfBirthday);
        }

        public IEnumerable<PassengerDTO> OrderByDateOfBirthdayDesc(IEnumerable<PassengerDTO> items)
        {
            return items.OrderByDescending(p => p.DateOfBirthday);
        }

        public IEnumerable<PassengerDTO> OrderByLastNameDesc(IEnumerable<PassengerDTO> items)
        {
            return items.OrderByDescending(p => p.LastName);
        }

        public IEnumerable<PassengerDTO> OrderBySex(IEnumerable<PassengerDTO> items)
        {
            return items.OrderBy(p => p.Sex);
        }

        public IEnumerable<PassengerDTO> OrderBySexDesc(IEnumerable<PassengerDTO> items)
        {
            return items.OrderByDescending(p => p.Sex);
        }

        public IEnumerable<PassengerDTO> OrderByPlaceClass(IEnumerable<PassengerDTO> items)
        {
            return items.OrderBy(p => p.PlaceClass);
        }

        public IEnumerable<PassengerDTO> OrderByPlaceClassDesc(IEnumerable<PassengerDTO> items)
        {
            return items.OrderByDescending(p => p.PlaceClass);
        }

        public IEnumerable<PassengerDTO> OrderByLastName(IEnumerable<PassengerDTO> items)
        {
            return items.OrderBy(p => p.LastName);
        }

        public void DeletePassenger(int id)
        {
            passengerUnit.PassengerRepository.Delete(id);
            passengerUnit.SaveChanges();
        }

        public void Dispose()
        {
            passengerUnit.Dispose();
        }

        public IEnumerable<PassengerDTO> FindByFirstName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ValidationException("enter search string", "");
            }
            var collection = passengerUnit.PassengerRepository.Get(p => p.FirstName.Contains(value.Trim()));
            if (collection == null)
            {
                throw new ValidationException($"Passengers with First name \"{value}\" not found", "");
            }
            return Mapper.Map<IEnumerable<Passenger>, List<PassengerDTO>>(collection);
        }

        public IEnumerable<PassengerDTO> FindByLastName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ValidationException("enter search string", "");
            }
            var collection = passengerUnit.PassengerRepository.Get(p => p.LastName.Contains(value.Trim()));
            if (collection == null)
            {
                throw new ValidationException($"Passengers with Last name \"{value}\" not found", "");
            }
            return MappToList(collection);
        }

        public IEnumerable<PassengerDTO> FindByFullName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ValidationException("enter search string", "");
            }
            var collection = passengerUnit.PassengerRepository.Get(p =>  
                                    (p.LastName + " " + p.FirstName).Contains(value.Trim())
                                    || (p.FirstName + " " + p.LastName).Contains(value.Trim()));
            if (collection == null)
            {
                throw new ValidationException($"Passengers with full name \"{value}\" not found", "");
            }
            return MappToList(collection);
        }

        public IEnumerable<PassengerDTO> FindByPassport(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ValidationException("enter search string", "");
            }
            var collection = passengerUnit.PassengerRepository.Get(p => p.Passport.Contains(value.Trim()));
            if (collection == null)
            {
                throw new ValidationException($"Passengers with passport \"{value}\" not found", "");
            }
            return MappToList(collection);
        }

        public IEnumerable<PassengerDTO> FindByNationality(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ValidationException("enter search string", "");
            }
            var collection = passengerUnit.PassengerRepository.Get(p => p.Nationality.Contains(value.Trim()));
            if (collection == null)
            {
                throw new ValidationException($"Passengers with nationality \"{value}\" not found", "");
            }
            return MappToList(collection);
        }

        public IEnumerable<PassengerDTO> FindByDateOfBirthday(DateTime? value)
        {
            if (!value.HasValue)
            {
                throw new ValidationException("date is null", "");
            }
            var collection = passengerUnit.PassengerRepository.Get(p => p.DateOfBirthday == value);
            if (collection == null)
            {
                throw new ValidationException($"Passengers with Date of birthday \"{value}\" not found", "");
            }
            return MappToList(collection);
        }

        public IEnumerable<PassengerDTO> FindBySex(SexDTO? value)
        {
            if (!value.HasValue)
            {
                throw new ValidationException("sex is null", "");
            }
            var collection = passengerUnit.PassengerRepository.Get(p => p.Sex == (DAL.Model.Enums.Sex) value);
            if (collection == null)
            {
                throw new ValidationException($"Passengers with sex \"{value}\" not found", "");
            }
            return MappToList(collection);
        }

        public IEnumerable<PassengerDTO> FindByPlaceClass(PlaceClassDTO? value)
        {
            if (!value.HasValue)
            {
                throw new ValidationException("sex is null", "");
            }
            var collection = passengerUnit.PassengerRepository
                .Get(p => p.PlaceClass == (DAL.Model.Enums.PlaceClass)value);
            if (collection == null)
            {
                throw new ValidationException($"Passengers with sex \"{value}\" not found", "");
            }
            return MappToList(collection);
        }
    }
}

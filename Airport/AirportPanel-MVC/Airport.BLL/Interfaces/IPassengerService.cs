namespace Airport.BLL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using DTO;
    using DTO.EnumsDTO;

    interface IPassengerService
    {
        void MakePassenger(PassengerDTO passengerDTO);
        PassengerDTO GetPassenger(int? id);
        IEnumerable<PassengerDTO> GetPassengers();
        void UpdatePassenger(PassengerDTO passengerDTO);
        void DeletePassenger(int id);
        void Dispose();

        IEnumerable<PassengerDTO> FindByFirstName(string value);
        IEnumerable<PassengerDTO> FindByLastName(string value);
        IEnumerable<PassengerDTO> FindByFullName(string value);
        IEnumerable<PassengerDTO> FindByPassport(string value);
        IEnumerable<PassengerDTO> FindByNationality(string value);
        IEnumerable<PassengerDTO> FindByDateOfBirthday(DateTime? value);
        IEnumerable<PassengerDTO> FindBySex(SexDTO? value);
        IEnumerable<PassengerDTO> FindByPlaceClass(PlaceClassDTO? value);

        IEnumerable<PassengerDTO> OrderByFirstName(IEnumerable<PassengerDTO> items);
        IEnumerable<PassengerDTO> OrderByFirstNameDesc(IEnumerable<PassengerDTO> items);
        IEnumerable<PassengerDTO> OrderByLastName(IEnumerable<PassengerDTO> items);
        IEnumerable<PassengerDTO> OrderByLastNameDesc(IEnumerable<PassengerDTO> items);
        IEnumerable<PassengerDTO> OrderByNationality(IEnumerable<PassengerDTO> items);
        IEnumerable<PassengerDTO> OrderByNationalityDesc(IEnumerable<PassengerDTO> items);
        IEnumerable<PassengerDTO> OrderByPassport(IEnumerable<PassengerDTO> items);
        IEnumerable<PassengerDTO> OrderByPassportDesc(IEnumerable<PassengerDTO> items);
        IEnumerable<PassengerDTO> OrderByDateOfBirthday(IEnumerable<PassengerDTO> items);
        IEnumerable<PassengerDTO> OrderByDateOfBirthdayDesc(IEnumerable<PassengerDTO> items);
        IEnumerable<PassengerDTO> OrderBySex(IEnumerable<PassengerDTO> items);
        IEnumerable<PassengerDTO> OrderBySexDesc(IEnumerable<PassengerDTO> items);
        IEnumerable<PassengerDTO> OrderByPlaceClass(IEnumerable<PassengerDTO> items);
        IEnumerable<PassengerDTO> OrderByPlaceClassDesc(IEnumerable<PassengerDTO> items);

    }
}

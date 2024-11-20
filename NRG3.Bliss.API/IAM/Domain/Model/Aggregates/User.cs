using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.ReviewManagement.Domain.Model.Aggregates;

namespace NRG3.Bliss.API.AppointmentManagement.Domain.Model.Entities;

/// <summary>
/// User aggregate root
/// </summary>
/// <remarks>
/// This class represents the user aggregate root.
/// It contains the properties and methods to manage the user information.
/// </remarks>

// TODO: Refactor class location to IAM context  (Astonitas)
public partial class User
{
    public int Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Password { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }
    public string Dni { get; private set; }
    public string Address { get; private set; }
    public string City { get; private set; }
    public DateTime BirthDate { get; private set; }
    
    public ICollection<Appointment> Appointments { get; }
    
    public ICollection<Review> Reviews { get; private set; } = new List<Review>();

    
    public User( string firstName, 
        string lastName, 
        string password, 
        string email, 
        string phone, 
        string dni, 
        string address, 
        string city, 
        DateTime birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        Password = password;
        Email = email;
        Phone = phone;
        Dni = dni;
        Address = address;
        City = city;
        BirthDate = birthDate;
    }
    
}
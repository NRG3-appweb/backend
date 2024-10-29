using NRG3.Bliss.API.ServiceManagement.Domain.Model.Aggregates;

namespace NRG3.Bliss.API.ServiceManagement.Domain.Model.Entities;

public partial class Company
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Ruc { get; set; }

    public string Email { get; set; }

    public string WebsiteUrl { get; set; }

    public string PhoneNumber { get; set; }
    
    public string Description { get; set; }
    public ICollection<Service> Services { get; set; }
    
    public Company()
    {
        Name = string.Empty;
        Ruc = string.Empty;
        Email = string.Empty;
        WebsiteUrl = string.Empty;
        PhoneNumber = string.Empty;
        Description = string.Empty;
    }

    public Company(string name, string ruc, string email, string websiteUrl, string phoneNumber, string description)
    {
        Name = name;
        Ruc = ruc;
        Email = email;
        WebsiteUrl = websiteUrl;
        PhoneNumber = phoneNumber;
        Description = description;
    }

    //TODO - Create the command constructor
    /*
    public Company(CreateCompanyCommand command)
    {
        Name = command.Name;
        Ruc = command.Ruc;
        Email = command.Email;
        WebsiteUrl = command.WebsiteUrl;
        PhoneNumber = command.PhoneNumber;
    }
    */
}
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Commands;

namespace NRG3.Bliss.API.ServiceManagement.Domain.Model.Entities;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public ICollection<Service> Services { get;}
    public Category()
    {
        Name = string.Empty;
        Description = string.Empty;
    }

    public Category(string name, string description)
    {
        Name = name;
        Description = description;
    }
    
    public Category(CreateCategoryCommand command)
    {
        Name = command.Name;
        Description = command.Description;
    }
}
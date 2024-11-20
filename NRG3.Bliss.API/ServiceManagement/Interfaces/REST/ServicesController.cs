using System.Net.Mime;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Commands;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Queries;
using NRG3.Bliss.API.ServiceManagement.Domain.Services;
using NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;
using NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace NRG3.Bliss.API.ServiceManagement.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Services")]
[EnableCors("AllowAllOrigins")]

public class ServicesController(
    IServiceCommandService serviceCommandService,
    IServiceQueryService serviceQueryService
    ) : ControllerBase
{
    [HttpGet("{serviceId:int}")]
    [SwaggerOperation (
        Summary = "Get service by id",
        Description = "Get a service by its id",
        OperationId = "GetServiceById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The service was found", typeof(ServiceResource))]
    public async Task<IActionResult> GetServiceById([FromRoute] int serviceId)
    {
        var getServiceByIdQuery = new GetServiceByIdQuery(serviceId);
        var service = await serviceQueryService.Handle(getServiceByIdQuery);
        if (service is null) return NotFound();
        var serviceResource = ServiceResourceFromEntityAssembler.ToResourceFromEntity(service);
        return Ok(serviceResource);
    }
    
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all services",
        Description = "Get all services in the system",
        OperationId = "GetAllServices")]
    [SwaggerResponse(StatusCodes.Status200OK, "The services were found", typeof(IEnumerable<ServiceResource>))]
    public async Task<IActionResult> GetAllServices()
    {
        var getAllServicesQuery = new GetAllServicesQuery();
        var services = await serviceQueryService.Handle(getAllServicesQuery);
        var serviceResources = services.Select(
            ServiceResourceFromEntityAssembler.ToResourceFromEntity
        );
        return Ok(serviceResources);
    }
    
    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new service",
        Description = "Create a new service in the system",
        OperationId = "CreateService")]
    [SwaggerResponse(StatusCodes.Status201Created, "The service was created", typeof(ServiceResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The request is invalid")]
    public async Task<IActionResult> CreateService([FromBody] CreateServiceResource resource)
    {
        var createServiceCommand = CreateServiceCommandResourceFromEntityAssembler.ToCommandFromResource(resource);
        var service = await serviceCommandService.Handle(createServiceCommand);
        if (service is null) return BadRequest("The service could not be created");
        var serviceResource = ServiceResourceFromEntityAssembler.ToResourceFromEntity(service);
        return CreatedAtAction(nameof(GetServiceById), new { serviceId = service.Id }, serviceResource);
    }
    
    [HttpPut("{serviceId:int}")]
    [SwaggerOperation(
        Summary = "Update a service",
        Description = "Update a new service in the system",
        OperationId = "UpdateService")]
    [SwaggerResponse(StatusCodes.Status200OK, "The service was updated", typeof(ServiceResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The request is invalid")]
    public async Task<IActionResult> UpdateService([FromBody] UpdateServiceResource resource,[FromRoute] int serviceId)
    {
        var updateServiceCommand = UpdateServiceCommandResourceFromEntityAssembler.ToCommandFromResource(resource, serviceId);
        var service = await serviceCommandService.Handle(updateServiceCommand);
        if (service is null) return BadRequest();
        var serviceResource = ServiceResourceFromEntityAssembler.ToResourceFromEntity(service);
        return Ok(serviceResource);
    }
    
    [HttpDelete("{serviceId:int}")]
    [SwaggerOperation(
        Summary = "Delete a service",
        Description = "Delete a service in the system",
        OperationId = "DeleteService")]
    [SwaggerResponse(StatusCodes.Status200OK, "The service was deleted")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The request is invalid")]
    public async Task<IActionResult> DeleteServiceById([FromRoute] int serviceId)
    {
        var deleteServiceCommand = new DeleteServiceCommand(serviceId);
        await serviceCommandService.Handle(deleteServiceCommand);
        return Ok("The service with the given id was successfully deleted");
    }
}
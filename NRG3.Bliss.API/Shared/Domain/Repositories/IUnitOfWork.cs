namespace NRG3.Bliss.API.Shared.Domain.Repositories;

/// <summary>
/// Unit of work interface
/// </summary>
public interface IUnitOfWork
{
        /// <summary>
        /// Save changes to the database
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous save operation.
        /// The task result contains the number of state entries written to the database.
        /// </returns>
        Task CompleteAsync();
}
using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace NRG3.Bliss.API.IAM.Domain.Model.Aggregate;

public class UserAuditable : IEntityWithCreatedUpdatedDate
{
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    [Column("CreatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}
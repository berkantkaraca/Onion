using Onion.Application.DtoInterfaces;
using Onion.Domain.Enums;

namespace Onion.Application.DtoClasses
{
    public abstract class BaseDto : IDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus Status { get; set; }
    }
}

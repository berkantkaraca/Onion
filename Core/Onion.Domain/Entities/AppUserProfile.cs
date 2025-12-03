namespace Onion.Domain.Entities
{
    //Todo: not
    public class AppUserProfile : BaseEntity
    {
        // 1-1 ilişki için hazırlanan alt yapı foreign key ile hazırlandı.
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AppUserId { get; set; }


        // Relational Properties
        public virtual AppUser AppUser { get; set; }
    }
}

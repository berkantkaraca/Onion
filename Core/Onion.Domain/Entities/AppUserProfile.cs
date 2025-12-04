namespace Onion.Domain.Entities
{
    //Burada birebir ilişki icin hazırladıgımız alt yapı aslında bire cok ilişkilerden alısık oldugumuz foreign key ile birlikte hazırlanmaya baslamıstır.

    //Bu artık 3. normalizasyonun ötesinde bir durumdur bize su avantajı saglar : Profile'in id'si kendisini kitleyen bir ilişkiden kurtuldugu icin buradaki veri girişini artık siz manage etmek zorunda kalmazsınız. Configuration otomatik olarak bu sistemi kuracaktır.
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

using EventOrganizer.Domain.Events;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace EventOrganizer.MongoDB;

[ConnectionStringName("Default")]
public class EventOrganizerMongoDbContext : AbpMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

        public IMongoCollection<Event> Events => Collection<Event>();

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        //modelBuilder.Entity<YourEntity>(b =>
        //{
        //    //...
     
        //});
    }
}

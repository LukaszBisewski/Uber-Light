namespace Passenger.Infrastructure.Mongo
{
    public class MongoSettings
    {
        public string ConnectionString { get; set; }  //URL,user, pass do bazy
        public string Database { get; set; }          //Nazwa kolekcji (bazy)
    }
}
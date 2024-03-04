using Serilog;
using MongoDB.Driver;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Loggers
{
    public class MongoDbLogger : LoggerServiceBase
    {

        public MongoDbLogger()
        {
            //MongoDbConfiguration? dbConfiguration = configuration.GetSection("SerilogConfigurations:MongoDbConfiguration")
            //    .Get<MongoDbConfiguration>();

            Logger = new LoggerConfiguration().WriteTo.MongoDBBson(
                cfg =>
                {
                    MongoClient client = new("mongodb://localhost:27017");
                    IMongoDatabase? database = client.GetDatabase("logs");
                    cfg.SetMongoDatabase(database);
                }
            ).CreateLogger();
        }
    }
}

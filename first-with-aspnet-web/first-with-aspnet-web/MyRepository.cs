namespace first_with_aspnet_web
{
    public class MyRepository: IRepository
    {
        private readonly ILogger<MyRepository> logger;

        public MyRepository(ILogger<MyRepository> _logger)
        {
            this.logger = _logger;
            logger.LogInformation("New My repository");
        }
        public string GetById(string id)
        {
            return "Id: " + id;
        }
    }
}

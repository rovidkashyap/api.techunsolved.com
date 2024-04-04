namespace api.techunsolved.com.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime ISTNow => DateTime.Now.ToLocalTime();
    }
}

using models;

namespace repository
{
    public class BaseRepository
    {
        protected string ConnectionString
        {
            get { return AppSettings.ConnectionString; }
        }
    }
}

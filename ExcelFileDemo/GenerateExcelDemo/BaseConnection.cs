namespace GenerateExcelDemo
{
    public class BaseConnection
    {
        public string _connString { get; private set; }
        public IConfiguration _config { get; private set; }
        public BaseConnection(IConfiguration config)
        {
            _config = config;
            _connString = _config.GetConnectionString("MyConn");
        }
    }
}

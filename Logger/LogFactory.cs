namespace Logger
{
    public class LogFactory
    {
        private string fPath;

        public void ConfigureFileLogger(string pth)
        {
            fPath = pth;
        }

        public BaseLogger CreateLogger(string cName)
        {
            if(fPath is null)
            {
                return null;
            }
            else
            {
                BaseLogger baseLogger = new FileLogger(fPath)
                {
                    className = cName
                };
                return baseLogger;
            }
        }
    }
}

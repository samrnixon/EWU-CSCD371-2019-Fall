using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger bLog, string msg, params object[] msgArgs)
        {
            LogLevel error = LogLevel.Error;

            if(bLog is null)
            {
                throw new ArgumentNullException("Baselogger is null");
            }
            else
            {
                foreach(object s in msgArgs)
                {
                    msg += " " + s.ToString();
                }

                bLog.Log(error, msg);
            }

        }
        public static void Warning(this BaseLogger bLog, string msg, object[] msgArgs)
        {
            LogLevel warning = LogLevel.Warning;

            if (bLog is null)
            {
                throw new ArgumentNullException("Baselogger is null");
            }
            else
            {
                foreach (object s in msgArgs)
                {
                    msg += " " + s.ToString();
                }

                bLog.Log(warning, msg);
            }
        }
        public static void Information(this BaseLogger bLog, string msg, params object[] msgArgs)
        {
            LogLevel information = LogLevel.Information;

            if (bLog is null)
            {
                throw new ArgumentNullException("Baselogger is null");
            }
            else
            {
                foreach (object s in msgArgs)
                {
                    msg += " " + s.ToString();
                }

                bLog.Log(information, msg);
            }
        }
        public static void Debug(this BaseLogger bLog, string msg, params object[] msgArgs)
        {
            LogLevel debug = LogLevel.Debug;

            if (bLog is null)
            {
                throw new ArgumentNullException("Baselogger is null");
            }
            else
            {
                foreach (object s in msgArgs)
                {
                    msg += " " + s.ToString();
                }

                bLog.Log(debug, msg);
            }
        }
    }
}

using System.Collections.Generic;

namespace SeriLoggerWithSeq
{
    interface ISomeLogger
    {
        void Error(string msg);
        void Info(string msg);
        void Info(string msg, Dictionary<string, string> props);
        void Warning(string msg);
    }
    public class SomeLogger : ISomeLogger
    {
        private Serilog.ILogger _logger;
        private string _name;
        private string _activityId;
        private string logger;
        public SomeLogger(string logger, string activityId, string name)
        {
            this._name = name;
            this._activityId = activityId;
            this.logger = logger;
            _logger = LoggerFactory.CreateLogger(logger, activityId, name);
        }
        public void Info(string msg)
        {
            _logger.Information(msg);
        }
        public void Info(string msg,Dictionary<string,string> props)
        {
            _logger.Information(msg, props);
        }
        public void Error(string msg)
        {
            _logger.Error(msg);
        }
        public void Warning(string msg)
        {
            _logger.Warning(msg);
        }

    }
}

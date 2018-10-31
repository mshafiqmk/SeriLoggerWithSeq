namespace SeriLoggerWithSeq
{
    interface iSomeLogger
    {
        void Error(string msg);
        void Info(string msg);
        void Warning(string msg);
    }
    public class SomeLogger : iSomeLogger
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

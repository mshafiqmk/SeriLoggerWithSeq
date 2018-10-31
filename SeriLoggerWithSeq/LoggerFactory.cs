﻿using System;
using System.Reflection;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Exceptions;
namespace SeriLoggerWithSeq
{
    public class LoggerFactory
    {
        public static ILogger CreateLogger(string logger, string activityId, string name)
        {
            var serverUrl = "http://localhost:5341/";
            var appEnrich = new ApplicationDetailEnricher(logger, activityId, name);
            var loggerConfig = new LoggerConfiguration()
                .WriteTo.Seq(serverUrl)
                .Enrich.WithExceptionDetails()
                .Enrich.With(appEnrich);

            var log = loggerConfig.CreateLogger();
            Log.Logger = log;
            return log;
        }

    }
    public class ApplicationDetailEnricher : ILogEventEnricher
    {
        private readonly string _logger;
        private readonly string _activityId;
        private readonly string _funcName;

        public ApplicationDetailEnricher(string logger, string activityId, string name)
        {
            this._logger = logger;
            this._activityId = activityId;
            this._funcName = name;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var appAssembly = Assembly.GetExecutingAssembly();
            var version = appAssembly.GetName().Version;
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("ActivityId", _activityId));
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("Function", _funcName));
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("Logger", _logger));
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("MachineName", Environment.MachineName));

        }
    }
}

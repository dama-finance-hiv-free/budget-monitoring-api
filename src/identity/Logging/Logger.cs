using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using Microsoft.Extensions.Configuration;
using Npgsql;
using NpgsqlTypes;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.PostgreSQL;

namespace IdentityProvider.Logging;

public static class Logger
{
    private static readonly ILogger PerfLogger;
    private static readonly ILogger UsageLogger;
    private static readonly ILogger ErrorLogger;
    private static readonly ILogger DiagnosticLogger;
    private static readonly IConfigurationRoot ConfigurationRoot;

    static Logger()
    {
        ConfigurationRoot = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = ConfigurationRoot["ConnectionStrings:IdentityLogger"];


        PerfLogger = new LoggerConfiguration()
            .WriteTo.PostgreSQL(connectionString, "PerfLogs", GetSqlColumnOptions())
            .CreateLogger();


        UsageLogger = new LoggerConfiguration()
            .WriteTo.PostgreSQL(connectionString, "UsageLogs", GetSqlColumnOptions())
            .CreateLogger();

        ErrorLogger = new LoggerConfiguration()
            .WriteTo.PostgreSQL(connectionString, "ErrorLogs", GetSqlColumnOptions())
            .CreateLogger();

        DiagnosticLogger = new LoggerConfiguration()
            .WriteTo.PostgreSQL(connectionString, "DiagnosticLogs", GetSqlColumnOptions())
            .CreateLogger();

        Serilog.Debugging.SelfLog.Enable(msg => Debug.WriteLine(msg));
    }

    public static IDictionary<string, ColumnWriterBase> GetSqlColumnOptions()
    {
        IDictionary<string, ColumnWriterBase> columnWriters = new Dictionary<string, ColumnWriterBase>
        {
            {"time_stamp", new TimestampColumnWriter(NpgsqlDbType.Timestamp) },
            {"product", new RenderedMessageColumnWriter(NpgsqlDbType.Text) },
            {"Layer", new RenderedMessageColumnWriter(NpgsqlDbType.Text) },
            {"Location", new RenderedMessageColumnWriter(NpgsqlDbType.Text) },
            {"message", new MessageTemplateColumnWriter(NpgsqlDbType.Text) },
            {"host_name", new RenderedMessageColumnWriter(NpgsqlDbType.Text) },
            {"user_id", new RenderedMessageColumnWriter(NpgsqlDbType.Text) },
            {"user_name", new RenderedMessageColumnWriter(NpgsqlDbType.Text) },
            {"exception", new ExceptionColumnWriter(NpgsqlDbType.Text) },
            {"elapsed_milliseconds", new ExceptionColumnWriter(NpgsqlDbType.Text) },
            {"correlation_id", new RenderedMessageColumnWriter(NpgsqlDbType.Text) },
            {"custom_exception", new ExceptionColumnWriter(NpgsqlDbType.Text) },
            {"additional_info", new RenderedMessageColumnWriter(NpgsqlDbType.Text) },
            {"client", new RenderedMessageColumnWriter(NpgsqlDbType.Text) },
            {"branch_code", new RenderedMessageColumnWriter(NpgsqlDbType.Text) }
        };

        return columnWriters;
    }

    public static void WritePerf(LogDetail infoToLog)
    {
        try
        {
            PerfLogger.Write(LogEventLevel.Information,
                "{Timestamp}{Message}{Layer}{Location}{Product}" +
                "{CustomException}{ElapsedMilliseconds}{Exception}{Hostname}" +
                "{UserId}{UserName}{CorrelationId}{AdditionalInfo}{Client}{BranchCode}",
                infoToLog.Timestamp, infoToLog.Message,
                infoToLog.Layer, infoToLog.Location,
                infoToLog.Product, infoToLog.CustomException,
                infoToLog.ElapsedMilliseconds, infoToLog.Exception?.ToBetterString(),
                infoToLog.Hostname, infoToLog.UserId,
                infoToLog.UserName, infoToLog.CorrelationId,
                infoToLog.AdditionalInfo,
                infoToLog.Client,
                infoToLog.BranchCode
            );
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public static void WriteUsage(LogDetail infoToLog)
    {
        //_usageLogger.Write(LogEventLevel.Information, "{@LogDetail}", infoToLog);

        UsageLogger.Write(LogEventLevel.Information,
            "{Timestamp}{Message}{Layer}{Location}{Product}" +
            "{CustomException}{ElapsedMilliseconds}{Exception}{Hostname}" +
            "{UserId}{UserName}{CorrelationId}{AdditionalInfo}{Client}{BranchCode}",
            infoToLog.Timestamp, infoToLog.Message,
            infoToLog.Layer, infoToLog.Location,
            infoToLog.Product, infoToLog.CustomException,
            infoToLog.ElapsedMilliseconds, infoToLog.Exception?.ToBetterString(),
            infoToLog.Hostname, infoToLog.UserId,
            infoToLog.UserName, infoToLog.CorrelationId,
            infoToLog.AdditionalInfo,
            infoToLog.Client,
            infoToLog.BranchCode
        );
    }
    public static void WriteError(LogDetail infoToLog)
    {
        if (infoToLog.Exception != null)
        {
            var procName = FindProcName(infoToLog.Exception);
            infoToLog.Location = string.IsNullOrEmpty(procName) ? infoToLog.Location : procName;
            infoToLog.Message = GetMessageFromException(infoToLog.Exception);
        }

        ErrorLogger.Write(LogEventLevel.Information,
            "{Timestamp}{Message}{Layer}{Location}{Product}" +
            "{CustomException}{ElapsedMilliseconds}{Exception}{Hostname}" +
            "{UserId}{UserName}{CorrelationId}{AdditionalInfo}{Client}{BranchCode}",
            infoToLog.Timestamp, infoToLog.Message,
            infoToLog.Layer, infoToLog.Location,
            infoToLog.Product, infoToLog.CustomException,
            infoToLog.ElapsedMilliseconds, infoToLog.Exception?.ToBetterString(),
            infoToLog.Hostname, infoToLog.UserId,
            infoToLog.UserName, infoToLog.CorrelationId,
            infoToLog.AdditionalInfo,
            infoToLog.Client,
            infoToLog.BranchCode
        );
    }
    public static void WriteDiagnostic(LogDetail infoToLog)
    {
        var writeDiagnostics = Convert.ToBoolean(ConfigurationRoot["EnableDiagnostics"]);
        if (!writeDiagnostics)
            return;

        DiagnosticLogger.Write(LogEventLevel.Information,
            "{Timestamp}{Message}{Layer}{Location}{Product}" +
            "{CustomException}{ElapsedMilliseconds}{Exception}{Hostname}" +
            "{UserId}{UserName}{CorrelationId}{AdditionalInfo}{Client}{BranchCode}",
            infoToLog.Timestamp, infoToLog.Message,
            infoToLog.Layer, infoToLog.Location,
            infoToLog.Product, infoToLog.CustomException,
            infoToLog.ElapsedMilliseconds, infoToLog.Exception?.ToBetterString(),
            infoToLog.Hostname, infoToLog.UserId,
            infoToLog.UserName, infoToLog.CorrelationId,
            infoToLog.AdditionalInfo,
            infoToLog.Client,
            infoToLog.BranchCode
        );
    }

    private static string GetMessageFromException(Exception ex)
    {
        if (ex.InnerException != null)
        {
            return GetMessageFromException(ex.InnerException);
        }

        return ex.Message;
    }

    private static string FindProcName(Exception ex)
    {
        if (ex is NpgsqlException sqlEx)
        {
            var procName = sqlEx.Source;
            if (!string.IsNullOrEmpty(procName))
                return procName;
        }

        if (!string.IsNullOrEmpty((string)ex.Data["Procedure"]))
        {
            return (string)ex.Data["Procedure"];
        }

        if (ex.InnerException != null)
            return FindProcName(ex.InnerException);

        return null;
    }
}
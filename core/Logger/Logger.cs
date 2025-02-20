using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.Extensions.Configuration;
using NpgsqlTypes;
using Serilog;
using Serilog.Sinks.PostgreSQL;

namespace Core.Logger;

public static class Logger
{
    private static readonly ILogger PerfLogger;
    private static readonly ILogger UsageLogger;
    private static readonly ILogger ErrorLogger;
    private static readonly ILogger DiagnosticLogger;

    private const int BatchSizeLimit = 1;
    private const bool NeedAutoCreateTable = true;

    static Logger()
    {
        var appSettings = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = appSettings["ConnectionStrings:MonitoringLogger"];

        PerfLogger = new LoggerConfiguration()
            .WriteTo.PostgreSQL(connectionString, "PerfLogs", ColumnWriters, needAutoCreateTable: NeedAutoCreateTable,
                batchSizeLimit: BatchSizeLimit, respectCase:false)
            .CreateLogger();

        UsageLogger = new LoggerConfiguration()
            .WriteTo.PostgreSQL(connectionString, "UsageLogs", ColumnWriters, needAutoCreateTable: NeedAutoCreateTable,
                batchSizeLimit: BatchSizeLimit)
            .CreateLogger();

        ErrorLogger = new LoggerConfiguration()
            .WriteTo.PostgreSQL(connectionString, "ErrorLogs", ColumnWriters, needAutoCreateTable: NeedAutoCreateTable,
                batchSizeLimit: BatchSizeLimit)
            .CreateLogger();

        DiagnosticLogger = new LoggerConfiguration()
            .WriteTo.PostgreSQL(connectionString, "DiagnosticLogs", ColumnWriters, needAutoCreateTable: NeedAutoCreateTable,
                batchSizeLimit: BatchSizeLimit)
            .CreateLogger();

        Serilog.Debugging.SelfLog.Enable(msg => Debug.WriteLine(msg));
    }

    private static readonly IDictionary<string, ColumnWriterBase> ColumnWriters = new Dictionary<string, ColumnWriterBase>
    {
        { "timestamp", new TimestampColumnWriter(NpgsqlDbType.Timestamp) },
        { "product", new SinglePropertyColumnWriter("product", PropertyWriteMethod.Raw, NpgsqlDbType.Varchar,columnLength:50) },
        { "layer", new SinglePropertyColumnWriter("layer", PropertyWriteMethod.Raw, NpgsqlDbType.Varchar,columnLength:25) },
        { "location", new SinglePropertyColumnWriter("location", PropertyWriteMethod.Raw, NpgsqlDbType.Varchar,columnLength:100) },
        { "message", new SinglePropertyColumnWriter("message", PropertyWriteMethod.Raw, NpgsqlDbType.Varchar,columnLength:250) },
        { "hostname", new SinglePropertyColumnWriter("hostname", PropertyWriteMethod.Raw, NpgsqlDbType.Varchar,columnLength:50) },
        { "user_id", new SinglePropertyColumnWriter("user_id", PropertyWriteMethod.Raw, NpgsqlDbType.Varchar,columnLength:50) },
        { "user_name", new SinglePropertyColumnWriter("user_name", PropertyWriteMethod.Raw, NpgsqlDbType.Varchar,columnLength:100) },
        { "exception", new SinglePropertyColumnWriter("exception", PropertyWriteMethod.Raw, NpgsqlDbType.Varchar,columnLength:800) },
        { "elapsed_milliseconds", new SinglePropertyColumnWriter("elapsed_milliseconds", PropertyWriteMethod.Raw, NpgsqlDbType.Integer) },
        { "correlation_id", new SinglePropertyColumnWriter("correlation_id", PropertyWriteMethod.Raw, NpgsqlDbType.Varchar,columnLength:100) },
        { "custom_exception", new SinglePropertyColumnWriter("custom_exception", PropertyWriteMethod.Raw, NpgsqlDbType.Varchar,columnLength:800) },
        { "additional_info", new SinglePropertyColumnWriter("additional_info", PropertyWriteMethod.Json, NpgsqlDbType.Varchar,columnLength:1200) },
        { "client", new SinglePropertyColumnWriter("client", PropertyWriteMethod.Raw, NpgsqlDbType.Varchar,columnLength:50) },
        { "branch_code", new SinglePropertyColumnWriter("branch_code", PropertyWriteMethod.Raw, NpgsqlDbType.Varchar,columnLength:10) },
    };

    public static void WritePerf(LogDetail infoToLog)
    {
        try
        {
            PerfLogger.Information(
                "message: {@message} layer: {@layer} location: {@location} product: {@product} hostname: {@hostname} user_id: {@user_id} user_name: {@user_name} " +
                "elapsed_milliseconds: {@elapsed_milliseconds} correlation_id: {@correlation_id} client: {@client} branch_code: {branch_code} additional_info: {additional_info} "+
                "exception: {@exception} custom_exception: {@custom_exception}",
                infoToLog.Message,
                infoToLog.Layer, infoToLog.Location,
                infoToLog.Product, infoToLog.Hostname, infoToLog.UserId, infoToLog.UserName,
                infoToLog.ElapsedMilliseconds, infoToLog.CorrelationId, infoToLog.Client, infoToLog.BranchCode,
                infoToLog.AdditionalInfo, infoToLog.Exception?.ToBetterString(), infoToLog.CustomException);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static void WriteUsage(LogDetail infoToLog)
    {
        UsageLogger.Information(
            "message: {@message} layer: {@layer} location: {@location} product: {@product} hostname: {@hostname} user_id: {@user_id} user_name: {@user_name} " +
            "elapsed_milliseconds: {@elapsed_milliseconds} correlation_id: {@correlation_id} client: {@client} branch_code: {branch_code} additional_info: {additional_info} " +
            "exception: {@exception} custom_exception: {@custom_exception}",
            infoToLog.Message,
            infoToLog.Layer, infoToLog.Location,
            infoToLog.Product, infoToLog.Hostname, infoToLog.UserId, infoToLog.UserName,
            infoToLog.ElapsedMilliseconds, infoToLog.CorrelationId, infoToLog.Client, infoToLog.BranchCode,
            infoToLog.AdditionalInfo, infoToLog.Exception?.ToBetterString(), infoToLog.CustomException);
    }

    public static void WriteError(LogDetail infoToLog)
    {
        if (infoToLog.Exception != null)
        {
            //var procName = FindProcName(infoToLog.Exception);
            //infoToLog.Location = string.IsNullOrEmpty(procName) ? infoToLog.Location : procName;
            infoToLog.Message = GetMessageFromException(infoToLog.Exception);
        }

        ErrorLogger.Information(
            "message: {@message} layer: {@layer} location: {@location} product: {@product} hostname: {@hostname} user_id: {@user_id} user_name: {@user_name} " +
            "elapsed_milliseconds: {@elapsed_milliseconds} correlation_id: {@correlation_id} client: {@client} branch_code: {branch_code} additional_info: {additional_info} " +
            "exception: {@exception} custom_exception: {@custom_exception}",
            infoToLog.Message,
            infoToLog.Layer, infoToLog.Location,
            infoToLog.Product, infoToLog.Hostname, infoToLog.UserId, infoToLog.UserName,
            infoToLog.ElapsedMilliseconds, infoToLog.CorrelationId, infoToLog.Client, infoToLog.BranchCode,
            infoToLog.AdditionalInfo, infoToLog.Exception?.ToBetterString(), infoToLog.CustomException);
    }

    public static void WriteDiagnostic(LogDetail infoToLog)
    {
        //var writeDiagnostics = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableDiagnostics"]);
        //if (!writeDiagnostics)
        //    return;

        DiagnosticLogger.Information(
            "message: {@message} layer: {@layer} location: {@location} product: {@product} hostname: {@hostname} user_id: {@user_id} user_name: {@user_name} " +
            "elapsed_milliseconds: {@elapsed_milliseconds} correlation_id: {@correlation_id} client: {@client} branch_code: {branch_code} additional_info: {additional_info} " +
            "exception: {@exception} custom_exception: {@custom_exception}",
            infoToLog.Message,
            infoToLog.Layer, infoToLog.Location,
            infoToLog.Product, infoToLog.Hostname, infoToLog.UserId, infoToLog.UserName,
            infoToLog.ElapsedMilliseconds, infoToLog.CorrelationId, infoToLog.Client, infoToLog.BranchCode,
            infoToLog.AdditionalInfo, infoToLog.Exception?.ToBetterString(), infoToLog.CustomException);
    }

    private static string GetMessageFromException(Exception ex)
    {
        if (ex.InnerException != null)
            return GetMessageFromException(ex.InnerException);

        return ex.Message;
    }

    //private static string FindProcName(Exception ex)
    //{
    //    var sqlEx = ex as SqlException;
    //    if (sqlEx != null)
    //    {
    //        var procName = sqlEx.Procedure;
    //        if (!string.IsNullOrEmpty(procName))
    //            return procName;
    //    }

    //    if (!string.IsNullOrEmpty((string)ex.Data["Procedure"]))
    //    {
    //        return (string)ex.Data["Procedure"];
    //    }

    //    if (ex.InnerException != null)
    //        return FindProcName(ex.InnerException);

    //    return null;
    //}
}
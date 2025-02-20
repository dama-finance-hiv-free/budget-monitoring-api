using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace IdentityProvider.Services;

public class EmailSenderService : IEmailSenderService
{
    private const string ApiKey = "1c44e7bdcbeccae88ffbdef37a487ddc-4de08e90-2807b583";
    private const string BaseUri = "https://api.mailgun.net/v3";
    private const string Domain = "avanfort.com";
    private const string SenderAddress = "no-reply@diha.cm";
    private const string SenderDisplayName = "DIHA";
    private const string Tag = "sampleTag";

    public async Task<IRestResponse> SendEmailAsync(UserEmailOptions userEmailOptions)
    {

        var client = new RestClient
        {
            BaseUrl = new Uri(BaseUri),
            Authenticator = new HttpBasicAuthenticator("api", ApiKey)
        };

        var request = new RestRequest();
        request.AddParameter("domain", Domain, ParameterType.UrlSegment);
        request.Resource = "{domain}/messages";
        request.AddParameter("from", $"{SenderDisplayName} <{SenderAddress}>");

        foreach (var toEmail in userEmailOptions.ToEmails)
        {
            request.AddParameter("to", toEmail);
        }

        request.AddParameter("subject", userEmailOptions.Subject);
        request.AddParameter("html", userEmailOptions.Body);
        request.AddParameter("o:tag", Tag);
        request.Method = Method.POST;
        return await client.ExecuteAsync(request);
    }
}

public interface IEmailSenderService
{
    Task<IRestResponse> SendEmailAsync(UserEmailOptions userEmailOptions);
}

public class UserEmailOptions
{
    public List<string> ToEmails { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
}
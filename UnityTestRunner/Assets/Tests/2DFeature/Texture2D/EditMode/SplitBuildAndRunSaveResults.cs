using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.TestRunner;
using System.Xml;
using System.IO;
using NUnit.Framework.Interfaces;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Threading;

[assembly: TestRunCallback(typeof(ResultSerializer))]
public class ResultSerializer : ITestRunCallback
{
    IList<IList<object>> testResult = new List<IList<object>>();

    //Request Parameter
    private string spreadsheetId = "1LPhFT5dWzWIwpt9N9PmuD5-6BXXNZtg7CKpTukFKjmc";
    private string range = "Test Result";


    static string[] Scopes = {      SheetsService.Scope.Spreadsheets, 
                                    SheetsService.Scope.Drive
    };
    static string ApplicationName = "Google Sheets API .NET Quickstart";

    public void RunStarted(ITest testsToRun) { }
    public void TestStarted(ITest test) { }
    public void TestFinished(ITestResult result) {
        if(!result.HasChildren)
            testResult.Add(new List<object>() { result.Name, result.ResultState.ToString()});
        
    }
    public void RunFinished(ITestResult testResults)
    {
        UserCredential credential;

        using (var stream =
            new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
        {
            // The file token.json stores the user's access and refresh tokens, and is created
            // automatically when the authorization flow completes for the first time.
            string credPath = "token.json";
            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.FromStream(stream).Secrets,
                Scopes,
                "user",
                CancellationToken.None,
                new FileDataStore(credPath, true)).Result;
        }

        // Create Google Sheets API service.
        var service = new SheetsService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = ApplicationName,
        });
                
        ValueRange upload = new ValueRange();
        upload.Values = testResult;
        SpreadsheetsResource.ValuesResource.UpdateRequest uploadRequest = service.Spreadsheets.Values.Update(upload, spreadsheetId, range);
        uploadRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;
        uploadRequest.Execute();

        /*
        //Generate result XML
        var path = Path.Combine(Application.persistentDataPath, "testresults.xml");
        using (var xw = XmlWriter.Create(path, new XmlWriterSettings { Indent = true }))
            testResults.ToXml(true).WriteTo(xw);
        System.Console.WriteLine($"***\n\nTEST RESULTS WRITTEN TO\n\n\t{path}\n\n***");
        Application.Quit(testResults.FailCount > 0 ? 1 : 0);
        */
    }
}

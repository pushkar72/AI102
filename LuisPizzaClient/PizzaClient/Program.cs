using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring.Models;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime.Models;
using Newtonsoft.Json;

namespace PizzaClient
{
    class Program
    {
        static void Main()
        {
            var appId = "05d28b27-31b8-4955-8a33-2cf3cf3ea8f2";
            var luiskey = "43f1708150154baf944d9cbcb599e76e";
            var predictionResource = "goofyluisai";
            
            var versionId = "0.1";
            var intentName = "OrderPizza";

            var predictionEndpoint = $"https://{predictionResource}.cognitiveservices.azure.com/";
            var creds = new  Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring.ApiKeyServiceClientCredentials(luiskey);

            var luisClient = new LUISRuntimeClient(creds) { Endpoint = predictionEndpoint };

            var request = new PredictionRequest() { Query = "I want a Small Pepporini Pizza" };

            var res = luisClient.Prediction.GetSlotPredictionAsync(Guid.Parse(appId), "Production", request).GetAwaiter().GetResult();
            Console.Write(JsonConvert.SerializeObject(res, Formatting.Indented));


        }
    }
}
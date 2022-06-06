using Microsoft.Bot.Builder.AI.Luis;
using Microsoft.Extensions.Configuration;

namespace Cinema.Bot.Services.LuisAI
{
    public class LuisAIService
    {
        //variable global
        public LuisRecognizer _luisRecognizer { get; set; }

        //constructor 
        public LuisAIService(IConfiguration configuration)
        {
            var luisApplication = new LuisApplication(
                configuration["Luis.AppId"],
                configuration["Luis.ApiKey"],
                configuration["Luis.HostName"]
            );

            var recognizerOptions = new LuisRecognizerOptionsV3(luisApplication)
            {
                PredictionOptions = new Microsoft.Bot.Builder.AI.LuisV3.LuisPredictionOptions()
                {
                    IncludeInstanceData = true
                }
            };

            _luisRecognizer = new LuisRecognizer(recognizerOptions);

        }
    }
}

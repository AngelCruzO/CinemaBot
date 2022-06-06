using Microsoft.Bot.Builder.AI.Luis;

namespace Cinema.Bot.Services.LuisAI
{
    public interface ILuisAIService
    {
        LuisRecognizer _luisRecognizer { get; set; }
    }
}

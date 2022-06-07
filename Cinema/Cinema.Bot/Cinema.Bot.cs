// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Cinema.Bot.Services.LuisAI;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Cinema.Bot
{
    public class CinemaBot : ActivityHandler
    {
        private readonly ILuisAIService _luisAIService;

        public CinemaBot(ILuisAIService luisAIService)
        {
            _luisAIService = luisAIService;
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    //await turnContext.SendActivityAsync(MessageFactory.Text($"Hello world!"), cancellationToken);
                }
            }
        }

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            var luisResult = await _luisAIService._luisRecognizer.RecognizeAsync(turnContext, cancellationToken);
            await Intentions(turnContext, luisResult, cancellationToken);
        }

        //metodo que trae la intencion con mayor probabilidad
        private async Task Intentions(ITurnContext<IMessageActivity> turnContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            var topIntent = luisResult.GetTopScoringIntent();

            switch (topIntent.intent)
            {
                case "Greet":
                    await IntentGreet(turnContext, luisResult, cancellationToken);
                    break;
                case "Dismiss":
                    await IntentDismiss(turnContext, luisResult, cancellationToken);
                    break;
                case "Thank":
                    await IntentThank(turnContext, luisResult, cancellationToken);
                    break;
                case "BuyMovie":
                    await IntentBuyMovie(turnContext, luisResult, cancellationToken);
                    break;
                case "None":
                    await IntentNone(turnContext, luisResult, cancellationToken);
                    break;
                default:
                    await IntentNone(turnContext, luisResult, cancellationToken);
                    break;
            }
        }

        //metodo para intenciones de saludo
        private async Task IntentGreet(ITurnContext<IMessageActivity> turnContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await turnContext.SendActivityAsync("Hola, que gusto hablar contigo", cancellationToken: cancellationToken);
        }

        //metodo para intenciones de despedida
        private async Task IntentDismiss(ITurnContext<IMessageActivity> turnContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await turnContext.SendActivityAsync("Espero verte pronto", cancellationToken: cancellationToken);
        }

        //metodo para intenciones de agradecimiento
        private async Task IntentThank(ITurnContext<IMessageActivity> turnContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await turnContext.SendActivityAsync("gracias a ti por escribirme", cancellationToken: cancellationToken);
        }

        //metodo para intenciones de compra
        private Task IntentBuyMovie(ITurnContext<IMessageActivity> turnContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        //metodo para intenciones que no corresponden
        private async Task IntentNone(ITurnContext<IMessageActivity> turnContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await turnContext.SendActivityAsync("Lo siento no entiendo lo que dices", cancellationToken: cancellationToken);
        }
    }
}

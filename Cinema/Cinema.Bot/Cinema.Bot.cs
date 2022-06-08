// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Cinema.Bot.Common.Models.Movies;
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
        private async Task IntentBuyMovie(ITurnContext<IMessageActivity> turnContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await turnContext.SendActivityAsync("Estas son las películas de nuestra cartelera");
            await Task.Delay(1500);
            await turnContext.SendActivityAsync(activity: ShowMovies(GetMovies()), cancellationToken);
        }
        
        //Lista de peliculas
        private List<MoviesModel> GetMovies()
        {
            var list = new List<MoviesModel>()
            {
                new MoviesModel
                {
                    name = "Joker",
                    price = "9.95",
                    imageUrl = "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/poster-joker-2-1567010576.jpg",
                    informationUrl = "https://www.culturagenial.com/es/pelicula-joker-de-todd-phillips/"
                },
                new MoviesModel
                {
                    name = "1917",
                    price = "8.95",
                    imageUrl = "https://m.media-amazon.com/images/I/61yYNBjFRjL._AC_SY679_.jpg",
                    informationUrl = "https://www.lahiguera.net/cinemania/pelicula/9034/sinopsis.php"
                },
                new MoviesModel
                {
                    name = "El llamado salvaje",
                    price = "10.95",
                    imageUrl = "https://i.pinimg.com/originals/f2/0c/4d/f20c4d439523810fe10acd6caa248233.png",
                    informationUrl = "https://www.filmaffinity.com/es/film726840.html"
                }
            };

            return list;
        }

        //metodo que muestra las películas en existencia
        private IActivity ShowMovies(List<MoviesModel> listMovies)
        {
            var optionsAttachments = new List<Attachment>();

            foreach (var item in listMovies)
            {                
                var card = new HeroCard
                {
                    Title = item.name,
                    Subtitle = $"Precio: ${item.price}",
                    Images = new List<CardImage> { new CardImage(item.imageUrl) },
                    Buttons = new List<CardAction>
                    {
                        new CardAction()
                        {
                            Title = "Comprar",
                            Type = ActionTypes.ImBack,
                            Value = "Comprar"
                        },
                        new CardAction()
                        {
                            Title = "Ver información",
                            Type = ActionTypes.OpenUrl,
                            Value = item.informationUrl
                        }
                    }
                };
                optionsAttachments.Add(card.ToAttachment());
            }                              

            var reply = MessageFactory.Attachment(optionsAttachments);
            reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;

            return reply as Activity;
        }

        //metodo para intenciones que no corresponden
        private async Task IntentNone(ITurnContext<IMessageActivity> turnContext, RecognizerResult luisResult, CancellationToken cancellationToken)
        {
            await turnContext.SendActivityAsync("Lo siento no entiendo lo que dices", cancellationToken: cancellationToken);
        }
    }
}

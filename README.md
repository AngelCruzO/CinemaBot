# Creación recursos en Azure

1.- Crear un grupo de recursos con el nombre grp-cinemabot

[grupo de recursos]

2.- Crear un servicio de cognitivo (Reconocimiento del lenguaje)

[cognitive services]

3.- terminada la creacion del servicio cognitivo entrar en [LUIS](https://www.luis.ai/), iniciar sesión con la cuenta de azure

4.- si es la primera vez que se accede al sitio, seleccionar lo siguiente

[auth]

5.- Dentro del repositorio se encuentra un archivo JSON con la configuración creada para el bot, solo hay que seleccionar import ->
import as JSON, buscar el archivo y colocar el nombre de CinemaBot

6.- ya importado el archivo JSON ir a manage -> Azure Resources -> Add prediction resource. Colocar las siguientes opciones

[prediction]

# Cinema.Bot

Bot Framework v4 empty bot sample.

This bot has been created using [Bot Framework](https://dev.botframework.com), it shows the minimum code required to build a bot.

## Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download) version 3.1

  ```bash
  # determine dotnet version
  dotnet --version
  ```

## To try this sample

- In a terminal, navigate to `Cinema.Bot`

    ```bash
    # change into project folder
    cd Cinema.Bot
    ```

- Run the bot from a terminal or from Visual Studio, choose option A or B.

  A) From a terminal

  ```bash
  # run the bot
  dotnet run
  ```

  B) Or from Visual Studio

  - Launch Visual Studio
  - File -> Open -> Project/Solution
  - Navigate to `Cinema.Bot` folder
  - Select `Cinema.Bot.csproj` file
  - Press `F5` to run the project

## Testing the bot using Bot Framework Emulator

[Bot Framework Emulator](https://github.com/microsoft/botframework-emulator) is a desktop application that allows bot developers to test and debug their bots on localhost or running remotely through a tunnel.

- Install the Bot Framework Emulator version 4.3.0 or greater from [here](https://github.com/Microsoft/BotFramework-Emulator/releases)

### Connect to the bot using Bot Framework Emulator

- Launch Bot Framework Emulator
- File -> Open Bot
- Enter a Bot URL of `http://localhost:3978/api/messages`

## Deploy the bot to Azure

To learn more about deploying a bot to Azure, see [Deploy your bot to Azure](https://aka.ms/azuredeployment) for a complete list of deployment instructions.

## Further reading

- [Bot Framework Documentation](https://docs.botframework.com)
- [Bot Basics](https://docs.microsoft.com/azure/bot-service/bot-builder-basics?view=azure-bot-service-4.0)
- [Activity processing](https://docs.microsoft.com/en-us/azure/bot-service/bot-builder-concept-activity-processing?view=azure-bot-service-4.0)
- [Azure Bot Service Introduction](https://docs.microsoft.com/azure/bot-service/bot-service-overview-introduction?view=azure-bot-service-4.0)
- [Azure Bot Service Documentation](https://docs.microsoft.com/azure/bot-service/?view=azure-bot-service-4.0)
- [.NET Core CLI tools](https://docs.microsoft.com/en-us/dotnet/core/tools/?tabs=netcore2x)
- [Azure CLI](https://docs.microsoft.com/cli/azure/?view=azure-cli-latest)
- [Azure Portal](https://portal.azure.com)
- [Language Understanding using LUIS](https://docs.microsoft.com/en-us/azure/cognitive-services/luis/)
- [Channels and Bot Connector Service](https://docs.microsoft.com/en-us/azure/bot-service/bot-concepts?view=azure-bot-service-4.0)

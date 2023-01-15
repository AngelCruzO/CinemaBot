# Pre requisitos
- Cuenta de Azure
- Visual Studio 2022 o superior
- Bot Framework Emulator V4

# Creación de Recursos en Azure
1 Crear un grupo de recursos, para la implementación

2 Crear un cognitive service de LUIS (Language Understanding)

3 Configurar el servicio LUIS en [LUIS](https://www.luis.ia), iniciar sesión con la cuenta de Azure

4 Para nuevos usuarios se necesita configurar el auth del servicio cognitivo

5 Para tener el servicio completo falta importar las intenciones y las entidades que conforman las respuestas del bot. Import -> import JSON -> buscar el archivo (CinemaBot.json) -> Nombre: CinemaBot

6 Una vez importando el JSON, manage -> Azure Resources -> Add prediction resource

7 Por ultimo hay que entrenar el modelo, dando click en Train, con esto el modelo esta listo para ser utilizado


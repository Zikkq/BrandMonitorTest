#Brand Monitor Test Task
Для запуска проекта необходимо:
1. Установить [докер](https://www.docker.com/get-started/) для развёртывания в нём контейнера с Postgres. После установки докера достаточно выполнить команду ```docker-composee up --detach``` из папки с проектом.
2. Устновить [].NET 6 Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).
После установки вышеперечисленного для запуска необходимо выполнить команду ```dotnet run``` из папки с проектом тогда сайт развернётся по адресу https://localhost:7125.
Адрес POST эндпоинта: https://localhost:7125/api/task
Адрес GET эндпоинта: https://localhost:7125/api/task?id=(GUID задачи)
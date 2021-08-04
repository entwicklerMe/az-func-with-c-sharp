# Azure Function mit C\# und GitHub Actions

### Ziele

* eine Azure Function mit C#, die auf einem HTTP `POST` & `GET` Request hört
* die Function schreibt Daten in einem Datenbank
* die Function kann aus dieser Datenbank wieder Daten auslesen
* das Deployment der Function läuft über GitHub Actions
* die Azure Function ist über eine Domain `az-func.az.entwickler.me` erreichbar

### Deployment

#### Lokaler Rechner

* Installation der _Azure Function Core Tools_: https://github.com/Azure/azure-functions-core-tools
* Im Terminal in der Azure Umgebung anmelden. 
  * `az login` im Terminal ausführen
* Im Repo-Ordner den Deployment Befehl ausführen:
  * `func azure functionapp publish ew-pets` im Termin ausführen
  * _ew-pets_ ist der Name der Function App im Azure Portal: https://portal.azure.com/

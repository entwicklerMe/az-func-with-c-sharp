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
  
### Datenbank Zugriff

Über die Endpunkte können neue Eintrage in eine Datenbank gespeichert werden und aus dieser ausgelesen werden.

### Konfiguration

Es wird eine CosmosDB vom Typ MongoDB benötigt um Einträge zu speichern und zu lesen.
Der Connection-String zur Datenbank, muss als Umgebungsvariable (`DATABASE_CONNECTION_STRING`) in der lokalen Entwicklung und in der Funktion App angegeben werden.
Zudem muss noch eine Datenbank und eine Collection angelegt werden.
* Datenbankname: pets
* Collection-Name: pets

### Daten eintragen

Request: [POST] /api/pets
Body:
```
{
    "name": "Mietze",
    "type": "KATZE"
}
```

### Daten auslesen

Request: [GET] /api/pets

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EW.Pets.Models;
using MongoDB.Driver;

namespace EW.Pets.Utils
{
    /// <summary>
    /// Klasse für den Zugriff auf die Azure Cosmos DB zu lesen & schreiben von Haustieren
    /// </summary>
    public class Repository
    {
        /// <summary>
        /// Referenz zur "pets" MongoDB Collection
        /// </summary>
        private readonly IMongoCollection<Pet> _collection;
        
        /// <summary>
        /// Erstellt eines neues Repository Objekt für den Zugriff auf eine CosmosDB
        /// mit der Datenbank "pets" und der Collection "pets".
        /// </summary>
        public Repository() {
            var dbClient = new MongoClient(Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING"));
            var db = dbClient.GetDatabase("pets");
            _collection = db.GetCollection<Pet>("pets");
        }
        
        /// <summary>
        /// Speichert einen neuen Eintrag in die Azure CosmosDB
        /// </summary>
        /// <param name="pet">Neues Haustier Objekt</param>
        public void Save(Pet pet) {
            _collection.InsertOne(pet);
        }

        /// <summary>
        /// Fragt alle Einträge von Haustieren in der der Datenbank ab.
        /// </summary>
        /// <returns>Liste von Haustieren</returns>
        public async Task<List<Pet>> GetPets()
        {
            return await _collection.Find(_ => true).ToListAsync<Pet>();
        }
        
    }
}
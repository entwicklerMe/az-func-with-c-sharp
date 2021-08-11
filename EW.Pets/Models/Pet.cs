using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EW.Pets.Models
{
    public class Pet
    {
        /// <summary>
        /// Eindeutige Datenbank ID von der CosmosDB
        /// </summary>
        [BsonId]
        public ObjectId ID { get; set; }
        
        /// <summary>
        /// Name von dem Haustier
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Art des Haustieres
        /// </summary>
        public string Type { get; set; }
    }
}
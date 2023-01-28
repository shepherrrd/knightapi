using System.Text.Json.Serialization;

namespace webtesting.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum rpgClass
    {
      
         knight = 1,
         Mage = 2,

        Clarence = 3
    }
}
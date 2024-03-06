using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WhereToEat.Model
{
    public class Restaurant
    {
        public string Name { get; set; }
        public string Cuisine { get; set; }
        public int Id { get; set; }
        public string Image { get; set; }
    }

    [JsonSerializable(typeof(List<Restaurant>))]
    internal sealed partial class RestaurantContext : JsonSerializerContext
    {

    }
}

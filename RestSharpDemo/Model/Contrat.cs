using Newtonsoft.Json;
using RestSharp.Serializers;

namespace RestSharpDemo.Model
{
    public enum Produit
    {
        P1 = 1,
        P2 = 2,
        P3 = 3
    }

    [SerializeAs(Name = "Contract")]
    public class Contrat
    {
        //[DeserializeAs(Name = "ContractNumber")]
        [JsonProperty("ContractNumber")]
        public int Numero { get; set; }

        //[DeserializeAs(Name = "Product")]
        [JsonProperty("Product")]
        public Produit Produit { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace RegistroDespesaApi.Models
{
    public class Despesa
    {
		[Key]
		public Guid CodDespesa { get; set; }
        public string NomeDespesa { get; set; }
        public string DescricaoDespesa { get; set; }
        public float Valor { get; set; }
        public DateTime Data { get; set; }
     
    }
}

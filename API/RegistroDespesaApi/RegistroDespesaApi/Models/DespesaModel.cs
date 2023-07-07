namespace RegistroDespesaApi.Models
{
    public class DespesaModel
    {
        public int codDespesa { get; set; }
        public string NomeDespesa { get; set; }
        public string DescricaoDespesa { get; set; }
        public float Valor { get; set; }
        public DateTime Data { get; set; }
        public float ValorTotal { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Imovel.Models
{
    public class Imovel
    {
        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Column("TipoImovel")]
        [Display(Name = "Tipo do Imovel")]
        public string TipoImovel { get; set; }

        [Column("ValorV")]
        [Display(Name = "ValorVenda")]
        public int ValorVenda { get; set; }

        [Column("ValorL")]
        [Display(Name = "ValorLocacao")]
        public int ValorLocacao { get; set; }

        [Column("Endereco")]
        [Display(Name = "Endereco")]
        public string Endereco { get; set; }

        [Column("Numero")]
        [Display(Name = "Numero")]
        public int Numero { get; set; }

        [Column("Complemento")]
        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        [Column("Bairro")]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Column("Cidade")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Column("Estado")]
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Column("Cep")]
        [Display(Name = "Cep")]
        public string Cep { get; set; }
    }
}

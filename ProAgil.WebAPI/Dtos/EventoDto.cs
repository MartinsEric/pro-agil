using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProAgil.WebAPI.Dtos
{
    public class EventoDto
    {
        public int Id { get; set; }
        
        [Required (ErrorMessage="O campo {0} é obrigatório.")]
        public string Tema { get; set; }
        
        [Required (ErrorMessage="O campo {0} é obrigatório.")]
        [StringLength(100, MinimumLength=2, ErrorMessage="O campo {0} deve conter entre 2 e 100 caracteres")]
        public string Local  { get; set; }
        public List<LoteDto> Lotes { get; set; }
        public int QtdPessoas { get; set; }
        public string Date { get; set; }        
        public string ImageUrl { get; set; }
        public string Telefone { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public List<RedeSocialDto> RedesSociais { get; set; }
        public List<PalestranteDto> Palestrantes { get; set; }
    }
}
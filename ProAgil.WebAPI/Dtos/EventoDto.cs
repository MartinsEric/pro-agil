using System.Collections.Generic;

namespace ProAgil.WebAPI.Dtos
{
    public class EventoDto
    {
        public int Id { get; set; }
        public string Tema { get; set; }
        public string Local  { get; set; }
        public List<LoteDto> Lotes { get; set; }
        public int QtdPessoas { get; set; }
        public string Date { get; set; }        
        public string ImageUrl { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public List<RedeSocialDto> RedesSociais { get; set; }
        public List<PalestranteDto> Palestrantes { get; set; }
    }
}
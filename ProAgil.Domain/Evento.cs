using System;
using System.Collections.Generic;

namespace ProAgil.Domain
{
    public class Evento
    {
        public int Id { get; set; }
        public string Tema { get; set; }
        public string Local  { get; set; }
        public List<Lote> Lotes { get; set; }
        public int QtdPessoas { get; set; }
        public DateTime Date { get; set; }        
        public string ImageUrl { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public List<RedeSocial> RedesSociais { get; set; }
        public List<PalestranteEvento> PalestrantesEventos { get; set; }
    }
}
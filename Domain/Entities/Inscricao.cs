using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Inscricao
    {
        public int Id { get; set; }
        public string NumeroInscricao { get; set; }
        public DateTime Data { get; set; }
        public string Status { get; set; }

        [JsonIgnore]
        public int LeadId { get; set; }
        public Lead Lead { get; set; }

        [JsonIgnore]
        public int ProcessoSeletivoId { get; set; }
        public ProcessoSeletivo ProcessoSeletivo { get; set; }

        [JsonIgnore]
        public int OfertaId { get; set; }
        public Oferta Oferta { get; set; }

    }
}

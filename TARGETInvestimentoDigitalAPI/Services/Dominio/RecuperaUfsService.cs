using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TARGETInvestimentoDigitalAPI.Dto.Dominio;
using TARGETInvestimentoDigitalAPI.Interfaces.Dominio;

namespace TARGETInvestimentoDigitalAPI.Services.Dominio
{
    public class RecuperaUfsService : IRecuperaUfsService
    {
        private readonly IMapper _mapper;

        public RecuperaUfsService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<ReadUfDto> Executar()
        {
            HttpClient httpClient = new HttpClient();
            string url = "https://servicodados.ibge.gov.br/api/v1/localidades/estados";
            var response = httpClient.GetAsync(url).GetAwaiter().GetResult();
            var result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<IEnumerable<ReadUfDto>>(result);
        }
    }
}

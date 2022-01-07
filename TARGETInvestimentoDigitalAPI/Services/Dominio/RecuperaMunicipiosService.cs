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
    public class RecuperaMunicipiosService : IRecuperaMunicipiosService
    {
        private readonly IMapper _mapper;

        public RecuperaMunicipiosService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<ReadMunicipioDto> Executar(int id)
        {
            HttpClient httpClient = new HttpClient();
            string url = "https://servicodados.ibge.gov.br/api/v1/localidades/estados/" + id + "/municipios";
            var response = httpClient.GetAsync(url).GetAwaiter().GetResult();
            var result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<IEnumerable<ReadMunicipioDto>>(result);
        }
    }
}

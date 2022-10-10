using Adocao_ONG_V2._1.Model;
using Adocao_ONG_V2._1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adocao_ONG_V2._1.Service
{
    public class PessService
    {
        private IPessRepository _pessRepository;

        public PessService()
        {
            _pessRepository = new PessRepository();
        }

        public bool Add(Pessoa pessoa)
        {
            return _pessRepository.Add(pessoa);
        }

        public List<Pessoa> GetAll()
        {
            return _pessRepository.GetAll();
        }
    }
}

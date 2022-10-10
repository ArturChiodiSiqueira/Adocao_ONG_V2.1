using Adocao_ONG_V2._1.Model;
using Adocao_ONG_V2._1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adocao_ONG_V2._1.Service
{
    public class AniService
    {
        private IAniRepository _aniRepository;

        public AniService()
        {
            _aniRepository = new AniRepository();
        }

        public bool Add(Animal pessoa)
        {
            return _aniRepository.Add(pessoa);
        }

        public List<Animal> GetAll()
        {
            return _aniRepository.GetAll();
        }
    }
}

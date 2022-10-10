using Adocao_ONG_V2._1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adocao_ONG_V2._1.Repository
{
        public interface IPessRepository
        {
            bool Add(Pessoa pessoa);

            List<Pessoa> GetAll();
        }
}

using Adocao_ONG_V2._1.Config;
using Adocao_ONG_V2._1.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adocao_ONG_V2._1.Repository
{
    internal class PessRepository : IPessRepository
    {
        private string _conn;

        public PessRepository()
        {
            _conn = DataBaseConfiguration.Get();
        }

        public bool Add(Pessoa pessoa)
        {
            bool result = false;

            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                db.Execute(Pessoa.INSERT, pessoa);
                result = true;
            }
            return result;
        }

        public List<Pessoa> GetAll()
        {
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                var pessoas = db.Query<Pessoa>(Pessoa.SELECT);
                return (List<Pessoa>)pessoas;
            }
        }
    }
}

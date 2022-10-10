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
    internal class AniRepository : IAniRepository
    {
        private string _conn;

        public AniRepository()
        {
            _conn = DataBaseConfiguration.Get();
        }

        public bool Add(Animal animal)
        {
            bool result = false;

            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                db.Execute(Animal.INSERT, animal);
                result = true;
            }
            return result;
        }

        public List<Animal> GetAll()
        {
            using (var db = new SqlConnection(_conn))
            {
                db.Open();
                var animais = db.Query<Animal>(Animal.SELECT);
                return (List<Animal>)animais;
            }
        }
    }
}

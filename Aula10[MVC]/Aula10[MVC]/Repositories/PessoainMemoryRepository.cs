using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aula10_MVC_.Models;

namespace Aula10_MVC_.Repositories
{
    public class PessoainMemoryRepository
    {
        private static List<PessoaModel> _pessoas = new List<PessoaModel>() 
        { new PessoaModel {
            Id = 1,
            Nome ="PessoaTeste",
            Nascimento = new DateTime(2001/06/30)
            }
        }; 
        
        public IEnumerable<PessoaModel> GetAll()
        {
            return _pessoas;
        }

        public void Add(PessoaModel newPessoaModel)
        {
            _pessoas.Add(newPessoaModel);
        }
    }
}

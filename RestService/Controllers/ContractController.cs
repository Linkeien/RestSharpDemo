using Microsoft.AspNetCore.Mvc;
using RestService.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private static IList<Contract> _contracts = new List<Contract>
            {
                new Contract(1, "Toto", "1 rue de toto", "Totocity", Product.P2),
                new Contract(2, "Titi", "1 rue de titi", "Titicity", Product.P1),
                new Contract(3, "Tutu", "1 rue de tutu", "Tutucity", Product.P3)
            };

        // DELETE : api/Contract
        [HttpDelete]
        public void Delete()
        {
            _contracts.Clear();
        }

        // DELETE : api/Contract/3
        [HttpDelete("{id}", Name = "Delete")]
        public void Delete(int id)
        {
            var contractToRemove = _contracts.FirstOrDefault(c => c.ContractNumber == id);
            if (contractToRemove != null)
            {
                _contracts.Remove(contractToRemove);
            }
        }

        // GET: api/Contract
        [HttpGet]
        public IEnumerable<Contract> Get()
        {
            return _contracts;
        }

        // GET: api/Contract/5
        [HttpGet("{id}", Name = "Get")]
        public Contract Get(int id)
        {
            return _contracts.FirstOrDefault(c => c.ContractNumber == id);
        }

        // POST: api/Contract
        [HttpPost]
        public void Post([FromBody] Contract value)
        {
            _contracts.Add(value);
        }
    }
}
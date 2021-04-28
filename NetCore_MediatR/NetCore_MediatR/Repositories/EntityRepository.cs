using NetCore_MediatR.Application.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_MediatR.Repositories
{
    public class EntityRepository : IRepository<Entity>
    {
        private static Dictionary<int, Entity> pessoas = new Dictionary<int, Entity>();

        public async Task<IEnumerable<Entity>> GetAll()
        {
            return await Task.Run(() => pessoas.Values.ToList());
        }

        public async Task<Entity> Get(int id)
        {
            return await Task.Run(() => pessoas.GetValueOrDefault(id));
        }

        public async Task Add(Entity pessoa)
        {
            await Task.Run(() => pessoas.Add(pessoa.Id, pessoa));
        }

        public async Task Edit(Entity pessoa)
        {
            await Task.Run(() =>
            {
                pessoas.Remove(pessoa.Id);
                pessoas.Add(pessoa.Id, pessoa);
            });
        }

        public async Task Delete(int id)
        {
            await Task.Run(() => pessoas.Remove(id));
        }
    }
}

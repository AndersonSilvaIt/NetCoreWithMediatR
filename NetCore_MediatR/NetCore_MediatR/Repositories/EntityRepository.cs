using NetCore_MediatR.Application.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore_MediatR.Repositories
{
    public class EntityRepository : IRepository<Entity>
    {
        private static Dictionary<int, Entity> entitys = new Dictionary<int, Entity>();

        public async Task<IEnumerable<Entity>> GetAll()
        {
            return await Task.Run(() => entitys.Values.ToList());
        }

        public async Task<Entity> Get(int id)
        {
            return await Task.Run(() => entitys.GetValueOrDefault(id));
        }

        public async Task<Entity> Add(Entity entity)
        {
            return await Task.Run(() => {
                var id = entitys.Count() + 1;
                entity.Id = id;
                entitys.Add(id, entity);
                return entity;
            });
        }

        public async Task Edit(Entity entity)
        {
            await Task.Run(() =>
            {
                entitys.Remove(entity.Id);
                entitys.Add(entity.Id, entity);
            });
        }

        public async Task Delete(int id)
        {
            await Task.Run(() => entitys.Remove(id));
        }
    }
}

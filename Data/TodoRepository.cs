using Data.Interfaces;
using Entities;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Data
{
    public class TodoRepository : RepositoryConnector, ITodoRepository
    {
        public TodoRepository(IConfiguration configuration) : base(configuration) { }
        public void Add(ToDo obj)
        {
            throw new System.NotImplementedException();
        }

        public ToDo Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ToDo> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Remove(ToDo obj)
        {
            throw new System.NotImplementedException();
        }

        public void Update(ToDo obj)
        {
            throw new System.NotImplementedException();
        }
    }
}

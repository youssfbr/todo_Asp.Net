using Data.Interfaces;
using Entities;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

namespace Data
{
    public class TodoRepository : RepositoryConnector, ITodoRepository
    {
        public TodoRepository(IConfiguration configuration) : base(configuration) { }
        public void Add(ToDo obj)
        {
            DynamicParameters pam = new DynamicParameters();
            pam.Add("@Tarefa", obj.Tarefa);

            string sql = "INSERT INTO Todo (Tarefa) VALUES(@Tarefa)";
            using (var con = new SqlConnection(base.GetConnection()))
            {
                con.Execute(sql, pam);
            }
        }

        public ToDo Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ToDo> GetAll()
        {
            IEnumerable<ToDo> retorno;
            string sql = "SELECT * FROM Todo";

            using(var con = new SqlConnection(base.GetConnection()))
            {
                retorno = con.Query<ToDo>(sql);
            }
            return retorno;
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

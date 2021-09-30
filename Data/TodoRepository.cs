using Data.Interfaces;
using Entities;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

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
            string sql = $"SELECT * FROM Todo WHERE Id = {id}";
            
            using (var con = new SqlConnection(base.GetConnection()))
            {
                return con.Query<ToDo>(sql).FirstOrDefault();
            }
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
            string sql = $@"UPDATE Todo 
                        SET Tarefa = @Tarefa
                        WHERE Id = {obj.Id}";

            DynamicParameters pam = new DynamicParameters();
            pam.Add("@Tarefa", obj.Tarefa);

            using(var con = new SqlConnection(base.GetConnection()))
            {
                con.Execute(sql, pam);
            }
        }
    }
}

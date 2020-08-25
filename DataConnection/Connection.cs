using Dapper;
using Model.Repo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataConnection
{
    public class Connection
    {

        string ConnectionString = @"Data Source=DESKTOP-LP152BS\EXPRESS2020;Database=PersonsData;User ID =Bunso1544; Password=J@hnjovence";

        private IDbConnection Connect { get; set; }

        public Connection()
        {
            Connect = new SqlConnection(ConnectionString);
        }

        public void AddEmployee(PersonsModel personsModel)
        {
            this.Connect.Execute("PersonsProc", personsModel, commandType: CommandType.StoredProcedure);
        }

        public List<PersonsModel> GetAllPersons()
        {
            return this.Connect.Query<PersonsModel>("GetAllPersons", commandType: CommandType.StoredProcedure).ToList();
        }
    }
}

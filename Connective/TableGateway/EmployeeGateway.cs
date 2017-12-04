using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connective.Conn;
using System.Data.SqlClient;
using Connective.Tables;
using System.Collections.ObjectModel;

namespace Connective.TableGateway
{
    public class EmployeeGateway
    {
        public static String SQL_CHECK_LOGIN = "SELECT DISTINCT * FROM Employee WHERE mail=@mail AND password=@password";
        public static String SQL_SELECT_ID = "SELECT * FROM Employee WHERE employee_id=@employee_id";
        public static String SQL_INSERT = "INSERT INTO Employee VALUES (@mail, @password)";
        public static String SQL_UPDATE = "UPDATE Employee SET mail=@mail, password=@password WHERE employee_id=@employee_id";
        public static String SQL_DELETE_ID = "DELETE FROM Employee WHERE employee_id=@employee_id";
        public static String SQL_DELETE = "DELETE FROM Employee";

        private static void PrepareCommand(SqlCommand command, Employee employee)
        {
            command.Parameters.AddWithValue("@mail", employee.Mail);
            command.Parameters.AddWithValue("@password", employee.Password);
        }

        private static void PrepareCommandU(SqlCommand command, Employee employee)
        {
            command.Parameters.AddWithValue("@employee_id", employee.RecordId);
            command.Parameters.AddWithValue("@mail", employee.Mail);
            command.Parameters.AddWithValue("@password", employee.Password);
        }

        public static int Insert(Employee employee)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, employee);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }
        public static int Update(Employee employee)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommandU(command, employee);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }

        public static Employee Select(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue("@employee_id", id);
            SqlDataReader reader = db.Select(command);

            Collection<Employee> employees = Read(reader);
            Employee em = null;
            if (employees.Count == 1)
            {
                em = employees[0];
            }

            db.Close();
            return em;
        }
        public static bool CheckPassword(Employee employee)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_CHECK_LOGIN);
            PrepareCommand(command, employee);

            SqlDataReader reader = db.Select(command);

            Collection<Employee> employees = Read(reader);
            db.Close();

            if (employees.Count > 0)
            {
                return true;
            }
            return false;
        }


        public static int Delete(int id)
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

            command.Parameters.AddWithValue("@employee_id", id);
            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }

        public static int Delete()
        {
            Database db = new Database();
            db.Connect();
            SqlCommand command = db.CreateCommand(SQL_DELETE);

            int ret = db.ExecuteNonQuery(command);

            db.Close();
            return ret;
        }

        private static Collection<Employee> Read(SqlDataReader reader)
        {
            Collection<Employee> employees = new Collection<Employee>();

            while (reader.Read())
            {
                Employee em = new Employee();
                int i = -1;
                em.RecordId = reader.GetInt32(++i);
                em.Mail = reader.GetString(++i);
                em.Password = reader.GetString(++i);

                employees.Add(em);
            }
            return employees;
        }
    }
}

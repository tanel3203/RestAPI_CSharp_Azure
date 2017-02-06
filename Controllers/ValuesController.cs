using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DT = System.Data;
using QC = System.Data.SqlClient;  // System.Data.dll  

namespace Zelda.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        // GET api/values
        [HttpGet]
        public List<FullName> Get()
        {
            List<FullName> received;



            using (var connection = new QC.SqlConnection(  
                "Server=tcp:ganondorf2.database.windows.net,1433;Initial Catalog=ganondorf2;Persist Security Info=False;User ID=tanel3203;Password=b1gBadpassword;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"  
                ))  
            {  
        
                connection.Open();  
                Console.WriteLine("Connected successfully.");  


                //Program.DeleteRows(connection);
                Console.WriteLine("Select below."); 
                received = ValuesController.SelectRows(connection);
                Console.WriteLine(received);
                Console.WriteLine("Select above");  
            }


            return received;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        // POST api/values
        [HttpPost] 
        public void Post(string inputFirstName,
                            string inputLastName,
                            string inputBirthDate,
                            string inputTitle,
                            string inputUrl,
                            string inputDescription,
                            string inputOwnerName,
                            string inputCategory,
                            string inputPoints)
        {

            using (var connection = new QC.SqlConnection(  
                "Server=tcp:ganondorf2.database.windows.net,1433;Initial Catalog=ganondorf2;Persist Security Info=False;User ID=tanel3203;Password=b1gBadpassword;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"  
                ))  
            {  
                connection.Open();  
                Console.WriteLine("Connected successfully.");  

                Console.WriteLine("Insert below");  
                ValuesController.InsertRows(connection, inputFirstName,
                                                        inputLastName,
                                                        inputBirthDate,
                                                        inputTitle,
                                                        inputUrl,
                                                        inputDescription,
                                                        inputOwnerName,
                                                        inputCategory,
                                                        inputPoints);
                Console.WriteLine("Insert closed"); 

            }

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        static public List<FullName> SelectRows(QC.SqlConnection connection)  
        {  
            List<FullName> names = new List<FullName>();

            using (var command = new QC.SqlCommand())  
            {  
                command.Connection = connection;  
                command.CommandType = DT.CommandType.Text;  
                command.CommandText = @"  
                        SELECT  
                                FirstName,
                                LastName,
                                BirthDate,
                                Title,
                                Url,
                                Description,
                                OwnerName,
                                Category,
                                Points
                            FROM  
                                ganondorf  
                             ";  

                QC.SqlDataReader reader = command.ExecuteReader();  
                
                while (reader.Read())  
                {  
                    Console.WriteLine("{0}",  
                        reader.GetString(0));                       


                    names.Add(new FullName() {
                        FirstName = reader.GetString(0),
                        LastName = reader.GetString(1),
                        BirthDate = reader.GetString(2),
                        Title = reader.GetString(3),
                        Url = reader.GetString(4),
                        Description = reader.GetString(5),
                        OwnerName = reader.GetString(6),
                        Category = reader.GetString(7),
                        Points = reader.GetString(8)
                        });
                }  
            }  
        return names;
        } 

        static public void InsertRows(QC.SqlConnection connection, 
                                        string inputFirstName,
                                        string inputLastName,
                                        string inputBirthDate,
                                        string inputTitle,
                                        string inputUrl,
                                        string inputDescription,
                                        string inputOwnerName,
                                        string inputCategory,
                                        string inputPoints)  
        {  
            QC.SqlParameter parameter;  

            using (var command = new QC.SqlCommand())  
            {  
                command.Connection = connection;  
                command.CommandType = DT.CommandType.Text;  
                command.CommandText = @"  
                        INSERT INTO ganondorf 
                                (FirstName,
                                LastName,
                                BirthDate,
                                Title,
                                Url,
                                Description,
                                OwnerName,
                                Category,
                                Points
                                )  
                            OUTPUT  
                                INSERTED.Title  
                            VALUES  
                                (@FirstName,
                                @LastName,
                                @BirthDate,
                                @Title,
                                @Url,
                                @Description,
                                @OwnerName,
                                @Category,
                                @Points
                                ); ";  


                parameter = new QC.SqlParameter("@FirstName", DT.SqlDbType.NVarChar, 255);  
                parameter.Value = inputFirstName;  
                command.Parameters.Add(parameter);  

                parameter = new QC.SqlParameter("@LastName", DT.SqlDbType.NVarChar, 255);  
                parameter.Value = inputLastName;  
                command.Parameters.Add(parameter);  

                parameter = new QC.SqlParameter("@BirthDate", DT.SqlDbType.NVarChar, 255);  
                parameter.Value = inputBirthDate;  
                command.Parameters.Add(parameter);  

                parameter = new QC.SqlParameter("@Title", DT.SqlDbType.NVarChar, 255);  
                parameter.Value = inputTitle;  
                command.Parameters.Add(parameter);  

                parameter = new QC.SqlParameter("@Url", DT.SqlDbType.NVarChar, 255);  
                parameter.Value = inputUrl;  
                command.Parameters.Add(parameter);  

                parameter = new QC.SqlParameter("@Description", DT.SqlDbType.NVarChar, 255);  
                parameter.Value = inputDescription;  
                command.Parameters.Add(parameter);  

                parameter = new QC.SqlParameter("@OwnerName", DT.SqlDbType.NVarChar, 255);  
                parameter.Value = inputOwnerName;  
                command.Parameters.Add(parameter);  

                parameter = new QC.SqlParameter("@Category", DT.SqlDbType.NVarChar, 255);  
                parameter.Value = inputCategory;  
                command.Parameters.Add(parameter);  

                parameter = new QC.SqlParameter("@Points", DT.SqlDbType.NVarChar, 255);  
                parameter.Value = inputPoints;  
                command.Parameters.Add(parameter);  
                
                string title = (string)command.ExecuteScalar();  
                Console.WriteLine("Record added - {0}", title);  
            }  
        }  


    }

    public class FullName
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string BirthDate { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public string OwnerName { get; set; }

        public string Category { get; set; }

        public string Points { get; set; }
    }


}

using DNEBlazor.Data.Models.Ecom;
using DNEBlazor.Repository.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DNEBlazor.Service.Ecom
{
    public class ImageService
    {
        private readonly ApplicationDbContext context;
        private readonly IConfiguration configuration;

        public ImageService(ApplicationDbContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public bool UploadImage(Image image)
        {
            string connectionString = configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string sql = $"Insert into ProductsEcom(Picture) Values('{image.Picture}')";
                //using (SqlCommand command = new SqlCommand(sql, sqlConnection))
                //{
                //    command.CommandType = CommandType.Text;
                //    sqlConnection.Open();
                //    command.ExecuteNonQuery();
                //    sqlConnection.Close();
                //}

                SqlDataAdapter sda = new SqlDataAdapter(sql, sqlConnection);
                DataTable dt = new DataTable();
                sda.Fill(dt);

            }
            return true;
        }
    }
}

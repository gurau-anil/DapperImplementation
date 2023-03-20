﻿using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace DapperImplementation.DAL.Infrastructure
{
    public interface IConnectionFactory
    {
        SqlConnection GetConnection { get; }
    }
    public class ConnectionFactory : IConnectionFactory
    {
        IConfiguration Configuration;

        public ConnectionFactory(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public SqlConnection GetConnection
        {
            get
            {
                var connectionString = Configuration.GetConnectionString("DefaultConnection");
                return new SqlConnection(connectionString);
            }
        }
    }
}

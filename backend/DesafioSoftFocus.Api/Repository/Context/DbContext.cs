using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DesafioSoftFocus.Api.Repository.Context
{
    public class DbContext : IDisposable
    {
        private MySqlConnection _conn;

        private readonly string _connString;

        public DbContext(IConfiguration config)
        {
            _connString = config["Connection"];
        }

        public void Dispose()
        {
            if (_conn != null)
            {
                MySqlConnection.ClearPool(_conn);
                _conn.Dispose();
                _conn.Close();
            }
        }

        public MySqlConnection getConnection()
        {
            _conn = new MySqlConnection(_connString);
            OpenConnection();
            return _conn;
        }

        public async Task<MySqlConnection> getConnectionAsync()
        {
            _conn = new MySqlConnection(_connString);
            await OpenConnectionAsync();
            return _conn;
        }

        private bool OpenConnection()
        {
            try
            {
                if (_conn.State != System.Data.ConnectionState.Open)
                    _conn.Open();

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

                return false;
            }
        }

        private async Task<bool> OpenConnectionAsync()
        {
            try
            {
                if (_conn.State != System.Data.ConnectionState.Open)
                    await _conn.OpenAsync();

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

                return false;
            }
        }
    }
}

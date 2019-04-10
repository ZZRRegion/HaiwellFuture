using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HaiwellFuture.ViewModels;
using System.Data.SQLite;
using System.Data;

namespace HaiwellFuture.Services
{
    public class ProjectScadaService : IProjectScadaView
    {
        public string ConnectionString { get; private set; }
        public ProjectViewModel GetViewModel()
        {
            ProjectViewModel projectViewModel = new ProjectViewModel();
            DataTable dtHaiwell = this.GetDataTable("haiwell");
            if(dtHaiwell != null && dtHaiwell.Rows.Count > 0)
            {
                DataRow row = dtHaiwell.Rows[0];
                projectViewModel.CloudScadaVersion = Convert.ToString(row["CloudScadaVersion"]);
                projectViewModel.DbSchemaVersion2 = Convert.ToString(row[nameof(projectViewModel.DbSchemaVersion2)]);
                projectViewModel.CreateTime = Convert.ToString(row["CreateDateTime"]);
                projectViewModel.ModificationDateTime = Convert.ToString(row["ModificationDateTime"]);
                projectViewModel.ModificationScadaVersion = Convert.ToString(row["ModificationScadaVersion"]);
                projectViewModel.ProjectCode = Convert.ToString(row["ProjectCode"]);
            }
            DataTable dtProject = this.GetDataTable("project");
            if(dtProject != null && dtProject.Rows.Count > 0)
            {
                DataRow row = dtProject.Rows[0];
                projectViewModel.ProjectName = Convert.ToString(row["Name"]);
                projectViewModel.HMIOrPC = Convert.ToString(row["HMIOrPC"]);
                projectViewModel.ScreenSize = Convert.ToString(row["ScreenSize"]);
                projectViewModel.CompileTime = Convert.ToString(row["CompileTime"]);
                projectViewModel.CompileGuid = Convert.ToString(row["CompileGuid"]);
                projectViewModel.ProjectSize = Convert.ToString(row["ProjectSize"]);
            }
            return projectViewModel;
        }
        private string dbpassword = "$HW@gZ25dzv*u0.nT$bhBl5!eFbS";
        public void SetFile(string fileName)
        {
            this.ConnectionString = $"Data Source={fileName};Version=3;Password={this.dbpassword};";
            try
            {
                this.ExecuteNonQuery("Select * from haiwell");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                this.ConnectionString = $"Data Source={fileName};Version=3;";
            }
        }
        private DataTable GetDataTable(string tableName)
        {
            DataTable dt = new DataTable();
            SQLiteConnection con = this.GetSQLiteConnection();
            try
            {
                SQLiteCommand cmd = con.CreateCommand();
                cmd.CommandText = $"Select * from {tableName}";
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                int count = da.Fill(dt);
                da.Dispose();
            }
            finally
            {
                CloseSQLiteConnection(con);
            }
            return dt;
        }
        private void ExecuteNonQuery(string sql)
        {
            SQLiteConnection con = this.GetSQLiteConnection();
            try
            {
                SQLiteCommand cmd = con.CreateCommand();
                cmd.CommandText = sql;
                int count = cmd.ExecuteNonQuery();
            }
            finally
            {
                CloseSQLiteConnection(con);
            }
        }
        private SQLiteConnection GetSQLiteConnection()
        {
            SQLiteConnection con = new SQLiteConnection(this.ConnectionString);
            con.Open();
            return con;
        }
        private void CloseSQLiteConnection(SQLiteConnection con)
        {
            con?.Close();
            con?.Dispose();
        }
    }
}

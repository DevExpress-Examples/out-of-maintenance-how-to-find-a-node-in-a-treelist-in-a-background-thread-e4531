using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using DevExpress.XtraSplashScreen;

namespace AsynchronousFindInTreeList {
    public static class DataHelper {
        static string ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=../../sampleDB.mdb";
        public static void GenegateData(int recordCount, int newRootRecordInterval) {
            OleDbConnection conn = new OleDbConnection(ConnectionString);
            conn.Open();
            try {
                OleDbCommand cmd = conn.CreateCommand();
                for(int i = 1; i < recordCount; i++) {
                    string command = string.Format("INSERT INTO TESTTABLE VALUES ({0}, {1}, {2}, '{3}', '{4}')", i, i % newRootRecordInterval == 0 ? 0 : i - 1, 0, "root_" + i, "root_i_" + i);
                    cmd.CommandText = command;
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            finally {
                conn.Close();
            }
        }
        public static DataTable GetDataTable() {
            string query = "Select * from TESTTABLE";
            DataTable dt = new DataTable("TESTTABLE");
            using(var cnn = new OleDbConnection(ConnectionString)) {
                cnn.Open();
                using(var da = new OleDbDataAdapter()) {
                    da.SelectCommand = new OleDbCommand(query, cnn);
                    da.Fill(dt);
                }
            }
            return dt;
        }
    }
}

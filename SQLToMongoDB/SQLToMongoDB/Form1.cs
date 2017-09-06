using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Data.SqlClient;


namespace SQLToMongoDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Migrate_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = txtConnectionString.Text;//ConfigurationManager.AppSettings["connectionStr"].ToString();
                conn.Open();

                // use the connection here

                string mongoDBConnectionString = txtMongoDBString.Text;
                IMongoClient _client = new MongoClient(mongoDBConnectionString);
                IMongoDatabase mongoDB = _client.GetDatabase(txtDBName.Text);


                try
                {

                    int iteration = (int)Math.Ceiling((double)(Convert.ToInt64(lblRecordCount.Text)) / (double)(Convert.ToInt64(txttChunkSize.Text)));
                    for (int i = 0; i < iteration; i++)
                    {
                        string strQueryInline = "select top " + Convert.ToInt64(txttChunkSize.Text) + " * from " + txtTableName.Text + " Where " + txtUniqueColumn.Text + " > " + i * Convert.ToInt64(txttChunkSize.Text) + " order by " + txtUniqueColumn.Text;
                        SqlDataAdapter adpt = new SqlDataAdapter(strQueryInline, conn);

                        DataTable dt = new DataTable();
                        adpt.Fill(dt);

                        var collection = mongoDB.GetCollection<BsonDocument>(txtTableName.Text);


                        foreach (DataRow dr in dt.Rows)
                        {
                            try
                            {
                                BsonDocument bson = new BsonDocument();
                                BsonDocument childBsonDocument = new BsonDocument();
                                //BsonDocument[] insertBsonDocuments;
                                //BsonDocument[] updateBsonDocuments;
                                // BsonElement element = new BsonElement();
                                string uniqueColumn = string.Empty, custId = string.Empty;
                                Int64 ticks = 0;

                                for (int col = 0; col < dr.ItemArray.Count(); col++)
                                {
                                    if (dr.Table.Columns[col].ColumnName == "CustomerId")
                                    {
                                        custId = dr[col].ToString();
                                        bson.Add(new BsonElement(dr.Table.Columns[col].ColumnName, BsonValue.Create(Convert.ToInt64(dr[col]))));
                                    }
                                    else if (dr.Table.Columns[col].ColumnName == "ActivityDateTime")
                                    {
                                        DateTimeOffset _dateTimeOffset = (DateTimeOffset)dr[col];
                                        ticks = _dateTimeOffset.Date.Ticks;
                                        // uniqueColumn = string.Concat(ticks);
                                        bson.Add(new BsonElement(dr.Table.Columns[col].ColumnName, BsonValue.Create(ticks)));
                                    }
                                    else
                                    {
                                        childBsonDocument.Add(new BsonElement(dr.Table.Columns[col].ColumnName, dr[col].ToString()));

                                    }

                                    //uncomment below section to support data type
                                    //if (dr.Table.Columns[col].DataType == typeof(string) || dr[col] == DBNull.Value)
                                    //    bson.Add(new BsonElement(dr.Table.Columns[col].ColumnName, dr[col].ToString()));
                                    //else if (dr.Table.Columns[col].DataType == typeof(Int16))
                                    //    bson.Add(new BsonElement(dr.Table.Columns[col].ColumnName, BsonValue.Create(Convert.ToInt16(dr[col]))));
                                    //else if (dr.Table.Columns[col].DataType == typeof(Int32))
                                    //    bson.Add(new BsonElement(dr.Table.Columns[col].ColumnName, BsonValue.Create(Convert.ToInt32(dr[col]))));
                                    //else if (dr.Table.Columns[col].DataType == typeof(Int64))
                                    //    bson.Add(new BsonElement(dr.Table.Columns[col].ColumnName, BsonValue.Create(Convert.ToInt64(dr[col]))));
                                    //else if (dr.Table.Columns[col].DataType == typeof(DateTime))
                                    //    bson.Add(new BsonElement(dr.Table.Columns[col].ColumnName, BsonValue.Create(Convert.ToDateTime(dr[col]))));
                                    //else if (dr.Table.Columns[col].DataType == typeof(DateTimeOffset))
                                    //{
                                    //    if (dr[col].ToString() != string.Empty)
                                    //    {
                                    //        //DateTime baseTime = new DateTime(2008, 6, 19, 7, 0, 0);
                                    //        //DateTimeOffset _dateTimeOffset = new DateTimeOffset(baseTime, TimeZoneInfo.Local.GetUtcOffset((DateTimeOffset)dr[col]));
                                    //        //bson.Add(new BsonElement(dr.Table.Columns[col].ColumnName, BsonValue.Create(_dateTimeOffset.DateTime)));

                                    //        DateTimeOffset _dateTimeOffset = (DateTimeOffset)dr[col];
                                    //        bson.Add(new BsonElement(dr.Table.Columns[col].ColumnName, BsonValue.Create(_dateTimeOffset.UtcDateTime)));
                                    //    }
                                    //    else
                                    //        bson.Add(new BsonElement(dr.Table.Columns[col].ColumnName, dr[col].ToString()));
                                    //}


                                }
                                BsonArray arr = new BsonArray();
                                arr.Add(childBsonDocument);
                                uniqueColumn = string.Concat(custId, "_", ticks);
                                bson.Add("Data", arr);
                                bson.Add(new BsonElement("CustDate", uniqueColumn));
                                var filter = Builders<BsonDocument>.Filter.Eq("CustDate", uniqueColumn);
                                var find = collection.Find<BsonDocument>(filter).FirstOrDefault<BsonDocument>();
                                if (find != null)
                                {
                                    var update = Builders<BsonDocument>.Update.Push("Data", childBsonDocument);
                                    collection.UpdateOne(filter, update);
                                }
                                else
                                {
                                    collection.InsertOne(bson);
                                }
                            }
                            catch (Exception ex)
                            {
                                lblMessage.Text += string.Concat("exception in iteration ", i, ", Exception: ", ex.Message, " ");
                            }

                        }

                        lblMessage.Text = (i + 1) * Convert.ToInt64(txttChunkSize.Text) + "Migratted Successfully";

                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Visible = true;
                    lblMessage.Text += "Failure: " + ex.Message;
                }
            }
        }

        //private void Migrate_Click(object sender, EventArgs e)
        //{
        //    using (SqlConnection conn = new SqlConnection())
        //    {
        //        conn.ConnectionString = txtConnectionString.Text;//ConfigurationManager.AppSettings["connectionStr"].ToString();
        //        conn.Open();

        //        // use the connection here

        //        string mongoDBConnectionString = txtMongoDBString.Text;
        //        IMongoClient _client = new MongoClient(mongoDBConnectionString);
        //        IMongoDatabase mongoDB = _client.GetDatabase(txtDBName.Text);


        //        try
        //        {

        //            int iteration = (int)Math.Ceiling((double)(Convert.ToInt64(lblRecordCount.Text)) / (double)(Convert.ToInt64(txttChunkSize.Text)));
        //            for (int i = 0; i < iteration; i++)
        //            {
        //                string strQueryInline = "select top " + Convert.ToInt64(txttChunkSize.Text) + " * from " + txtTableName.Text + " Where " + txtUniqueColumn.Text + " > " + i * Convert.ToInt64(txttChunkSize.Text) + " order by " + txtUniqueColumn.Text;
        //                SqlDataAdapter adpt = new SqlDataAdapter(strQueryInline, conn);

        //                DataTable dt = new DataTable();
        //                adpt.Fill(dt);

        //                var collection = mongoDB.GetCollection<BsonDocument>(txtTableName.Text);


        //                foreach (DataRow dr in dt.Rows)
        //                {

        //                    BsonDocument bson = new BsonDocument();
        //                    BsonElement element = new BsonElement();

        //                    for (int col = 0; col < dr.ItemArray.Count(); col++)
        //                    {
        //                        //uncomment below section to support data type
        //                        //if (dr.Table.Columns[col].DataType == typeof(string) || dr[col] == DBNull.Value)
        //                        //    bson.Add(new BsonElement(dr.Table.Columns[col].ColumnName, dr[col].ToString()));
        //                        //else if (dr.Table.Columns[col].DataType == typeof(Int16))
        //                        //    bson.Add(new BsonElement(dr.Table.Columns[col].ColumnName, BsonValue.Create(Convert.ToInt16(dr[col]))));
        //                        //else if (dr.Table.Columns[col].DataType == typeof(Int32))
        //                        //    bson.Add(new BsonElement(dr.Table.Columns[col].ColumnName, BsonValue.Create(Convert.ToInt32(dr[col]))));
        //                        //else if (dr.Table.Columns[col].DataType == typeof(Int64))
        //                        //    bson.Add(new BsonElement(dr.Table.Columns[col].ColumnName, BsonValue.Create(Convert.ToInt64(dr[col]))));
        //                        //else if (dr.Table.Columns[col].DataType == typeof(DateTime))
        //                        //    bson.Add(new BsonElement(dr.Table.Columns[col].ColumnName, BsonValue.Create(Convert.ToDateTime(dr[col]))));
        //                        //else if (dr.Table.Columns[col].DataType == typeof(DateTimeOffset))
        //                        //{
        //                        //    if (dr[col].ToString() != string.Empty)
        //                        //    {
        //                        //        //DateTime baseTime = new DateTime(2008, 6, 19, 7, 0, 0);
        //                        //        //DateTimeOffset _dateTimeOffset = new DateTimeOffset(baseTime, TimeZoneInfo.Local.GetUtcOffset((DateTimeOffset)dr[col]));
        //                        //        //bson.Add(new BsonElement(dr.Table.Columns[col].ColumnName, BsonValue.Create(_dateTimeOffset.DateTime)));

        //                        //        DateTimeOffset _dateTimeOffset = (DateTimeOffset)dr[col];
        //                        //        bson.Add(new BsonElement(dr.Table.Columns[col].ColumnName, BsonValue.Create(_dateTimeOffset.UtcDateTime)));
        //                        //    }
        //                        //    else
        //                        //        bson.Add(new BsonElement(dr.Table.Columns[col].ColumnName, dr[col].ToString()));
        //                        //}
        //                        bson.Add(new BsonElement(dr.Table.Columns[col].ColumnName, dr[col].ToString()));
        //                    }
        //                    collection.InsertOne(bson);


        //                }

        //                lblMessage.Text = (i + 1) * Convert.ToInt64(txttChunkSize.Text) + "Migratted Successfully";

        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            lblMessage.Visible = true;
        //            lblMessage.Text = "Failure: " + ex.Message;
        //        }
        //    }
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                string strQueryInline = "select Count(1) from " + txtTableName.Text;
                SqlDataReader dr = null;
                try
                {
                    conn.ConnectionString = txtConnectionString.Text;//ConfigurationManager.AppSettings["connectionStr"].ToString();
                    conn.Open();


                    SqlCommand cmd = new SqlCommand(strQueryInline, conn);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        lblRecordCount.Text = dr[0].ToString();
                        lblRecordCount.Visible = true;
                    }
                }
                finally
                {
                    if (dr != null) dr.Close();
                    if (conn != null) conn.Close();
                }
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcoCBRcls;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using EcoCBRcls;



namespace EcoCBR_DB
{
    public class EcoCBRDB
    {
        //HConnect connect = new HConnect();
        SqlConnection connect = new SqlConnection();

        public EcoCBRDB()
        {
            connect.ConnectionString = "Database=EcoCBRDB;Server=KULHROLWLR0XYKP\\SQLSERVER14;user Id=sa;password=p@ssw0rd";
        }

        public EcoCBRDB(string conString)
        {
            connect.ConnectionString = conString;
        }

        public DataTable selectDDL(string value)
        {
            DataSet ds;

            try
            {
                connect.Open();
                SqlCommand cm = new SqlCommand();
                cm.CommandText = "SELECT distinct([" + value + "]) FROM data_edited where [" + value + "] is not null";
                cm.CommandType = CommandType.Text;
                //cm.Parameters.Add(new SqlParameter("@State", stateid));


                cm.Connection = connect;
                ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cm;
                da.Fill(ds, "Table1");
                //if (cm.Parameters["@msg"].Value != DBNull.Value || !cm.Parameters["@msg"].Value.ToString().Equals(""))
                //    msg = cm.Parameters["@msg"].Value.ToString();
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                connect.Close();
            }

            return ds.Tables["Table1"];
        }

        public DataTable selectDDL(string value, string materialValue)
        {
            DataSet ds;

            try
            {
                connect.Open();
                SqlCommand cm = new SqlCommand();
                cm.CommandText = "SELECT distinct([" + value + "]) FROM data_edited where [" + value + "] is not null and [Material Type] = '" + materialValue + "' ";
                cm.CommandType = CommandType.Text;
                //cm.Parameters.Add(new SqlParameter("@State", stateid));


                cm.Connection = connect;
                ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cm;
                da.Fill(ds, "Table1");
                //if (cm.Parameters["@msg"].Value != DBNull.Value || !cm.Parameters["@msg"].Value.ToString().Equals(""))
                //    msg = cm.Parameters["@msg"].Value.ToString();
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                connect.Close();
            }

            return ds.Tables["Table1"];
        }

        public int selectMaxRow()
        {
            DataSet ds;

            try
            {
                connect.Open();
                SqlCommand cm = new SqlCommand();
                cm.CommandText = "select count(1) as maxno FROM data_edited ";
                cm.CommandType = CommandType.Text;
                //cm.Parameters.Add(new SqlParameter("@State", stateid));


                cm.Connection = connect;
                ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cm;
                da.Fill(ds, "Table1");
                //if (cm.Parameters["@msg"].Value != DBNull.Value || !cm.Parameters["@msg"].Value.ToString().Equals(""))
                //    msg = cm.Parameters["@msg"].Value.ToString();
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                connect.Close();
            }

            return int.Parse(ds.Tables["Table1"].Rows[0]["maxno"].ToString());
        }

        public bool selectExist(string value, string valueToCheck)
        {
            bool exist = false;
            DataSet ds;

            try
            {
                connect.Open();
                SqlCommand cm = new SqlCommand();
                cm.CommandText = "SELECT 1 FROM data_edited where [" + value + "] = '" + valueToCheck + "'";
                cm.CommandType = CommandType.Text;
                //cm.Parameters.Add(new SqlParameter("@State", stateid));


                cm.Connection = connect;
                ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cm;
                da.Fill(ds, "Table1");
                //if (cm.Parameters["@msg"].Value != DBNull.Value || !cm.Parameters["@msg"].Value.ToString().Equals(""))
                //    msg = cm.Parameters["@msg"].Value.ToString();
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                connect.Close();
            }

            //return ds.Tables["Table1"];
            if (ds.Tables["Table1"].Rows.Count > 0)
                exist = true;

            return exist;
        }

        public DataTable selectMaxMin(string value, List<Tuple<string, string>> listCriteria)
        {
            DataSet ds;
            var commandText = "";

            try
            {
                connect.Open();
                SqlCommand cm = new SqlCommand();
                commandText = "SELECT max([" + value + "]) as maxvalue,min([" + value + "]) as minvalue FROM data_edited ";

                if (listCriteria.Count > 0)
                    commandText += " where ";

                for (int i = 0; i < listCriteria.Count; i++)
                {
                    Tuple<string, string> tRows = listCriteria[i];
                    commandText += "[" + tRows.Item1 + "] = '" + tRows.Item2 + "'";

                    if (i < (listCriteria.Count - 1) && listCriteria.Count > 1)
                        commandText += " and ";
                }

                cm.CommandText = commandText;
                cm.CommandType = CommandType.Text;
                //cm.Parameters.Add(new SqlParameter("@State", stateid));


                cm.Connection = connect;
                ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cm;
                da.Fill(ds, "Table1");
                //if (cm.Parameters["@msg"].Value != DBNull.Value || !cm.Parameters["@msg"].Value.ToString().Equals(""))
                //    msg = cm.Parameters["@msg"].Value.ToString();
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                connect.Close();
            }

            return ds.Tables["Table1"];
        }

        public DataTable selectAllConditional(List<Tuple<string, string>> listCriteria)
        {
            DataSet ds;
            var commandText = "";

            try
            {
                connect.Open();
                SqlCommand cm = new SqlCommand();
                //commandText = "SELECT * FROM data_edited ";
                commandText = "SELECT * FROM data_edited ";

                if (listCriteria.Count > 0)
                    commandText += " where ";

                for (int i = 0; i < listCriteria.Count; i++)
                {
                    Tuple<string, string> tRows = listCriteria[i];
                    commandText += "[" + tRows.Item1 + "] = '" + tRows.Item2 + "'";

                    if (i < (listCriteria.Count - 1) && listCriteria.Count > 1)
                        commandText += " and ";
                }

                cm.CommandText = commandText;
                cm.CommandType = CommandType.Text;
                //cm.Parameters.Add(new SqlParameter("@State", stateid));


                cm.Connection = connect;
                ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cm;
                da.Fill(ds, "Table1");
                //if (cm.Parameters["@msg"].Value != DBNull.Value || !cm.Parameters["@msg"].Value.ToString().Equals(""))
                //    msg = cm.Parameters["@msg"].Value.ToString();
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                connect.Close();
            }

            return ds.Tables["Table1"];
        }

        public DataTable selectMMPConditional(List<Tuple<string, string>> listCriteria)
        {
            DataSet ds;
            var commandText = "";

            try
            {
                connect.Open();
                SqlCommand cm = new SqlCommand();
                //commandText = "SELECT * FROM data_edited ";
                commandText = "SELECT top 10 [Case No],[Material Type],[Process],[Product Weight(gram)] FROM data_edited ";

                if (listCriteria.Count > 0)
                    commandText += " where ";

                for (int i = 0; i < listCriteria.Count; i++)
                {
                    Tuple<string, string> tRows = listCriteria[i];
                    commandText += "[" + tRows.Item1 + "] = '" + tRows.Item2 + "'";

                    if (i < (listCriteria.Count - 1) && listCriteria.Count > 1)
                        commandText += " and ";
                }

                cm.CommandText = commandText;
                cm.CommandType = CommandType.Text;
                //cm.Parameters.Add(new SqlParameter("@State", stateid));


                cm.Connection = connect;
                ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cm;
                da.Fill(ds, "Table1");
                //if (cm.Parameters["@msg"].Value != DBNull.Value || !cm.Parameters["@msg"].Value.ToString().Equals(""))
                //    msg = cm.Parameters["@msg"].Value.ToString();
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                connect.Close();
            }

            return ds.Tables["Table1"];
        }

        public DataTable selectTransportConditional(List<Tuple<string, string>> listCriteria)
        {
            DataSet ds;
            var commandText = "";

            try
            {
                connect.Open();
                SqlCommand cm = new SqlCommand();
                //commandText = "SELECT * FROM data_edited ";
                commandText = "SELECT top 10 [Case No],[Origin],[Destination],[Transport Type],[Distance(km)],[Product Weight(gram)] FROM data_edited ";

                if (listCriteria.Count > 0)
                    commandText += " where ";

                for (int i = 0; i < listCriteria.Count; i++)
                {
                    Tuple<string, string> tRows = listCriteria[i];
                    commandText += "[" + tRows.Item1 + "] = '" + tRows.Item2 + "'";

                    if (i < (listCriteria.Count - 1) && listCriteria.Count > 1)
                        commandText += " and ";
                }

                cm.CommandText = commandText;
                cm.CommandType = CommandType.Text;
                //cm.Parameters.Add(new SqlParameter("@State", stateid));


                cm.Connection = connect;
                ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cm;
                da.Fill(ds, "Table1");
                //if (cm.Parameters["@msg"].Value != DBNull.Value || !cm.Parameters["@msg"].Value.ToString().Equals(""))
                //    msg = cm.Parameters["@msg"].Value.ToString();
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                connect.Close();
            }

            return ds.Tables["Table1"];
        }

        public DataTable selectEOLConditional(List<Tuple<string, string>> listCriteria)
        {
            DataSet ds;
            var commandText = "";

            try
            {
                connect.Open();
                SqlCommand cm = new SqlCommand();
                //commandText = "SELECT * FROM data_edited ";
                commandText = "SELECT top 10 [Case No],[Recycled(%)],[Incinerated (%)],[Landfill (%)],[Product Weight(gram)] FROM data_edited ";

                if (listCriteria.Count > 0)
                    commandText += " where ";

                for (int i = 0; i < listCriteria.Count; i++)
                {
                    Tuple<string, string> tRows = listCriteria[i];
                    commandText += "[" + tRows.Item1 + "] = '" + tRows.Item2 + "'";

                    if (i < (listCriteria.Count - 1) && listCriteria.Count > 1)
                        commandText += " and ";
                }

                cm.CommandText = commandText;
                cm.CommandType = CommandType.Text;
                //cm.Parameters.Add(new SqlParameter("@State", stateid));


                cm.Connection = connect;
                ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cm;
                da.Fill(ds, "Table1");
                //if (cm.Parameters["@msg"].Value != DBNull.Value || !cm.Parameters["@msg"].Value.ToString().Equals(""))
                //    msg = cm.Parameters["@msg"].Value.ToString();
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                connect.Close();
            }

            return ds.Tables["Table1"];
        }

        public DataTable selectProductDesignConditional(List<Tuple<string, string>> listCriteria)
        {
            DataSet ds;
            var commandText = "";

            try
            {
                connect.Open();
                SqlCommand cm = new SqlCommand();
                //commandText = "SELECT * FROM data_edited ";
                commandText = "SELECT top 10 [Case No],[Thin Region(mm)],[Thick Region(mm)],[Height(mm)],[Surface Area(mm2)],[Volume(mm3)],[Perimeter(mm)],[Product Weight(gram)] FROM data_edited ";

                if (listCriteria.Count > 0)
                    commandText += " where ";

                for (int i = 0; i < listCriteria.Count; i++)
                {
                    Tuple<string, string> tRows = listCriteria[i];
                    commandText += "[" + tRows.Item1 + "] = '" + tRows.Item2 + "'";

                    if (i < (listCriteria.Count - 1) && listCriteria.Count > 1)
                        commandText += " and ";
                }

                cm.CommandText = commandText;
                cm.CommandType = CommandType.Text;
                //cm.Parameters.Add(new SqlParameter("@State", stateid));


                cm.Connection = connect;
                ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cm;
                da.Fill(ds, "Table1");
                //if (cm.Parameters["@msg"].Value != DBNull.Value || !cm.Parameters["@msg"].Value.ToString().Equals(""))
                //    msg = cm.Parameters["@msg"].Value.ToString();
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                connect.Close();
            }

            return ds.Tables["Table1"];
        }

        public DataTable selectAll(List<string> listCriteria)
        {
            DataSet ds;
            var commandText = "";

            try
            {
                connect.Open();
                SqlCommand cm = new SqlCommand();
                commandText = "SELECT * FROM data_edited ";

                if (listCriteria.Count > 0)
                    commandText += " where [Case No] in (";

                for (int i = 0; i < listCriteria.Count; i++)
                {
                    string case_no = listCriteria[i];
                    commandText += "'" + case_no + "'";

                    if (i < (listCriteria.Count - 1) && listCriteria.Count > 1)
                        commandText += " , ";
                }

                if (listCriteria.Count > 0)
                    commandText += " ) ";

                cm.CommandText = commandText;
                cm.CommandType = CommandType.Text;
                //cm.Parameters.Add(new SqlParameter("@State", stateid));


                cm.Connection = connect;
                ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cm;
                da.Fill(ds, "Table1");
                //if (cm.Parameters["@msg"].Value != DBNull.Value || !cm.Parameters["@msg"].Value.ToString().Equals(""))
                //    msg = cm.Parameters["@msg"].Value.ToString();
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                connect.Close();
            }

            return ds.Tables["Table1"];
        }

        public DataSet selectAllPair(List<Tuple<string, string>> listCaseNoPair)
        {
            DataSet ds = new DataSet();
            var commandText = "";

            try
            {
                connect.Open();
                SqlCommand cm = new SqlCommand();

                for (int i = 0; i < listCaseNoPair.Count; i++)
                {
                    commandText = "SELECT * FROM data_edited ";

                    if (listCaseNoPair.Count > 0)
                        commandText += " where [Case No] in (";


                    string case_no = listCaseNoPair[i].Item2;
                    commandText += "'" + case_no + "'";

                    if (listCaseNoPair.Count > 0)
                        commandText += " ) ";

                    cm.CommandText = commandText;
                    cm.CommandType = CommandType.Text;
                    //cm.Parameters.Add(new SqlParameter("@State", stateid));

                    cm.Connection = connect;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cm;
                    da.Fill(ds, listCaseNoPair[i].Item1.ToString());
                }
                //if (cm.Parameters["@msg"].Value != DBNull.Value || !cm.Parameters["@msg"].Value.ToString().Equals(""))
                //    msg = cm.Parameters["@msg"].Value.ToString();
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                connect.Close();
            }

            return ds;
        }

        public DataTable selectAll(List<Tuple<string, string>> listCriteria)
        {
            DataSet ds;
            var commandText = "";

            try
            {
                connect.Open();
                SqlCommand cm = new SqlCommand();
                commandText = "SELECT * FROM data_edited ";

                if (listCriteria.Count > 0)
                    commandText += " where ";

                cm.CommandText = commandText;
                cm.CommandType = CommandType.Text;
                //cm.Parameters.Add(new SqlParameter("@State", stateid));


                cm.Connection = connect;
                ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cm;
                da.Fill(ds, "Table1");
                //if (cm.Parameters["@msg"].Value != DBNull.Value || !cm.Parameters["@msg"].Value.ToString().Equals(""))
                //    msg = cm.Parameters["@msg"].Value.ToString();
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                connect.Close();
            }

            return ds.Tables["Table1"];
        }

        public DataTable selectMaterialType()
        {
            DataSet ds;

            try
            {
                connect.Open();
                SqlCommand cm = new SqlCommand();
                cm.CommandText = "SELECT distinct(Origin) FROM data_edited where Origin is not null";
                cm.CommandType = CommandType.Text;
                //cm.Parameters.Add(new SqlParameter("@State", stateid));


                cm.Connection = connect;
                ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cm;
                da.Fill(ds, "Table1");
                //if (cm.Parameters["@msg"].Value != DBNull.Value || !cm.Parameters["@msg"].Value.ToString().Equals(""))
                //    msg = cm.Parameters["@msg"].Value.ToString();
            }
            catch (Exception e)
            {
                throw (e);
            }
            finally
            {
                connect.Close();
            }

            return ds.Tables["Table1"];
        }

        public int insertEcoBR(clsEcoCBR ecoBR)
        {
            int inserted = 0;
            SqlCommand cm = new SqlCommand();

            try
            {
                var cmdText = "";
                cmdText = "INSERT [dbo].[data_edited]([Case No], [Origin], [Destination], [Transport Type], [Distance(km)], " +
                     " [Material Type], [Process], [Product Weight(gram)], [Recycled(%)], [Incinerated (%)], [Landfill (%)], " +
                     " [Thin Region(mm)], [Thick Region(mm)], [Height(mm)], [Surface Area(mm2)], [Perimeter(mm)], [Volume(mm3)], " +
                     " [Carbon_Material], [Carbon_Manufacturing], [Carbon_Use], [Carbon_End Of Life], [Carbon_Transport], [EnergyCon_Material], " +
                     " [EnergyCon_Manufacturing], [EnergyCon_Use], [EnergyCon_End Of Life], [EnergyCon_Transport], [AirAcid_Material], [AirAcid_Manufacturing], " +
                     " [AirAcid_Use], [AirAcid_End Of Life], [AirAcid_Transport], [WaterEu_Material], [WaterEu_Manufacturing], [WaterEu_Use], [WaterEu_End Of Life], " +
                     " [WaterEu_Transport]) " +
                            " VALUES " +
                     " (@Case_No, @Origin, @Destination, @Transport, @Distance, @Material, @Process, @Product_Weight, @Recycled, @Incinerated, @Landfill, @Thin_Region, @Thick_Region, @Height, @Surface_Area, @Perimeter, " +
                     " @Volume, @Carbon_Material, @Carbon_Manufacturing, @Carbon_Use, @Carbon_EndOfLife, @Carbon_Transport, " +
                     " @EnergyCon_Material, @EnergyCon_Manufacturing, @EnergyCon_Use, @EnergyCon_EndOfLife, @EnergyCon_Transport, " +
                     " @AirAcid_Material, @AirAcid_Manufacturing, @AirAcid_Use, @AirAcid_EndOfLife, @AirAcid_Transport, " +
                     " @WaterEu_Material, @WaterEu_Manufacturing, @WaterEu_Use, @WaterEu_EndOfLife, @WaterEu_Transport) ";
                cm.CommandText = cmdText;

                cm.Parameters.Add(new SqlParameter("@Case_No", ecoBR.Case_No));
                cm.Parameters.Add(new SqlParameter("@Origin", ecoBR.Origin));
                cm.Parameters.Add(new SqlParameter("@Destination", ecoBR.Destination));
                cm.Parameters.Add(new SqlParameter("@Transport", ecoBR.Transport));
                cm.Parameters.Add(new SqlParameter("@Distance", ecoBR.Distance));
                cm.Parameters.Add(new SqlParameter("@Material", ecoBR.Material));
                cm.Parameters.Add(new SqlParameter("@Process", ecoBR.Process));
                cm.Parameters.Add(new SqlParameter("@Product_Weight", ecoBR.Product_Weight));
                cm.Parameters.Add(new SqlParameter("@Recycled", ecoBR.Recycled));
                cm.Parameters.Add(new SqlParameter("@Incinerated", ecoBR.Incinerated));
                cm.Parameters.Add(new SqlParameter("@Landfill", ecoBR.Landfill));
                cm.Parameters.Add(new SqlParameter("@Thin_Region", ecoBR.Thin_Region));
                cm.Parameters.Add(new SqlParameter("@Thick_Region", ecoBR.Thick_Region));
                cm.Parameters.Add(new SqlParameter("@Height", ecoBR.Height));
                cm.Parameters.Add(new SqlParameter("@Surface_Area", ecoBR.Surface_Area));
                cm.Parameters.Add(new SqlParameter("@Perimeter", ecoBR.Perimeter));
                cm.Parameters.Add(new SqlParameter("@Volume", ecoBR.Volume));

                cm.Parameters.Add(new SqlParameter("@Carbon_Material", ecoBR.Carbon_Material));
                cm.Parameters.Add(new SqlParameter("@EnergyCon_Material", ecoBR.EnergyCon_Material));
                cm.Parameters.Add(new SqlParameter("@AirAcid_Material", ecoBR.AirAcid_Material));
                cm.Parameters.Add(new SqlParameter("@WaterEu_Material", ecoBR.WaterEu_Material));

                cm.Parameters.Add(new SqlParameter("@Carbon_Manufacturing", ecoBR.Carbon_Manufacturing));
                cm.Parameters.Add(new SqlParameter("@EnergyCon_Manufacturing", ecoBR.EnergyCon_Manufacturing));
                cm.Parameters.Add(new SqlParameter("@AirAcid_Manufacturing", ecoBR.AirAcid_Manufacturing));
                cm.Parameters.Add(new SqlParameter("@WaterEu_Manufacturing", ecoBR.WaterEu_Manufacturing));

                cm.Parameters.Add(new SqlParameter("@Carbon_Use", ecoBR.Carbon_Use));
                cm.Parameters.Add(new SqlParameter("@EnergyCon_Use", ecoBR.EnergyCon_Use));
                cm.Parameters.Add(new SqlParameter("@AirAcid_Use", ecoBR.AirAcid_Use));
                cm.Parameters.Add(new SqlParameter("@WaterEu_Use", ecoBR.WaterEu_Use));

                cm.Parameters.Add(new SqlParameter("@Carbon_EndOfLife", ecoBR.Carbon_EndOfLife));
                cm.Parameters.Add(new SqlParameter("@EnergyCon_EndOfLife", ecoBR.EnergyCon_EndOfLife));
                cm.Parameters.Add(new SqlParameter("@AirAcid_EndOfLife", ecoBR.AirAcid_EndOfLife));
                cm.Parameters.Add(new SqlParameter("@WaterEu_EndOfLife", ecoBR.WaterEu_EndOfLife));

                cm.Parameters.Add(new SqlParameter("@Carbon_Transport", ecoBR.Carbon_Transport));
                cm.Parameters.Add(new SqlParameter("@EnergyCon_Transport", ecoBR.EnergyCon_Transport));
                cm.Parameters.Add(new SqlParameter("@AirAcid_Transport", ecoBR.AirAcid_Transport));
                cm.Parameters.Add(new SqlParameter("@WaterEu_Transport", ecoBR.WaterEu_Transport));
                cm.CommandType = CommandType.Text;
                connect.Open();
                cm.Connection = connect;
                inserted += cm.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                //throw;
                inserted = 0;
            }
            finally
            {
                connect.Close();
            }

            return inserted;
        }

        //public int insertHotel(clsHotel hotel)
        //{
        //    int inserted = 0;
        //    SqlCommand cm = new SqlCommand();

        //    try
        //    {
        //        cm.CommandText = "usp_Hotel_Insert";

        //        cm.Parameters.Add(new SqlParameter("@Hotel", hotel.Hotel));
        //        cm.Parameters.Add(new SqlParameter("@Rating", hotel.Rating));
        //        cm.Parameters.Add(new SqlParameter("@Meeting", hotel.Meeting));
        //        cm.Parameters.Add(new SqlParameter("@MICE", hotel.MICE));
        //        cm.Parameters.Add(new SqlParameter("@HotelDetails", hotel.HotelDetails));
        //        cm.Parameters.Add(new SqlParameter("@Address", hotel.Address));
        //        cm.Parameters.Add(new SqlParameter("@Contact", hotel.Contact));
        //        cm.Parameters.Add(new SqlParameter("@Phone", hotel.Phone));
        //        cm.Parameters.Add(new SqlParameter("@Fax", hotel.Fax));
        //        cm.Parameters.Add(new SqlParameter("@Email", hotel.Email));
        //        cm.Parameters.Add(new SqlParameter("@Website", hotel.Website));
        //        cm.Parameters.Add(new SqlParameter("@RackRates", hotel.RackRates));
        //        cm.Parameters.Add(new SqlParameter("@RoomRates", hotel.RoomRates));
        //        cm.Parameters.Add(new SqlParameter("@Statedesc", hotel.State));
        //        cm.Parameters.Add(new SqlParameter("@Imagelink", hotel.Imagelink));
        //        cm.CommandType = CommandType.StoredProcedure;
        //        connect.Open();
        //        cm.Connection = connect;
        //        inserted += cm.ExecuteNonQuery();
        //    }
        //    catch (SqlException ex)
        //    {
        //        //throw;
        //        inserted = 0;
        //    }
        //    finally
        //    {
        //        connect.Close();
        //    }
        //    return inserted;
        //}

        //public int updateHotel(clsHotel hotel)
        //{
        //    int inserted = 0;
        //    SqlCommand cm = new SqlCommand();

        //    try
        //    {
        //        cm.CommandText = "usp_Hotel_Update";

        //        cm.Parameters.Add(new SqlParameter("@Hotel", hotel.Hotel));
        //        cm.Parameters.Add(new SqlParameter("@Rating", hotel.Rating));
        //        cm.Parameters.Add(new SqlParameter("@Meeting", hotel.Meeting));
        //        cm.Parameters.Add(new SqlParameter("@MICE", hotel.MICE));
        //        cm.Parameters.Add(new SqlParameter("@HotelDetails", hotel.HotelDetails));
        //        cm.Parameters.Add(new SqlParameter("@Address", hotel.Address));
        //        cm.Parameters.Add(new SqlParameter("@Contact", hotel.Contact));
        //        cm.Parameters.Add(new SqlParameter("@Phone", hotel.Phone));
        //        cm.Parameters.Add(new SqlParameter("@Fax", hotel.Fax));
        //        cm.Parameters.Add(new SqlParameter("@Email", hotel.Email));
        //        cm.Parameters.Add(new SqlParameter("@Website", hotel.Website));
        //        cm.Parameters.Add(new SqlParameter("@RackRates", hotel.RackRates));
        //        cm.Parameters.Add(new SqlParameter("@RoomRates", hotel.RoomRates));
        //        cm.Parameters.Add(new SqlParameter("@Statedesc", hotel.State));
        //        cm.Parameters.Add(new SqlParameter("@Imagelink", hotel.Imagelink));
        //        cm.Parameters.Add(new SqlParameter("@HotelID", hotel.ID));

        //        cm.CommandType = CommandType.StoredProcedure;
        //        connect.Open();
        //        cm.Connection = connect;
        //        inserted += cm.ExecuteNonQuery();
        //    }
        //    catch (SqlException ex)
        //    {
        //        //throw;
        //        inserted = 0;
        //    }
        //    finally
        //    {
        //        connect.Close();
        //    }
        //    return inserted;
        //}

    }
}

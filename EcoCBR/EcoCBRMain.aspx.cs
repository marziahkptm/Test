using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using EcoCBR_DB;
using EcoCBRcls;

namespace EcoBR
{
    public partial class EcoCBRMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                initPage();
            }
        }

        protected void ddlMMType_SelectedIndexChanged(object sender, EventArgs e)
        {
            initMaterialManifactureTwo();
        }

        private void initPage()
        {
            initMaterialManifacture();
            initTransportation();
            initEndOfLife();
            initProductDesign();
        }

        private void initMaterialManifacture()
        {
            //txtTest.Text = ConfigurationManager.ConnectionStrings["conString"].ToString();
            EcoCBRDB ecoDB = new EcoCBRDB(ConfigurationManager.ConnectionStrings["conString"].ToString());
            ddlMMType.DataSource = ecoDB.selectDDL("Material Type");
            ddlMMType.DataTextField = "Material Type";
            ddlMMType.DataBind();            
            //ddlMMProcess.DataSource = ecoDB.selectDDL("Process");
            ddlMMProcess.DataSource = ecoDB.selectDDL("Process", ddlMMType.SelectedValue);
            ddlMMProcess.DataTextField = "Process";
            ddlMMProcess.DataBind();
        }

        private void initMaterialManifactureTwo()
        {
            EcoCBRDB ecoDB = new EcoCBRDB(ConfigurationManager.ConnectionStrings["conString"].ToString());
            ddlMMProcess.DataSource = ecoDB.selectDDL("Process", ddlMMType.SelectedValue);
            ddlMMProcess.DataTextField = "Process";
            ddlMMProcess.DataBind();
        }

        private void initTransportation()
        {
            EcoCBRDB ecoDB = new EcoCBRDB(ConfigurationManager.ConnectionStrings["conString"].ToString());
            ddlTOrigin.DataSource = ecoDB.selectDDL("Origin");
            ddlTOrigin.DataTextField = "Origin";
            ddlTOrigin.DataBind();
            ddlTDestination.DataSource = ecoDB.selectDDL("Destination");
            ddlTDestination.DataTextField = "Destination";
            ddlTDestination.DataBind();
            ddlTType.DataSource = ecoDB.selectDDL("Transport Type");
            ddlTType.DataTextField = "Transport Type";
            ddlTType.DataBind();
        }

        private void initEndOfLife()
        {

        }

        private void initProductDesign()
        {

        }

        private DataTable initDataTable(DataSet dsOri, List<Tuple<string, string>> listCaseNoPair)
        {
            DataTable dt = new DataTable();
            dt.Clear();

            dt.Columns.Add("Solution", typeof(string));
            dt.Columns.Add("CarbonFootprint", typeof(double));
            dt.Columns.Add("EnergyConsumption", typeof(double));
            dt.Columns.Add("AirAcidification", typeof(double));
            dt.Columns.Add("WaterEuthrophication", typeof(double));

            /*
      [Carbon_Material],[EnergyCon_Material],[AirAcid_Material],[WaterEu_Material]
      [Carbon_Manufacturing],[EnergyCon_Manufacturing],[AirAcid_Manufacturing],[WaterEu_Manufacturing]
      [Carbon_Use],[EnergyCon_Use],[AirAcid_Use],[WaterEu_Use]
      [Carbon_End Of Life],[EnergyCon_End Of Life],[AirAcid_End Of Life],[WaterEu_End Of Life]
      [Carbon_Transport],[EnergyCon_Transport],[AirAcid_Transport],[WaterEu_Transport]
      */

            //listCaseNo.Add(MMP_Info);
            //listCaseNo.Add(Transport_Info);
            //listCaseNo.Add(EndOfLife_Info);
            //listCaseNo.Add(ProductDesign_Info);

            double totalCarbonFootprint = 0.0;
            double totalEnergyConsumptiont = 0.0;
            double totalAirAcidification = 0.0;
            double totalWaterEuthrophication = 0.0;

            DataRow dr = dt.NewRow();

            if (dsOri.Tables["MMP_Info"].Rows.Count > 0)
            {
                dr["Solution"] = "Material";
                dr["CarbonFootprint"] = dsOri.Tables["MMP_Info"].Rows[0]["Carbon_Material"];
                dr["EnergyConsumption"] = dsOri.Tables["MMP_Info"].Rows[0]["EnergyCon_Material"];
                dr["AirAcidification"] = dsOri.Tables["MMP_Info"].Rows[0]["AirAcid_Material"];
                dr["WaterEuthrophication"] = dsOri.Tables["MMP_Info"].Rows[0]["WaterEu_Material"];
                dt.Rows.Add(dr);

                totalCarbonFootprint += doubleParseNullCheck(dsOri.Tables["MMP_Info"].Rows[0]["Carbon_Material"].ToString());
                totalEnergyConsumptiont += doubleParseNullCheck(dsOri.Tables["MMP_Info"].Rows[0]["EnergyCon_Material"].ToString());
                totalAirAcidification += doubleParseNullCheck(dsOri.Tables["MMP_Info"].Rows[0]["AirAcid_Material"].ToString());
                totalWaterEuthrophication += doubleParseNullCheck(dsOri.Tables["MMP_Info"].Rows[0]["WaterEu_Material"].ToString());
            }

            if (dsOri.Tables["MMP_Info"].Rows.Count > 0)
            {
                dr = dt.NewRow();
                dr["Solution"] = "Manufacturing";
                dr["CarbonFootprint"] = dsOri.Tables["MMP_Info"].Rows[0]["Carbon_Manufacturing"];
                dr["EnergyConsumption"] = dsOri.Tables["MMP_Info"].Rows[0]["EnergyCon_Manufacturing"];
                dr["AirAcidification"] = dsOri.Tables["MMP_Info"].Rows[0]["AirAcid_Manufacturing"];
                dr["WaterEuthrophication"] = dsOri.Tables["MMP_Info"].Rows[0]["WaterEu_Manufacturing"];
                dt.Rows.Add(dr);

                totalCarbonFootprint += doubleParseNullCheck(dsOri.Tables["MMP_Info"].Rows[0]["Carbon_Manufacturing"].ToString());
                totalEnergyConsumptiont += doubleParseNullCheck(dsOri.Tables["MMP_Info"].Rows[0]["EnergyCon_Manufacturing"].ToString());
                totalAirAcidification += doubleParseNullCheck(dsOri.Tables["MMP_Info"].Rows[0]["AirAcid_Manufacturing"].ToString());
                totalWaterEuthrophication += doubleParseNullCheck(dsOri.Tables["MMP_Info"].Rows[0]["WaterEu_Manufacturing"].ToString());
            }

            if (dsOri.Tables["ProductDesign_Info"].Rows.Count > 0)
            {
                dr = dt.NewRow();
                dr["Solution"] = "Use";
                dr["CarbonFootprint"] = dsOri.Tables["ProductDesign_Info"].Rows[0]["Carbon_Use"];
                dr["EnergyConsumption"] = dsOri.Tables["ProductDesign_Info"].Rows[0]["EnergyCon_Use"];
                dr["AirAcidification"] = dsOri.Tables["ProductDesign_Info"].Rows[0]["AirAcid_Use"];
                dr["WaterEuthrophication"] = dsOri.Tables["ProductDesign_Info"].Rows[0]["WaterEu_Use"];
                dt.Rows.Add(dr);

                totalCarbonFootprint += doubleParseNullCheck(dsOri.Tables["ProductDesign_Info"].Rows[0]["Carbon_Use"].ToString());
                totalEnergyConsumptiont += doubleParseNullCheck(dsOri.Tables["ProductDesign_Info"].Rows[0]["EnergyCon_Use"].ToString());
                totalAirAcidification += doubleParseNullCheck(dsOri.Tables["ProductDesign_Info"].Rows[0]["AirAcid_Use"].ToString());
                totalWaterEuthrophication += doubleParseNullCheck(dsOri.Tables["ProductDesign_Info"].Rows[0]["WaterEu_Use"].ToString());
            }

            if (dsOri.Tables["EndOfLife_Info"].Rows.Count > 0)
            {
                dr = dt.NewRow();
                dr["Solution"] = "EndOfLife";
                dr["CarbonFootprint"] = dsOri.Tables["EndOfLife_Info"].Rows[0]["Carbon_End Of Life"];
                dr["EnergyConsumption"] = dsOri.Tables["EndOfLife_Info"].Rows[0]["EnergyCon_End Of Life"];
                dr["AirAcidification"] = dsOri.Tables["EndOfLife_Info"].Rows[0]["AirAcid_End Of Life"];
                dr["WaterEuthrophication"] = dsOri.Tables["EndOfLife_Info"].Rows[0]["WaterEu_End Of Life"];
                dt.Rows.Add(dr);

                totalCarbonFootprint += doubleParseNullCheck(dsOri.Tables["EndOfLife_Info"].Rows[0]["Carbon_End Of Life"].ToString());
                totalEnergyConsumptiont += doubleParseNullCheck(dsOri.Tables["EndOfLife_Info"].Rows[0]["EnergyCon_End Of Life"].ToString());
                totalAirAcidification += doubleParseNullCheck(dsOri.Tables["EndOfLife_Info"].Rows[0]["AirAcid_End Of Life"].ToString());
                totalWaterEuthrophication += doubleParseNullCheck(dsOri.Tables["EndOfLife_Info"].Rows[0]["WaterEu_End Of Life"].ToString());
            }

            if (dsOri.Tables["Transport_Info"].Rows.Count > 0)
            {
                dr = dt.NewRow();
                dr["Solution"] = "Transport";
                dr["CarbonFootprint"] = dsOri.Tables["Transport_Info"].Rows[0]["Carbon_Transport"];
                dr["EnergyConsumption"] = dsOri.Tables["Transport_Info"].Rows[0]["EnergyCon_Transport"];
                dr["AirAcidification"] = dsOri.Tables["Transport_Info"].Rows[0]["AirAcid_Transport"];
                dr["WaterEuthrophication"] = dsOri.Tables["Transport_Info"].Rows[0]["WaterEu_Transport"];
                dt.Rows.Add(dr);

                totalCarbonFootprint += doubleParseNullCheck(dsOri.Tables["Transport_Info"].Rows[0]["Carbon_Transport"].ToString());
                totalEnergyConsumptiont += doubleParseNullCheck(dsOri.Tables["Transport_Info"].Rows[0]["EnergyCon_Transport"].ToString());
                totalAirAcidification += doubleParseNullCheck(dsOri.Tables["Transport_Info"].Rows[0]["AirAcid_Transport"].ToString());
                totalWaterEuthrophication += doubleParseNullCheck(dsOri.Tables["Transport_Info"].Rows[0]["WaterEu_Transport"].ToString());
            }

            dr = dt.NewRow();
            dr["Solution"] = "Total";
            dr["CarbonFootprint"] = totalCarbonFootprint.ToString();
            dr["EnergyConsumption"] = totalEnergyConsumptiont.ToString();
            dr["AirAcidification"] = totalAirAcidification.ToString();
            dr["WaterEuthrophication"] = totalWaterEuthrophication.ToString();
            dt.Rows.Add(dr);

            return dt;
        }

        private DataTable addAdditionalColumn(DataTable dt, List<Tuple<string, Type>> listColumns)
        {
            foreach (Tuple<string, Type> tTup in listColumns)
            {
                dt.Columns.Add(tTup.Item1, tTup.Item2);
                //dt.Columns.Add("CarbonFootprint", typeof(double));
            }

            return dt;
        }

        private DataTable addAdditionalData(DataTable dt, List<Tuple<string, double>> listColumns)
        {
            dt.Columns.Add("Solution", typeof(string));
            dt.Columns.Add("CarbonFootprint", typeof(double));
            dt.Columns.Add("EnergyConsumption", typeof(double));
            dt.Columns.Add("AirAcidification", typeof(double));
            dt.Columns.Add("WaterEuthrophication", typeof(double));

            DataRow dr = dt.NewRow();
            dr["Solution"] = "Material";
            dr["CarbonFootprint"] = 1;
            dr["EnergyConsumption"] = 1;
            dr["AirAcidification"] = 1;
            dr["WaterEuthrophication"] = 1;
            dt.Rows.Add(dr);

            return dt;
        }

        private double calculateNumericalLS(double valueEntered, double valueMax, double valueMin)
        {
            double total = 0.0;

            if ((valueEntered != 0) && (valueMax != 0))
            {
                double minValue = valueEntered > valueMin ? valueMin : valueEntered;
                double maxValue = valueEntered > valueMax ? valueEntered : valueMax;
                //total = valueEntered / valueMax;
                total = minValue / maxValue;
            }
            else
                total = 1;

            return total;
        }

        private double calculateNumericalLS(double valueEntered, double valueMax)
        {
            double total = 0.0;

            if ((valueEntered == 0) && (valueMax == 0))
                total = 1;
            else
            {
                double minValue = valueEntered > valueMax ? valueMax : valueEntered;
                double maxValue = valueEntered > valueMax ? valueEntered : valueMax;
                total = minValue / maxValue;
            }



            return total;
        }

        private double calculateGlobalS(List<Tuple<int, double>> listFormula)
        {
            double total = 0.0;
            double totalTop = 0.0;
            double totalBottom = 0.0;

            foreach (Tuple<int, double> tDouble in listFormula)
            {
                totalTop += tDouble.Item1 * tDouble.Item2;
                totalBottom += tDouble.Item1;
            }
            total = totalTop / totalBottom;

            return total;
        }

        private double doubleParseNullCheck(string value)
        {
            double valueD = 0.0;

            if (!double.TryParse(value, out valueD))
                return 0.0;

            return valueD;
        }

        private void MMP_Search()
        {
            EcoCBRDB ecoDB = new EcoCBRDB(ConfigurationManager.ConnectionStrings["conString"].ToString());
            int MMType = ecoDB.selectExist("Material Type", ddlMMType.SelectedValue) ? 1 : 0; // non numerical formula
            int MMProcess = ecoDB.selectExist("Process", ddlMMProcess.SelectedValue) ? 1 : 0;

            List<Tuple<string, string>> listCriteria = new List<Tuple<string, string>>();
            listCriteria.Add(new Tuple<string, string>("Material Type", ddlMMType.SelectedValue)); //kalau nak keluarkan semua result termasuk 0
            listCriteria.Add(new Tuple<string, string>("Process", ddlMMProcess.SelectedValue)); 

            DataTable dt = ecoDB.selectMaxMin("product Weight(gram)", listCriteria);
            double totalProductMax = calculateNumericalLS(doubleParseNullCheck(txtMMProduct.Text.Trim()), doubleParseNullCheck(dt.Rows[0]["maxvalue"].ToString()));

            List<Tuple<int, double>> listFormula = new List<Tuple<int, double>>();
            listFormula.Add(new Tuple<int, double>(int.Parse(txtMMTypeWeight.Text.Trim()), MMType));
            listFormula.Add(new Tuple<int, double>(int.Parse(txtMMProcessWeight.Text.Trim()), MMProcess));
            listFormula.Add(new Tuple<int, double>(int.Parse(txtMMProductWeight.Text.Trim()), totalProductMax));
            double totalGlobal = calculateGlobalS(listFormula);
            txtTest.Text = totalGlobal.ToString("#.####");

            //note : calculation to be performed against all row of exisint data
        }

        private void MMP_Calculate()
        {
            EcoCBRDB ecoDB = new EcoCBRDB(ConfigurationManager.ConnectionStrings["conString"].ToString());
            int MMType = ecoDB.selectExist("Material Type", ddlMMType.SelectedValue) ? 1 : 0;
            int MMProcess = ecoDB.selectExist("Process", ddlMMProcess.SelectedValue) ? 1 : 0;

            List<Tuple<string, string>> listCriteria = new List<Tuple<string, string>>();
            listCriteria.Add(new Tuple<string, string>("Material Type", ddlMMType.SelectedValue));
            listCriteria.Add(new Tuple<string, string>("Process", ddlMMProcess.SelectedValue));

            //[Case No],[Material Type],[Process],[Product Weight(gram)]

            DataTable dt = ecoDB.selectMMPConditional(listCriteria);
            List<Tuple<string, Type>> listNewColumn = new List<Tuple<string, Type>>();
            listNewColumn.Add(new Tuple<string, Type>("productNumericalLS", typeof(double)));
            listNewColumn.Add(new Tuple<string, Type>("GlobalS", typeof(double)));
            dt = addAdditionalColumn(dt, listNewColumn);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                double productNumericalLS = calculateNumericalLS(doubleParseNullCheck(txtMMProduct.Text.Trim()), doubleParseNullCheck(dt.Rows[i]["product Weight(gram)"].ToString()));

                List<Tuple<int, double>> listFormula = new List<Tuple<int, double>>();
                listFormula.Add(new Tuple<int, double>(int.Parse(txtMMTypeWeight.Text.Trim()), MMType));
                listFormula.Add(new Tuple<int, double>(int.Parse(txtMMProcessWeight.Text.Trim()), MMProcess));
                listFormula.Add(new Tuple<int, double>(int.Parse(txtMMProductWeight.Text.Trim()), productNumericalLS));
                double totalGlobal = calculateGlobalS(listFormula);
                dt.Rows[i]["productNumericalLS"] = productNumericalLS;
                dt.Rows[i]["GlobalS"] = totalGlobal;
            }

            dt = dt.AsEnumerable().OrderByDescending(x => x.Field<double>("GlobalS")).Take(10).CopyToDataTable(); // nak dapatkan result 10 yg utama

            grvMaterialManifacturing.DataSource = dt;
            grvMaterialManifacturing.DataBind();

            ViewState["MMP_Info"] = dt.Rows[0]["Case No"].ToString(); // pegang no case yg plg similar
            //txtTest.Text = totalGlobal.ToString("#.####");

            //note : calculation to be performed against all row of exisint data
        }

        private void Transport_Search()
        {
            EcoCBRDB ecoDB = new EcoCBRDB(ConfigurationManager.ConnectionStrings["conString"].ToString());
            int TOrigin = ecoDB.selectExist("Origin", ddlTOrigin.SelectedValue) ? 1 : 0;
            int TDestination = ecoDB.selectExist("Destination", ddlTDestination.SelectedValue) ? 1 : 0;
            int TType = ecoDB.selectExist("Transport Type", ddlTType.SelectedValue) ? 1 : 0;

            List<Tuple<string, string>> listCriteria = new List<Tuple<string, string>>();
            listCriteria.Add(new Tuple<string, string>("Origin", ddlTOrigin.SelectedValue));
            listCriteria.Add(new Tuple<string, string>("Destination", ddlTDestination.SelectedValue));
            listCriteria.Add(new Tuple<string, string>("Transport Type", ddlTType.SelectedValue));

            DataTable dtDistance = ecoDB.selectMaxMin("Distance(km)", listCriteria);
            double totalDistanceMax = calculateNumericalLS(doubleParseNullCheck(txtTDistance.Text.Trim()), doubleParseNullCheck(dtDistance.Rows[0]["maxvalue"].ToString()));

            DataTable dtProduct = ecoDB.selectMaxMin("product Weight(gram)", listCriteria);
            double totalProductMax = calculateNumericalLS(doubleParseNullCheck(txtMMProduct.Text.Trim()), doubleParseNullCheck(dtProduct.Rows[0]["maxvalue"].ToString()));
            //double totalProductMax = calculateNumericalLS(doubleParseNullCheck(txtMMProduct.Text.Trim()), doubleParseNullCheck("233.15"));

            List<Tuple<int, double>> listFormula = new List<Tuple<int, double>>();
            listFormula.Add(new Tuple<int, double>(int.Parse(txtTOriginWeight.Text.Trim()), TOrigin));
            listFormula.Add(new Tuple<int, double>(int.Parse(txtTDestinationWeight.Text.Trim()), TDestination));
            listFormula.Add(new Tuple<int, double>(int.Parse(txtTTypeWeight.Text.Trim()), TType));
            listFormula.Add(new Tuple<int, double>(int.Parse(txtTDistanceWeight.Text.Trim()), totalDistanceMax));
            listFormula.Add(new Tuple<int, double>(int.Parse(txtMMProductWeight.Text.Trim()), totalProductMax));
            double totalGlobal = calculateGlobalS(listFormula);
            txtTest.Text = totalGlobal.ToString("#.####");
        }

        private void Transport_Calculate()
        {
            EcoCBRDB ecoDB = new EcoCBRDB(ConfigurationManager.ConnectionStrings["conString"].ToString());
            int TOrigin = ecoDB.selectExist("Origin", ddlTOrigin.SelectedValue) ? 1 : 0;
            int TDestination = ecoDB.selectExist("Destination", ddlTDestination.SelectedValue) ? 1 : 0;
            int TType = ecoDB.selectExist("Transport Type", ddlTType.SelectedValue) ? 1 : 0;

            List<Tuple<string, string>> listCriteria = new List<Tuple<string, string>>();
            listCriteria.Add(new Tuple<string, string>("Origin", ddlTOrigin.SelectedValue));
            listCriteria.Add(new Tuple<string, string>("Destination", ddlTDestination.SelectedValue));
            listCriteria.Add(new Tuple<string, string>("Transport Type", ddlTType.SelectedValue));

            DataTable dt = ecoDB.selectTransportConditional(listCriteria);
            List<Tuple<string, Type>> listNewColumn = new List<Tuple<string, Type>>();
            listNewColumn.Add(new Tuple<string, Type>("productDistanceLS", typeof(double)));
            listNewColumn.Add(new Tuple<string, Type>("productNumericalLS", typeof(double)));
            listNewColumn.Add(new Tuple<string, Type>("GlobalS", typeof(double)));
            dt = addAdditionalColumn(dt, listNewColumn);


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //DataTable dtDistance = ecoDB.selectMaxMin("Distance(km)", listCriteria);
                double productDistanceLS = calculateNumericalLS(doubleParseNullCheck(txtTDistance.Text.Trim()), doubleParseNullCheck(dt.Rows[i]["Distance(km)"].ToString()));

                //DataTable dtProduct = ecoDB.selectMaxMin("product Weight(gram)", listCriteria);
                double productNumericalLS = calculateNumericalLS(doubleParseNullCheck(txtMMProduct.Text.Trim()), doubleParseNullCheck(dt.Rows[i]["product Weight(gram)"].ToString()));
                //double totalProductMax = calculateNumericalLS(doubleParseNullCheck(txtMMProduct.Text.Trim()), doubleParseNullCheck("233.15"));

                List<Tuple<int, double>> listFormula = new List<Tuple<int, double>>();
                listFormula.Add(new Tuple<int, double>(int.Parse(txtTOriginWeight.Text.Trim()), TOrigin));
                listFormula.Add(new Tuple<int, double>(int.Parse(txtTDestinationWeight.Text.Trim()), TDestination));
                listFormula.Add(new Tuple<int, double>(int.Parse(txtTTypeWeight.Text.Trim()), TType));
                listFormula.Add(new Tuple<int, double>(int.Parse(txtTDistanceWeight.Text.Trim()), productDistanceLS));
                listFormula.Add(new Tuple<int, double>(int.Parse(txtMMProductWeight.Text.Trim()), productNumericalLS));
                double totalGlobal = calculateGlobalS(listFormula);
                dt.Rows[i]["productDistanceLS"] = productDistanceLS;
                dt.Rows[i]["productNumericalLS"] = productNumericalLS;
                dt.Rows[i]["GlobalS"] = totalGlobal;
            }

            dt = dt.AsEnumerable().OrderByDescending(x => x.Field<double>("GlobalS")).Take(10).CopyToDataTable();

            grvTransportation.DataSource = dt;
            grvTransportation.DataBind();

            ViewState["Transport_Info"] = dt.Rows[0]["Case No"].ToString();
            //txtTest.Text = totalGlobal.ToString("#.####");
        }

        private void EndOfLife_Search()
        {
            EcoCBRDB ecoDB = new EcoCBRDB(ConfigurationManager.ConnectionStrings["conString"].ToString());

            int MMType = ecoDB.selectExist("Material Type", ddlMMType.SelectedValue) ? 1 : 0;

            List<Tuple<string, string>> listCriteria = new List<Tuple<string, string>>();
            listCriteria.Add(new Tuple<string, string>("Material Type", ddlMMType.SelectedValue));

            DataTable dtRecycle = ecoDB.selectMaxMin("Recycled(%)", listCriteria);
            double totalRecycleMax = calculateNumericalLS(doubleParseNullCheck(txtEOLRecycle.Text.Trim()), doubleParseNullCheck(dtRecycle.Rows[0]["maxvalue"].ToString()));

            DataTable dtInc = ecoDB.selectMaxMin("Incinerated (%)", listCriteria);
            double totalIncineratedMax = calculateNumericalLS(doubleParseNullCheck(txtEOLIncinerated.Text.Trim()), doubleParseNullCheck(dtInc.Rows[0]["maxvalue"].ToString()));

            DataTable dtLandfill = ecoDB.selectMaxMin("Landfill (%)", listCriteria);
            double totalLandfillMax = calculateNumericalLS(doubleParseNullCheck(txtEOLLandfill.Text.Trim()), doubleParseNullCheck(dtLandfill.Rows[0]["maxvalue"].ToString()));
            //double totalLandfillMax = calculateNumericalLS(doubleParseNullCheck(txtEOLLandfill.Text.Trim()), doubleParseNullCheck("0"));

            DataTable dtProduct = ecoDB.selectMaxMin("product Weight(gram)", listCriteria);
            double totalProductMax = calculateNumericalLS(doubleParseNullCheck(txtMMProduct.Text.Trim()), doubleParseNullCheck(dtProduct.Rows[0]["maxvalue"].ToString()));

            List<Tuple<int, double>> listFormula = new List<Tuple<int, double>>();
            listFormula.Add(new Tuple<int, double>(int.Parse(txtMMTypeWeight.Text.Trim()), MMType));
            listFormula.Add(new Tuple<int, double>(int.Parse(txtEOLRecycleWeight.Text.Trim()), totalRecycleMax));
            listFormula.Add(new Tuple<int, double>(int.Parse(txtEOLIncineratedWeight.Text.Trim()), totalIncineratedMax));
            listFormula.Add(new Tuple<int, double>(int.Parse(txtEOLLandfillWeight.Text.Trim()), totalLandfillMax));
            listFormula.Add(new Tuple<int, double>(int.Parse(txtMMProductWeight.Text.Trim()), totalProductMax));
            double totalGlobal = calculateGlobalS(listFormula);
            txtTest.Text = totalGlobal.ToString("#.####");
        }

        private void EndOfLife_Calculate()
        {
            EcoCBRDB ecoDB = new EcoCBRDB(ConfigurationManager.ConnectionStrings["conString"].ToString());

            int MMType = ecoDB.selectExist("Material Type", ddlMMType.SelectedValue) ? 1 : 0;

            List<Tuple<string, string>> listCriteria = new List<Tuple<string, string>>();
            listCriteria.Add(new Tuple<string, string>("Material Type", ddlMMType.SelectedValue));

            DataTable dt = ecoDB.selectEOLConditional(listCriteria);
            List<Tuple<string, Type>> listNewColumn = new List<Tuple<string, Type>>();
            listNewColumn.Add(new Tuple<string, Type>("RecycleNumericalLS", typeof(double)));
            listNewColumn.Add(new Tuple<string, Type>("IncineratedNumericalLS", typeof(double)));
            listNewColumn.Add(new Tuple<string, Type>("LandfillNumericalLS", typeof(double)));
            listNewColumn.Add(new Tuple<string, Type>("productNumericalLS", typeof(double)));
            listNewColumn.Add(new Tuple<string, Type>("GlobalS", typeof(double)));
            dt = addAdditionalColumn(dt, listNewColumn);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //DataTable dtRecycle = ecoDB.selectMaxMin("Recycled(%)", listCriteria);
                double RecycleNumericalLS = calculateNumericalLS(doubleParseNullCheck(txtEOLRecycle.Text.Trim()), doubleParseNullCheck(dt.Rows[i]["Recycled(%)"].ToString()));

                //DataTable dtInc = ecoDB.selectMaxMin("Incinerated (%)", listCriteria);
                double IncineratedNumericalLS = calculateNumericalLS(doubleParseNullCheck(txtEOLIncinerated.Text.Trim()), doubleParseNullCheck(dt.Rows[i]["Incinerated (%)"].ToString()));

                //DataTable dtLandfill = ecoDB.selectMaxMin("Landfill (%)", listCriteria);
                double LandfillNumericalLS = calculateNumericalLS(doubleParseNullCheck(txtEOLLandfill.Text.Trim()), doubleParseNullCheck(dt.Rows[i]["Landfill (%)"].ToString()));
                //double totalLandfillMax = calculateNumericalLS(doubleParseNullCheck(txtEOLLandfill.Text.Trim()), doubleParseNullCheck("0"));

                //DataTable dtProduct = ecoDB.selectMaxMin("product Weight(gram)", listCriteria);
                double productNumericalLS = calculateNumericalLS(doubleParseNullCheck(txtMMProduct.Text.Trim()), doubleParseNullCheck(dt.Rows[i]["product Weight(gram)"].ToString()));

                List<Tuple<int, double>> listFormula = new List<Tuple<int, double>>();
                listFormula.Add(new Tuple<int, double>(int.Parse(txtMMTypeWeight.Text.Trim()), MMType));
                listFormula.Add(new Tuple<int, double>(int.Parse(txtEOLRecycleWeight.Text.Trim()), RecycleNumericalLS));
                listFormula.Add(new Tuple<int, double>(int.Parse(txtEOLIncineratedWeight.Text.Trim()), IncineratedNumericalLS));
                listFormula.Add(new Tuple<int, double>(int.Parse(txtEOLLandfillWeight.Text.Trim()), LandfillNumericalLS));
                listFormula.Add(new Tuple<int, double>(int.Parse(txtMMProductWeight.Text.Trim()), productNumericalLS));
                double totalGlobal = calculateGlobalS(listFormula);

                dt.Rows[i]["RecycleNumericalLS"] = RecycleNumericalLS;
                dt.Rows[i]["IncineratedNumericalLS"] = IncineratedNumericalLS;
                dt.Rows[i]["LandfillNumericalLS"] = LandfillNumericalLS;
                dt.Rows[i]["productNumericalLS"] = productNumericalLS;
                dt.Rows[i]["GlobalS"] = totalGlobal;
            }

            dt = dt.AsEnumerable().OrderByDescending(x => x.Field<double>("GlobalS")).Take(10).CopyToDataTable();

            grvEndOfLife.DataSource = dt;
            grvEndOfLife.DataBind();

            ViewState["EndOfLife_Info"] = dt.Rows[0]["Case No"].ToString();
            //txtTest.Text = totalGlobal.ToString("#.####");
        }

        private void ProductDesign_Search()
        {
            EcoCBRDB ecoDB = new EcoCBRDB(ConfigurationManager.ConnectionStrings["conString"].ToString());

            int MMType = ecoDB.selectExist("Material Type", ddlMMType.SelectedValue) ? 1 : 0;

            List<Tuple<string, string>> listCriteria = new List<Tuple<string, string>>();
            listCriteria.Add(new Tuple<string, string>("Material Type", ddlMMType.SelectedValue));

            DataTable dtThin = ecoDB.selectMaxMin("Thin Region(mm)", listCriteria);
            double totalThinRegionMax = calculateNumericalLS(doubleParseNullCheck(txtPDThickThin.Text.Trim()), doubleParseNullCheck(dtThin.Rows[0]["maxvalue"].ToString()));

            DataTable dtThick = ecoDB.selectMaxMin("Thick Region(mm)", listCriteria);
            double totalThickRegionMax = calculateNumericalLS(doubleParseNullCheck(txtPDThickThick.Text.Trim()), doubleParseNullCheck(dtThick.Rows[0]["maxvalue"].ToString()));

            DataTable dtHeight = ecoDB.selectMaxMin("Height(mm)", listCriteria);
            double totalHeightMax = calculateNumericalLS(doubleParseNullCheck(txtPDHeight.Text.Trim()), doubleParseNullCheck(dtHeight.Rows[0]["maxvalue"].ToString()));

            DataTable dtSurfaceArea = ecoDB.selectMaxMin("Surface Area(mm2)", listCriteria);
            double totalSurfaceAreaMax = calculateNumericalLS(doubleParseNullCheck(txtPDSurface.Text.Trim()), doubleParseNullCheck(dtSurfaceArea.Rows[0]["maxvalue"].ToString()));

            DataTable dtVolume = ecoDB.selectMaxMin("Volume(mm3)", listCriteria);
            double totalVolumeMax = calculateNumericalLS(doubleParseNullCheck(txtPDVolume.Text.Trim()), doubleParseNullCheck(dtVolume.Rows[0]["maxvalue"].ToString()));

            DataTable dtPerimeter = ecoDB.selectMaxMin("Perimeter(mm)", listCriteria);
            double totalPerimeterMax = calculateNumericalLS(doubleParseNullCheck(txtPDPerimeter.Text.Trim()), doubleParseNullCheck(dtPerimeter.Rows[0]["maxvalue"].ToString()));
            //double totalPerimeterMax = calculateNumericalLS(doubleParseNullCheck(txtPDPerimeter.Text.Trim()), doubleParseNullCheck("682.48"));

            DataTable dtProduct = ecoDB.selectMaxMin("product Weight(gram)", listCriteria);
            double totalProductMax = calculateNumericalLS(doubleParseNullCheck(txtMMProduct.Text.Trim()), doubleParseNullCheck(dtProduct.Rows[0]["maxvalue"].ToString()));

            List<Tuple<int, double>> listFormula = new List<Tuple<int, double>>();
            listFormula.Add(new Tuple<int, double>(int.Parse(txtMMTypeWeight.Text.Trim()), MMType));
            listFormula.Add(new Tuple<int, double>(int.Parse(txtPDThickThinWeight.Text.Trim()), totalThinRegionMax));
            listFormula.Add(new Tuple<int, double>(int.Parse(txtPDThickThickWeight.Text.Trim()), totalThickRegionMax));
            listFormula.Add(new Tuple<int, double>(int.Parse(txtPDHeightWeight.Text.Trim()), totalHeightMax));
            listFormula.Add(new Tuple<int, double>(int.Parse(txtPDSurfaceWeight.Text.Trim()), totalSurfaceAreaMax));
            listFormula.Add(new Tuple<int, double>(int.Parse(txtPDVolumeWeight.Text.Trim()), totalVolumeMax));
            listFormula.Add(new Tuple<int, double>(int.Parse(txtPDPerimeterWeight.Text.Trim()), totalPerimeterMax));
            listFormula.Add(new Tuple<int, double>(int.Parse(txtMMProductWeight.Text.Trim()), totalProductMax));
            double totalGlobal = calculateGlobalS(listFormula);
            txtTest.Text = totalGlobal.ToString("#.####");
        }

        private void ProductDesign_Calculate()
        {
            EcoCBRDB ecoDB = new EcoCBRDB(ConfigurationManager.ConnectionStrings["conString"].ToString());

            int MMType = ecoDB.selectExist("Material Type", ddlMMType.SelectedValue) ? 1 : 0;

            List<Tuple<string, string>> listCriteria = new List<Tuple<string, string>>();
            listCriteria.Add(new Tuple<string, string>("Material Type", ddlMMType.SelectedValue));

            DataTable dt = ecoDB.selectProductDesignConditional(listCriteria);
            List<Tuple<string, Type>> listNewColumn = new List<Tuple<string, Type>>();
            listNewColumn.Add(new Tuple<string, Type>("ThinRegionNumericalLS", typeof(double)));
            listNewColumn.Add(new Tuple<string, Type>("ThickRegionNumericalLS", typeof(double)));
            listNewColumn.Add(new Tuple<string, Type>("HeightNumericalLS", typeof(double)));
            listNewColumn.Add(new Tuple<string, Type>("SurfaceAreaNumericalLS", typeof(double)));
            listNewColumn.Add(new Tuple<string, Type>("VolumeNumericalLS", typeof(double)));
            listNewColumn.Add(new Tuple<string, Type>("PerimeterNumericalLS", typeof(double)));
            listNewColumn.Add(new Tuple<string, Type>("productNumericalLS", typeof(double)));
            listNewColumn.Add(new Tuple<string, Type>("GlobalS", typeof(double)));
            dt = addAdditionalColumn(dt, listNewColumn);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //DataTable dtThin = ecoDB.selectMaxMin("Thin Region(mm)", listCriteria);
                double ThinRegionNumericalLS = calculateNumericalLS(doubleParseNullCheck(txtPDThickThin.Text.Trim()), doubleParseNullCheck(dt.Rows[i]["Thin Region(mm)"].ToString()));

                //DataTable dtThick = ecoDB.selectMaxMin("Thick Region(mm)", listCriteria);
                double ThickRegionNumericalLS = calculateNumericalLS(doubleParseNullCheck(txtPDThickThick.Text.Trim()), doubleParseNullCheck(dt.Rows[i]["Thick Region(mm)"].ToString()));

                //DataTable dtHeight = ecoDB.selectMaxMin("Height(mm)", listCriteria);
                double HeightNumericalLS = calculateNumericalLS(doubleParseNullCheck(txtPDHeight.Text.Trim()), doubleParseNullCheck(dt.Rows[i]["Height(mm)"].ToString()));

                //DataTable dtSurfaceArea = ecoDB.selectMaxMin("Surface Area(mm2)", listCriteria);
                double SurfaceAreaNumericalLS = calculateNumericalLS(doubleParseNullCheck(txtPDSurface.Text.Trim()), doubleParseNullCheck(dt.Rows[i]["Surface Area(mm2)"].ToString()));

                //DataTable dtVolume = ecoDB.selectMaxMin("Volume(mm3)", listCriteria);
                double VolumeNumericalLS = calculateNumericalLS(doubleParseNullCheck(txtPDVolume.Text.Trim()), doubleParseNullCheck(dt.Rows[i]["Volume(mm3)"].ToString()));

                //DataTable dtPerimeter = ecoDB.selectMaxMin("Perimeter(mm)", listCriteria);
                double PerimeterNumericalLS = calculateNumericalLS(doubleParseNullCheck(txtPDPerimeter.Text.Trim()), doubleParseNullCheck(dt.Rows[i]["Perimeter(mm)"].ToString()));
                //double totalPerimeterMax = calculateNumericalLS(doubleParseNullCheck(txtPDPerimeter.Text.Trim()), doubleParseNullCheck("682.48"));

                //DataTable dtProduct = ecoDB.selectMaxMin("product Weight(gram)", listCriteria);
                double productNumericalLS = calculateNumericalLS(doubleParseNullCheck(txtMMProduct.Text.Trim()), doubleParseNullCheck(dt.Rows[i]["product Weight(gram)"].ToString()));

                List<Tuple<int, double>> listFormula = new List<Tuple<int, double>>();
                listFormula.Add(new Tuple<int, double>(int.Parse(txtMMTypeWeight.Text.Trim()), MMType));
                listFormula.Add(new Tuple<int, double>(int.Parse(txtPDThickThinWeight.Text.Trim()), ThinRegionNumericalLS));
                listFormula.Add(new Tuple<int, double>(int.Parse(txtPDThickThickWeight.Text.Trim()), ThickRegionNumericalLS));
                listFormula.Add(new Tuple<int, double>(int.Parse(txtPDHeightWeight.Text.Trim()), HeightNumericalLS));
                listFormula.Add(new Tuple<int, double>(int.Parse(txtPDSurfaceWeight.Text.Trim()), SurfaceAreaNumericalLS));
                listFormula.Add(new Tuple<int, double>(int.Parse(txtPDVolumeWeight.Text.Trim()), VolumeNumericalLS));
                listFormula.Add(new Tuple<int, double>(int.Parse(txtPDPerimeterWeight.Text.Trim()), PerimeterNumericalLS));
                listFormula.Add(new Tuple<int, double>(int.Parse(txtMMProductWeight.Text.Trim()), productNumericalLS));
                double totalGlobal = calculateGlobalS(listFormula);

                dt.Rows[i]["ThinRegionNumericalLS"] = ThinRegionNumericalLS;
                dt.Rows[i]["ThickRegionNumericalLS"] = ThickRegionNumericalLS;
                dt.Rows[i]["HeightNumericalLS"] = HeightNumericalLS;
                dt.Rows[i]["SurfaceAreaNumericalLS"] = SurfaceAreaNumericalLS;
                dt.Rows[i]["VolumeNumericalLS"] = VolumeNumericalLS;
                dt.Rows[i]["PerimeterNumericalLS"] = PerimeterNumericalLS;
                dt.Rows[i]["productNumericalLS"] = productNumericalLS;
                dt.Rows[i]["GlobalS"] = totalGlobal;
            }

            dt = dt.AsEnumerable().OrderByDescending(x => x.Field<double>("GlobalS")).Take(10).CopyToDataTable();

            grvProductDesign.DataSource = dt;
            grvProductDesign.DataBind();

            ViewState["ProductDesign_Info"] = dt.Rows[0]["Case No"].ToString();

            //txtTest.Text = totalGlobal.ToString("#.####");
        }

        protected void EnvironmentalImpact_Calculate()
        {
            var MMP_Info = ViewState["MMP_Info"] != null ? ViewState["MMP_Info"].ToString() : "";
            var Transport_Info = ViewState["Transport_Info"] != null ? ViewState["Transport_Info"].ToString() : "";
            var EndOfLife_Info = ViewState["EndOfLife_Info"] != null ? ViewState["EndOfLife_Info"].ToString() : "";
            var ProductDesign_Info = ViewState["ProductDesign_Info"] != null ? ViewState["ProductDesign_Info"].ToString() : "";

            List<string> listCaseNo = new List<string>();
            listCaseNo.Add(MMP_Info);
            listCaseNo.Add(Transport_Info);
            listCaseNo.Add(EndOfLife_Info);
            listCaseNo.Add(ProductDesign_Info);

            List<Tuple<string, string>> listCaseNoPair = new List<Tuple<string, string>>();
            listCaseNoPair.Add(new Tuple<string, string>("MMP_Info", MMP_Info));
            listCaseNoPair.Add(new Tuple<string, string>("Transport_Info", Transport_Info));
            listCaseNoPair.Add(new Tuple<string, string>("EndOfLife_Info", EndOfLife_Info));
            listCaseNoPair.Add(new Tuple<string, string>("ProductDesign_Info", ProductDesign_Info));

            EcoCBRDB ecoDB = new EcoCBRDB(ConfigurationManager.ConnectionStrings["conString"].ToString());

            //DataTable dt = this,ecoDB.selectAll(listCriteria);
            DataTable dt = this.initDataTable(ecoDB.selectAllPair(listCaseNoPair), listCaseNoPair);

            grvImpact.DataSource = dt;
            grvImpact.DataBind();

            grvImpactTwo.DataSource = dt;
            grvImpactTwo.DataBind();
            grvImpactTwo.Visible = false;
        }

        protected clsEcoCBR getValueFromForm()
        {
            clsEcoCBR ecoBR = new clsEcoCBR();
            ecoBR.Case_No = "";
            ecoBR.Origin = ddlTOrigin.SelectedValue;
            ecoBR.Destination = ddlTDestination.SelectedValue;
            ecoBR.Transport = ddlTType.SelectedValue;
            ecoBR.Distance = this.doubleParseNullCheck(txtTDistance.Text);
            ecoBR.Material = ddlMMType.SelectedValue;
            ecoBR.Process = ddlMMProcess.SelectedValue;
            ecoBR.Product_Weight = this.doubleParseNullCheck(txtMMProduct.Text);
            ecoBR.Recycled = this.doubleParseNullCheck(txtEOLRecycle.Text); ;
            ecoBR.Incinerated = this.doubleParseNullCheck(txtEOLIncinerated.Text);
            ecoBR.Landfill = this.doubleParseNullCheck(txtEOLLandfill.Text);
            ecoBR.Thin_Region = this.doubleParseNullCheck(txtPDThickThin.Text);
            ecoBR.Thick_Region = this.doubleParseNullCheck(txtPDThickThick.Text);
            ecoBR.Height = this.doubleParseNullCheck(txtPDHeight.Text);
            ecoBR.Surface_Area = this.doubleParseNullCheck(txtPDSurface.Text);
            ecoBR.Perimeter = this.doubleParseNullCheck(txtPDPerimeter.Text);
            ecoBR.Volume = this.doubleParseNullCheck(txtPDVolume.Text);
            //string test = ((TextBox)grvImpactTwo.Rows[0].Cells[1]..FindControls("txtCarbonFootprint")).Text;
            //string test2 = (TextBox)grvImpactTwo.Rows[0].Cells[2.FindControls("txtEnergyConsumption")).Text;

            for (int i = 0; i < grvImpactTwo.Rows.Count; i++)
            {
                TextBox txtCarbonFootprint = (TextBox)grvImpactTwo.Rows[i].FindControl("txtCarbonFootprint");
                TextBox txtEnergyConsumption = (TextBox)grvImpactTwo.Rows[i].FindControl("txtEnergyConsumption");
                TextBox txtAirAcidification = (TextBox)grvImpactTwo.Rows[i].FindControl("txtAirAcidification");
                TextBox txtWaterEuthrophication = (TextBox)grvImpactTwo.Rows[i].FindControl("txtWaterEuthrophication");

                if (i == 0)//material
                {
                    ecoBR.Carbon_Material = this.doubleParseNullCheck(txtCarbonFootprint.Text);
                    ecoBR.EnergyCon_Material = this.doubleParseNullCheck(txtEnergyConsumption.Text);
                    ecoBR.AirAcid_Material = this.doubleParseNullCheck(txtAirAcidification.Text);
                    ecoBR.WaterEu_Material = this.doubleParseNullCheck(txtWaterEuthrophication.Text);
                }
                else if (i == 1)//manufacturing
                {
                    ecoBR.Carbon_Manufacturing = this.doubleParseNullCheck(txtCarbonFootprint.Text);
                    ecoBR.EnergyCon_Manufacturing = this.doubleParseNullCheck(txtEnergyConsumption.Text);
                    ecoBR.AirAcid_Manufacturing = this.doubleParseNullCheck(txtAirAcidification.Text);
                    ecoBR.WaterEu_Manufacturing = this.doubleParseNullCheck(txtWaterEuthrophication.Text);
                }
                else if (i == 2)//Use
                {
                    ecoBR.Carbon_Use = this.doubleParseNullCheck(txtCarbonFootprint.Text);
                    ecoBR.EnergyCon_Use = this.doubleParseNullCheck(txtEnergyConsumption.Text);
                    ecoBR.AirAcid_Use = this.doubleParseNullCheck(txtAirAcidification.Text);
                    ecoBR.WaterEu_Use = this.doubleParseNullCheck(txtWaterEuthrophication.Text);
                }
                else if (i == 3)//End OF life
                {
                    ecoBR.Carbon_EndOfLife = this.doubleParseNullCheck(txtCarbonFootprint.Text);
                    ecoBR.EnergyCon_EndOfLife = this.doubleParseNullCheck(txtEnergyConsumption.Text);
                    ecoBR.AirAcid_EndOfLife = this.doubleParseNullCheck(txtAirAcidification.Text);
                    ecoBR.WaterEu_EndOfLife = this.doubleParseNullCheck(txtWaterEuthrophication.Text);
                }
                else if (i == 4)//Transport
                {
                    ecoBR.Carbon_Transport = this.doubleParseNullCheck(txtCarbonFootprint.Text);
                    ecoBR.EnergyCon_Transport = this.doubleParseNullCheck(txtEnergyConsumption.Text);
                    ecoBR.AirAcid_Transport = this.doubleParseNullCheck(txtAirAcidification.Text);
                    ecoBR.WaterEu_Transport = this.doubleParseNullCheck(txtWaterEuthrophication.Text);
                }
                else if (i == 5)//Total
                {
                    ecoBR.Total_Carbon = this.doubleParseNullCheck(txtCarbonFootprint.Text);
                    ecoBR.Total_EnergyCon = this.doubleParseNullCheck(txtEnergyConsumption.Text);
                    ecoBR.Total_AirAcid = this.doubleParseNullCheck(txtAirAcidification.Text);
                    ecoBR.Total_WaterEu = this.doubleParseNullCheck(txtWaterEuthrophication.Text);
                }
            }

            return ecoBR;
        }

        protected int AddToLibrary()
        {
            int inserted = 0;

            clsEcoCBR ecoBR = this.getValueFromForm();
            EcoCBRDB ecoDB = new EcoCBRDB(ConfigurationManager.ConnectionStrings["conString"].ToString());
            var newRow = ecoDB.selectMaxRow() + 1;
            ecoBR.Case_No = "C" + newRow.ToString();

            inserted = ecoDB.insertEcoBR(ecoBR);

            return inserted;
        }

        protected void Reset()
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnMMSearch_Click(object sender, EventArgs e)
        {
            //MMP_Search();
            //grvMaterialManifacturing.DataSource = initDataTable();
            //grvMaterialManifacturing.DataBind();
            MMP_Calculate();
        }

        protected void txtTSearch_Click(object sender, EventArgs e)
        {
            //Transport_Search();
            Transport_Calculate();
        }

        protected void btnEOLSearch_Click(object sender, EventArgs e)
        {
            EndOfLife_Calculate();
        }

        protected void btnPDSearch_Click(object sender, EventArgs e)
        {
            ProductDesign_Calculate();
        }

        protected void btnEnvironmentalImpact_Click(object sender, EventArgs e)
        {
            EnvironmentalImpact_Calculate();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        protected void btnReviseSolution_Click(object sender, EventArgs e)
        {
            grvImpact.Visible = false;
            grvImpactTwo.Visible = true;
        }

        protected void btnAddToLibrary_Click(object sender, EventArgs e)
        {
            int inserted = AddToLibrary();

            if (inserted == 1)
            {
                lblResult.Text = "Add To Library Successful!";
                lblResult.Visible = true;
            }
            else
            {
                lblResult.Text = "Add To Library Failed!";
                lblResult.Visible = true;
            }
        }
    }
}
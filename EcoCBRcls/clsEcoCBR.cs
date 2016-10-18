using System;
using System.Data;
using System.Configuration;
using System.Web;

/// <summary>
/// Summary description for clsHotel
/// </summary>
namespace EcoCBRcls
{
    public class clsEcoCBR
    {
        public clsEcoCBR()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public string Case_No = "";
        public string Origin = "";
        public string Destination = "";
        public string Transport = "";
        public double Distance = 0.0;
        public string Material = "";
        public string Process = "";
        public double Product_Weight = 0.0;
        public double Recycled = 0.0;
        public double Incinerated = 0.0;
        public double Landfill = 0.0;
        public double Thin_Region = 0.0;
        public double Thick_Region = 0.0;
        public double Height = 0.0;
        public double Surface_Area = 0.0;
        public double Perimeter = 0.0;
        public double Volume = 0.0;
        public double Carbon_Material = 0.0;
        public double Carbon_Manufacturing = 0.0;
        public double Carbon_Use = 0.0;
        public double Carbon_EndOfLife = 0.0;
        public double Carbon_Transport = 0.0;
        public double EnergyCon_Material = 0.0;
        public double EnergyCon_Manufacturing = 0.0;
        public double EnergyCon_Use = 0.0;
        public double EnergyCon_EndOfLife = 0.0;
        public double EnergyCon_Transport = 0.0;
        public double AirAcid_Material = 0.0;
        public double AirAcid_Manufacturing = 0.0;
        public double AirAcid_Use = 0.0;
        public double AirAcid_EndOfLife = 0.0;
        public double AirAcid_Transport = 0.0;
        public double WaterEu_Material = 0.0;
        public double WaterEu_Manufacturing = 0.0;
        public double WaterEu_Use = 0.0;
        public double WaterEu_EndOfLife = 0.0;
        public double WaterEu_Transport = 0.0;
        public double Total_Carbon = 0.0;
        public double Total_EnergyCon = 0.0;
        public double Total_AirAcid = 0.0;
        public double Total_WaterEu = 0.0;        
    }
}

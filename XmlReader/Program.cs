using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;

namespace XmlReader
{
    /// <summary>
    /// Static Class for Global Definitions
    /// </summary>
    public static class Globals
    {
        // XML file path
        public const string XML_PATH = @"..\..\resource\config.xml";

        // THRESHOLDS
        public static IDictionary<string, double> THRESHOLDS = new Dictionary<string, double>();
    }

    /// <summary>
    /// Program Class
    /// </summary>
    class Program
    {
        /// <summary>
        /// Read Threshold values from XML file
        /// </summary>
        static bool ReadThresholds()
        {
            // create document instance using XML file path
            System.Xml.XmlDocument xmlDoc = new XmlDocument(); // Create an XML document object

            FileInfo FileXmlPath = new FileInfo(Globals.XML_PATH);

            if (FileXmlPath.Exists)
            {
                xmlDoc.Load(Globals.XML_PATH); // Load the XML document from the specified file
            }
            else
            {
                Console.WriteLine("ERROR: Failed to find config.xml file in the path.");
                return false;
            }   

            // Get elements
            System.Xml.XmlNodeList streamLeft = xmlDoc.GetElementsByTagName("Left");
            System.Xml.XmlNodeList streamRight = xmlDoc.GetElementsByTagName("Right");

            if (streamLeft.Count != 1)
            {
                Console.WriteLine("No <Left> tage exists or more than 1 <Left> exists.");
                return false;
            }

            if (streamRight.Count != 1)
            {
                Console.WriteLine("No <Right> tage exists or more than 1 <Right> exists.");
                return false;
            }

            // Get tool nodes
            System.Xml.XmlNode nLeft_analyze_1 = streamLeft[0]["Analyze-1"];
            System.Xml.XmlNode nLeft_analyze_2 = streamLeft[0]["Analyze-2"];
            System.Xml.XmlNode nLeft_analyze_3 = streamLeft[0]["Analyze-3"];
            System.Xml.XmlNode nLeft_analyze_4 = streamLeft[0]["Analyze-4"];
            System.Xml.XmlNode nRight_analyze_1 = streamRight[0]["Analyze-1"];
            System.Xml.XmlNode nRight_analyze_2 = streamRight[0]["Analyze-2"];
            System.Xml.XmlNode nRight_analyze_3 = streamRight[0]["Analyze-3"];
            System.Xml.XmlNode nRight_analyze_4 = streamRight[0]["Analyze-4"];

            //////////////////////////////////////////////////////////////////////////////////////////////////////////
            // STREAM-LEFT
            //////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Get thresholds for Left/Analyze-1
            Globals.THRESHOLDS.Add("LEFT_ANALYZE-1_T1", Convert.ToDouble(nLeft_analyze_1["T1"].InnerText));
            Globals.THRESHOLDS.Add("LEFT_ANALYZE-1_T2", Convert.ToDouble(nLeft_analyze_1["T2"].InnerText));
            Globals.THRESHOLDS.Add("LEFT_ANALYZE-1_TA", Convert.ToDouble(nLeft_analyze_1["TA"].InnerText));

            // Get thresholds for Left/Analyze-2
            Globals.THRESHOLDS.Add("LEFT_ANALYZE-2_T1", Convert.ToDouble(nLeft_analyze_2["T1"].InnerText));
            Globals.THRESHOLDS.Add("LEFT_ANALYZE-2_T2", Convert.ToDouble(nLeft_analyze_2["T2"].InnerText));
            Globals.THRESHOLDS.Add("LEFT_ANALYZE-2_TA", Convert.ToDouble(nLeft_analyze_2["TA"].InnerText));

            // Get thresholds for Left/Analyze-4
            Globals.THRESHOLDS.Add("LEFT_ANALYZE-3_T1", Convert.ToDouble(nLeft_analyze_3["T1"].InnerText));
            Globals.THRESHOLDS.Add("LEFT_ANALYZE-3_T2", Convert.ToDouble(nLeft_analyze_3["T2"].InnerText));
            Globals.THRESHOLDS.Add("LEFT_ANALYZE-3_TA", Convert.ToDouble(nLeft_analyze_3["TA"].InnerText));

            // Get thresholds for Left/Analyze-4
            Globals.THRESHOLDS.Add("LEFT_ANALYZE-4_T1", Convert.ToDouble(nLeft_analyze_4["T1"].InnerText));
            Globals.THRESHOLDS.Add("LEFT_ANALYZE-4_T2", Convert.ToDouble(nLeft_analyze_4["T2"].InnerText));
            Globals.THRESHOLDS.Add("LEFT_ANALYZE-4_TA", Convert.ToDouble(nLeft_analyze_4["TA"].InnerText));

            //////////////////////////////////////////////////////////////////////////////////////////////////////////
            // STREAM-RIGHT
            //////////////////////////////////////////////////////////////////////////////////////////////////////////
            // Get thresholds for Right/Analyze-1
            Globals.THRESHOLDS.Add("RIGHT_ANALYZE-1_T1", Convert.ToDouble(nRight_analyze_1["T1"].InnerText));
            Globals.THRESHOLDS.Add("RIGHT_ANALYZE-1_T2", Convert.ToDouble(nRight_analyze_1["T2"].InnerText));
            Globals.THRESHOLDS.Add("RIGHT_ANALYZE-1_TA", Convert.ToDouble(nRight_analyze_1["TA"].InnerText));

            // Get thresholds for Right/Analyze-2
            Globals.THRESHOLDS.Add("RIGHT_ANALYZE-2_T1", Convert.ToDouble(nRight_analyze_2["T1"].InnerText));
            Globals.THRESHOLDS.Add("RIGHT_ANALYZE-2_T2", Convert.ToDouble(nRight_analyze_2["T2"].InnerText));
            Globals.THRESHOLDS.Add("RIGHT_ANALYZE-2_TA", Convert.ToDouble(nRight_analyze_2["TA"].InnerText));

            // Get thresholds for Right/Analyze-3
            Globals.THRESHOLDS.Add("RIGHT_ANALYZE-3_T1", Convert.ToDouble(nRight_analyze_3["T1"].InnerText));
            Globals.THRESHOLDS.Add("RIGHT_ANALYZE-3_T2", Convert.ToDouble(nRight_analyze_3["T2"].InnerText));
            Globals.THRESHOLDS.Add("RIGHT_ANALYZE-3_TA", Convert.ToDouble(nRight_analyze_3["TA"].InnerText));

            // Get thresholds for Right/Analyze-4
            Globals.THRESHOLDS.Add("RIGHT_ANALYZE-4_T1", Convert.ToDouble(nRight_analyze_4["T1"].InnerText));
            Globals.THRESHOLDS.Add("RIGHT_ANALYZE-4_T2", Convert.ToDouble(nRight_analyze_4["T2"].InnerText));
            Globals.THRESHOLDS.Add("RIGHT_ANALYZE-4_TA", Convert.ToDouble(nRight_analyze_4["TA"].InnerText));

            return true;
        }

        /// <summary>
        /// Main
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            if (ReadThresholds())
            {
                Console.WriteLine("Succeed to fetch threshold values.");
            }
            else
            {
                Console.WriteLine("Failed to fetch threshold values.");
            }

            // Debugging
            Console.WriteLine("LEFT_ANALYZE-1_T1: {0}", Globals.THRESHOLDS["LEFT_ANALYZE-1_T1"]);
            Console.WriteLine("LEFT_ANALYZE-1_T2: {0}", Globals.THRESHOLDS["LEFT_ANALYZE-1_T2"]);
            Console.WriteLine("LEFT_ANALYZE-1_TA: {0}", Globals.THRESHOLDS["LEFT_ANALYZE-1_TA"]);
            Console.WriteLine("");

            Console.WriteLine("LEFT_ANALYZE-2_T1: {0}", Globals.THRESHOLDS["LEFT_ANALYZE-2_T1"]);
            Console.WriteLine("LEFT_ANALYZE-2_T2: {0}", Globals.THRESHOLDS["LEFT_ANALYZE-2_T2"]);
            Console.WriteLine("LEFT_ANALYZE-2_TA: {0}", Globals.THRESHOLDS["LEFT_ANALYZE-2_TA"]);
            Console.WriteLine("");

            Console.WriteLine("LEFT_ANALYZE-3_T1: {0}", Globals.THRESHOLDS["LEFT_ANALYZE-3_T1"]);
            Console.WriteLine("LEFT_ANALYZE-3_T2: {0}", Globals.THRESHOLDS["LEFT_ANALYZE-3_T2"]);
            Console.WriteLine("LEFT_ANALYZE-3_TA: {0}", Globals.THRESHOLDS["LEFT_ANALYZE-3_TA"]);
            Console.WriteLine("");

            Console.WriteLine("LEFT_ANALYZE-4_T1: {0}", Globals.THRESHOLDS["LEFT_ANALYZE-4_T1"]);
            Console.WriteLine("LEFT_ANALYZE-4_T2: {0}", Globals.THRESHOLDS["LEFT_ANALYZE-4_T2"]);
            Console.WriteLine("LEFT_ANALYZE-4_TA: {0}", Globals.THRESHOLDS["LEFT_ANALYZE-4_TA"]);
            Console.WriteLine("");

            Console.ReadLine();
        }
    }
}

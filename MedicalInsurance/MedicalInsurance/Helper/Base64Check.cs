using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MedicalInsurance.Helper
{/// <summary>
/// 
/// </summary>
    public static class Base64Check
    {/// <summary>
    /// 
    /// </summary>
    /// <param name="param"></param>
    /// <returns></returns>
        public static string Check(string param)
        {

            string dummyData = param.Trim().Replace("%", "").Replace(",", "").Replace(" ", "+");
            if (dummyData.Length % 4 > 0)
            {
                dummyData = dummyData.PadRight(dummyData.Length + 4 - dummyData.Length % 4, '=');
            }

            try
            {
                Encoding myEncoding = Encoding.GetEncoding("utf-8");

                //myByte中获得这样的字节数组：228,184,173,229,141,142,228,186,186,230,176,145,229,133,177,229,146,140,229,155,189

                byte[] myByte = myEncoding.GetBytes(param);

                //把byte[]转成base64编码,这个例子形成的base64编码为:"5Lit5Y2O5Lq65rCR5YWx5ZKM5Zu9"

                 dummyData = Convert.ToBase64String(myByte);
                //byte[] byteArray = Convert.ToBase64String(dummyData);
            }
            catch (Exception e)
            {
              
                throw new  Exception(param + e.Message);
            }
           
            return dummyData;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static string ToXml(string param)
        {
            string pathXml = System.AppDomain.CurrentDomain.BaseDirectory + param+".xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(pathXml);
            return doc.InnerXml;
        }

    

    }
}


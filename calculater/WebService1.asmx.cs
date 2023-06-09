﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace calculater
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true ,Description="2 numbers add",CacheDuration =20) ]
        public int Add(int firstNumber, int secondNumber)
        {
            List<string> calculations;
            if (Session["calculations"] == null)
            {
                calculations = new List<string>();
            }
            else
            {
                calculations = (List<string>)Session["calculations"];
            }

            string strRecentCalculation = firstNumber.ToString() + " + " + secondNumber.ToString() + " = " + (firstNumber + secondNumber).ToString();

            calculations.Add(strRecentCalculation);

            Session["calculations"] = calculations;

            return firstNumber + secondNumber;
        }

        [WebMethod(EnableSession = true)]
        public List<string> GetCalculations()
        {
            if (Session["calculations"] == null)
            {
                List<string> calculations = new List<string>();
                calculations.Add("No calculations yet");
                return calculations;
            }
            else
            {
                return (List<string>)Session["calculations"];
            }
        }

    }
}

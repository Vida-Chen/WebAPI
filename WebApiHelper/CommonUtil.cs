using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebApiHelper.Models;

namespace WebApiHelper
{
	public class CommonUtil
	{
		private static ExecuteResult executeResult = null;
		public static ExecuteResult CallService(object postData, string control, string method)
		{
			//IList<LocalCuisine> d = new List<LocalCuisine>();
			//d.Add(new LocalCuisine { });
			//var result = new ExecuteResult { IsSuccess = false, Data = d, Msg = "" };
			//return result;

			executeResult = new ExecuteResult();
			string jsonString = string.Empty;
			using (HttpClient client = new HttpClient())
			{
				try
				{
					client.Timeout = TimeSpan.FromSeconds(30);
					string json = JsonConvert.SerializeObject(postData);
					HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
					Uri RequestUri = new Uri(getConfig("WebApiURL") + "/" + control + "/" + method);
					HttpResponseMessage response = client.PostAsync(RequestUri, httpContent).Result;
					if (response.IsSuccessStatusCode)
					{
						jsonString = response.Content.ReadAsStringAsync().Result;
						executeResult = JsonConvert.DeserializeObject<ExecuteResult>(jsonString);
					}
				}
				catch (Exception ee)
				{
					executeResult.Msg = ee.Message;
					executeResult.IsSuccess = false;
					Console.WriteLine("\nException Caught!");
					Console.WriteLine("Message : {0}", ee.Message);
				}
			}
			return executeResult;
		}
		public static string getConfig(string key)
		{
			return ConfigurationManager.AppSettings[key];
		}
	}
}

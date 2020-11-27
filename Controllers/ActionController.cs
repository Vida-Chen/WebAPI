using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AppLibrary;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApiHelper;
using WebApiHelper.Models;

namespace WebApiTest.Controllers
{
	[RoutePrefix("api/action")]
	public class ActionController : ApiController
	{
		[HttpPost]
		[Route("query")]
		public ExecuteResult QueryData([FromBody] JObject postData)
		{
			ExecuteResult executeResult = new ExecuteResult();
			try
			{
				//LocalCuisine foods = postData["foods"].ToObject<LocalCuisine>();
				//int intVal = postData["intVal"].ToObject<int>();
				LocalCuisine criteria = postData.ToObject<LocalCuisine>();

				//引用AppLibrary.dll中的Repository pattern, 抓取sqlite db
				Repository<LocalCuisine> rep = new Repository<LocalCuisine>(CommonUtil.getConfig("DBName"));
				executeResult.Data = rep.Select(criteria);
				executeResult.IsSuccess = true;
			}
			catch (Exception e)
			{
				executeResult.Msg = e.Message;
				executeResult.IsSuccess = false;
			}

			return executeResult;
		}

		[HttpPost]
		[Route("import")]
		public ExecuteResult BatchInsert([FromBody] JObject postData)
		{
			ExecuteResult executeResult = new ExecuteResult();
			UnitOfWork unitOfWork = null;
			try
			{
				List<LocalCuisine> stores = postData["stores"].ToObject<List<LocalCuisine>>();

				unitOfWork = new UnitOfWork(CommonUtil.getConfig("DBName"));
				unitOfWork.BeginTransaction();
				BatchDelete(unitOfWork);
				RepositoryTransaction<LocalCuisine> repTrans = new RepositoryTransaction<LocalCuisine>(unitOfWork);
				foreach (var store in stores)
				{
					repTrans.Insert(store);
				}
				unitOfWork.Commit();
				executeResult.IsSuccess = true;
				executeResult.Data = stores;
			}
			catch (Exception e)
			{
				unitOfWork.Rollback();
				executeResult.Msg = e.Message;
				executeResult.IsSuccess = false;
			}
			return executeResult;
		}

		private void BatchDelete(UnitOfWork unitOfWork)
		{
			var delSql = "delete from tb_LocalFood";
			SQLiteCommand cmd = new SQLiteCommand(delSql, unitOfWork.connection);
			cmd.ExecuteNonQuery();
		}

		[HttpPost]
		[Route("update")]
		public ExecuteResult BatchUpdate([FromBody] JObject postData)
		{
			ExecuteResult executeResult = new ExecuteResult();
			UnitOfWork unitOfWork = null;
			try
			{
				List<LocalCuisine> stores = postData["stores"].ToObject<List<LocalCuisine>>();

				unitOfWork = new UnitOfWork(CommonUtil.getConfig("DBName"));
				unitOfWork.BeginTransaction();
				RepositoryTransaction<LocalCuisine> repTrans = new RepositoryTransaction<LocalCuisine>(unitOfWork);
				foreach (var store in stores)
				{
					repTrans.Update(store);
				}
				unitOfWork.Commit();
				executeResult.IsSuccess = true;
				executeResult.Data = stores;
			}
			catch (Exception e)
			{
				unitOfWork.Rollback();
				executeResult.Msg = e.Message;
				executeResult.IsSuccess = false;
			}
			return executeResult;
		}
	}
}

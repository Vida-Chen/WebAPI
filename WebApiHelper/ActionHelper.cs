using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApiHelper.Models;

namespace WebApiHelper
{
	public class ActionHelper
	{
		public IList<string> InitDistrictDropDownList()
		{
			var districtData = new List<string>();
			districtData.Add("");
			districtData.AddRange(Query(new LocalCuisine(), new LocalCuisine()).OrderBy(x => x.DISTRICT).Select(x => x.DISTRICT).Distinct().ToList());
			return districtData;
		}

		public List<LocalCuisine> Query(LocalCuisine equalSearch, LocalCuisine fuzzySearch)
		{
			//WebApi query的寫法是equal判斷, 故除了District這種正規化欄位可equal search外, 其餘Name與Address這兩個模糊搜尋的欄位另外以lambda過濾
			ExecuteResult getAllData = CommonUtil.CallService(equalSearch, "action", "query");
			List<LocalCuisine> jObjs = new List<LocalCuisine>();
			foreach (var d in getAllData.Data)
			{
				JObject jObj = d as JObject;
				jObjs.Add(jObj.ToObject<LocalCuisine>());
			}

			if (string.IsNullOrEmpty(fuzzySearch.NAME) == false)
			{
				jObjs = jObjs.FindAll(x => x.NAME.IndexOf(fuzzySearch.NAME) > -1);
			}
			if (string.IsNullOrEmpty(fuzzySearch.ADDRESS) == false)
			{
				jObjs = jObjs.FindAll(x => x.ADDRESS.IndexOf(fuzzySearch.ADDRESS) > -1);
			}
			return jObjs;
		}

		public bool ImportData(FileInfo jsonFile)
		{
			var reverseObjs = JsonConvert.DeserializeObject<List<LocalCuisine>>(jsonFile.OpenText().ReadToEnd());
			reverseObjs.ForEach(x => x.ID = Guid.NewGuid().ToString());
			var postobjs = new { stores = reverseObjs };
			var result = CommonUtil.CallService(postobjs, "action", "import");
			return result.IsSuccess;
		}

		public void ExportFile(string fileName, List<LocalCuisine> datas)
		{
			if (fileName.ToUpper().EndsWith("JSON"))
			{
				ExportJson(fileName, datas);
			}
			else//Excel
			{
				ExportExcel(fileName, datas);
			}
		}

		private static void ExportExcel(string fileName, List<LocalCuisine> datas)
		{
			//1. 建立空白的Excel
			var memoryStream = new MemoryStream();
			using (var document = SpreadsheetDocument.Create(memoryStream, SpreadsheetDocumentType.Workbook))
			{
				var workbookPart = document.AddWorkbookPart();
				workbookPart.Workbook = new Workbook();

				var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
				worksheetPart.Worksheet = new Worksheet(new SheetData());

				var sheets = workbookPart.Workbook.AppendChild(new Sheets());
				sheets.Append(new Sheet()
				{
					Id = workbookPart.GetIdOfPart(worksheetPart),
					SheetId = 1,
					Name = "Sheet 1"
				});

				// 2.寫入資料					
				//// 從 Worksheet 取得要編輯的 SheetData
				var sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();
				var row = new Row();
				row.Append(
					new Cell()
					{
						CellValue = new CellValue("ITEM"),
						DataType = CellValues.String
					},
					new Cell()
					{
						CellValue = new CellValue("NAME"),
						DataType = CellValues.String
					},
					new Cell()
					{
						CellValue = new CellValue("DISTRICT"),
						DataType = CellValues.String
					}, new Cell()
					{
						CellValue = new CellValue("PHONE"),
						DataType = CellValues.String
					},
					new Cell()
					{
						CellValue = new CellValue("ADDRESS"),
						DataType = CellValues.String
					}
				);
				sheetData.AppendChild(row);

				foreach (var data in datas)
				{
					row = new Row();
					row.Append(new Cell() { CellValue = new CellValue(data.ITEM), DataType = CellValues.String });
					row.Append(new Cell() { CellValue = new CellValue(data.NAME), DataType = CellValues.String });
					row.Append(new Cell() { CellValue = new CellValue(data.DISTRICT), DataType = CellValues.String });
					row.Append(new Cell() { CellValue = new CellValue(data.PHONE), DataType = CellValues.String });
					row.Append(new Cell() { CellValue = new CellValue(data.ADDRESS), DataType = CellValues.String });
					sheetData.AppendChild(row);
				}

				// 3.要從 MemoryStream 匯出，必須先儲存 Workbook，並關閉 SpreadsheetDocument 物件
				workbookPart.Workbook.Save();
				document.Close();

				using (var fileStream = new FileStream(fileName, FileMode.Create))
				{
					memoryStream.WriteTo(fileStream);
				}
			}
		}

		private static void ExportJson(string fileName, List<LocalCuisine> datas)
		{
			//var newDatas = datas.Select(x => new { ITEM = x.ITEM, NAME = x.NAME, DISTRICT = x.DISTRICT, PHONE = x.PHONE, ADDRESS = x.ADDRESS });
			//var newDatas = datas.Select(x => new { x.ITEM, x.NAME, x.DISTRICT, x.PHONE, x.ADDRESS });

			string json = JsonConvert.SerializeObject(datas.Select(x => new { x.ITEM, x.NAME, x.DISTRICT, x.PHONE, x.ADDRESS }), Formatting.Indented);
			//File.WriteAllText(fileName, json);
			using (TextWriter writer = new StreamWriter(fileName))
			{
				writer.Write(json);
			}
		}

		public bool Update(List<LocalCuisine> datas)
		{
			var postData = new { stores = datas };
			var result = CommonUtil.CallService(postData, "action", "update");
			return result.IsSuccess;
		}
	}
}

## WebAPI2 practicing.
這是一個Winform 呼叫 webapi進行基本查詢、維護的範例。
- 畫面圖示

![](https://github.com/Vida-Chen/WebAPI/blob/master/Img/MainForm.png?raw=true)

- 程式架構
  + WebApiHelper - 介於winform與webapi間的溝通橋樑，winform呼叫helper的服務後，再由helper執行真正對應的WebApi內容並加以整合business rule後回傳給winform需要的資料型態與內容。
  + WebApiTest - WebApi，此範例主要僅用來處理CRUD
  + WindowsFormApp1 - Winform畫面
  
![](https://github.com/Vida-Chen/WebAPI/blob/master/Img/Architecture.png?raw=true)
  
 + 以Query查詢程式為例
  + Winform的btnQuery_Click
  
```sh
		private void btnQuery_Click(object sender, EventArgs e)
		{
			var equalSearch = new LocalCuisine { DISTRICT = string.IsNullOrEmpty(cboDistrict.Text) == false ? cboDistrict.Text : null };
			var fuzzySearch = new LocalCuisine
			{
				NAME = string.IsNullOrEmpty(txtName.Text) == false ? txtName.Text : null,
				ADDRESS = string.IsNullOrEmpty(txtAddress.Text) == false ? txtAddress.Text : null
			};
			List<LocalCuisine> datas = actionHelper.Query(equalSearch, fuzzySearch);

			dgvResult.Rows.Clear();
			foreach (var data in datas)
			{
				dgvResult.Rows.Add(data.ID, data.ITEM, data.NAME, data.DISTRICT, data.PHONE, data.ADDRESS);
			}
		}
```

  + Helper的Query()
  
```sh
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
```

  + WebApi
  
```sh
		[HttpPost]
		[Route("query")]
		public ExecuteResult QueryData([FromBody] JObject postData)
		{
			ExecuteResult executeResult = new ExecuteResult();
			try
			{
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
```

- Winform操作功能簡介
> Import 
  - 可選擇 WebApiHelper\Models\Taichung_LocalCuisine_formatter.json file後進行import, 程式會將json內容寫入sqlite資料庫(產生路徑：WebApiTest\testdb.sqlite)
  - 程式先Delete all data後再進行batch insert

![](https://github.com/Vida-Chen/WebAPI/blob/master/Img/ImportJson.png?raw=true)

> Query
  - 依查詢條件回傳符合結果
  - 用於撈出 "District" dropdownlist內容及 "Query" button的查詢結果
  
![](https://github.com/Vida-Chen/WebAPI/blob/master/Img/MainForm.png?raw=true)

> Update
  - 除Item欄位外，其餘Cell click兩下可修改該欄位值, 按下 "Update" button後進行batch update
  
![](https://github.com/Vida-Chen/WebAPI/blob/master/Img/Update.png?raw=true)

> Export
  - 可選擇匯出json or excel file
  - 依gridview內容進行匯出
  
![](https://github.com/Vida-Chen/WebAPI/blob/master/Img/Export.png?raw=true)

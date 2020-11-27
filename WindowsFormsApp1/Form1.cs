using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebApiHelper;
using WebApiHelper.Models;

namespace WindowsFormsApp1
{
	public partial class Form1 : Form
	{
		private ActionHelper actionHelper = null;

		public Form1()
		{
			InitializeComponent();
			actionHelper = new ActionHelper();
		}

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

		private void Form1_Load(object sender, EventArgs e)
		{
			dgvResult.Columns[0].Visible = false;
			dgvResult.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
			btnQuery.PerformClick();
			cboDistrict.DataSource = actionHelper.InitDistrictDropDownList();
		}

		private void btnImport_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog();
			openFileDialog1.CheckFileExists = true;
			openFileDialog1.AddExtension = true;
			openFileDialog1.Filter = "Json files (*.json)|*.json";
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				if (openFileDialog1.FileName.ToUpper().EndsWith("JSON"))
				{
					FileInfo jsonFile = new FileInfo(openFileDialog1.FileName);
					if (jsonFile.Exists)
					{
						if (actionHelper.ImportData(jsonFile))
						{
							MessageBox.Show("Import success!");
							btnQuery.PerformClick();
						}
						else
						{
							MessageBox.Show("Import fail!");
						}
					}
				}
				else
				{
					MessageBox.Show("僅限json格式!");
				}
			}
		}

		private void btnExpJson_Click(object sender, EventArgs e)
		{
			if (dgvResult.Rows.Count == 0)
			{
				MessageBox.Show("請先進行查詢!");
			}
			else
			{
				SaveFileDialog saveFileDialog1 = new SaveFileDialog();
				saveFileDialog1.Filter = "Json files(*.json)| *.json|Excel Worksheets|*.xlsx";
				saveFileDialog1.AddExtension = true;
				if (saveFileDialog1.ShowDialog() == DialogResult.OK)
				{
					if (saveFileDialog1.FileName.ToUpper().EndsWith("JSON")
						|| saveFileDialog1.FileName.ToUpper().EndsWith("XLSX"))
					{
						try
						{
							//GridToObjects => 將Datagridview 內容轉回自訂物件後，丟給SaveFileDialog做存檔用
							actionHelper.ExportFile(saveFileDialog1.FileName, GridToObjects());
							MessageBox.Show(saveFileDialog1.FileName + " 存檔成功!");
						}
						catch (Exception ee)
						{
							MessageBox.Show(ee.ToString());
						}
					}
					else
					{
						MessageBox.Show("僅限json or excel存檔格式!");
					}
				}
			}
		}

		private List<LocalCuisine> GridToObjects()
		{
			List<LocalCuisine> datas = new List<LocalCuisine>();
			foreach (DataGridViewRow row in dgvResult.Rows)
			{
				if (row.Cells["ID"].Value == null) continue;//Datagridview預設有最後一列空白列
				datas.Add(new LocalCuisine
				{
					ID = row.Cells["ID"].Value.ToString(),
					ITEM = row.Cells["ITEM"].Value.ToString(),
					NAME = row.Cells["NAME"].Value.ToString(),
					DISTRICT = row.Cells["DISTRICT"].Value.ToString(),
					PHONE = row.Cells["PHONE"].Value.ToString(),
					ADDRESS = row.Cells["ADDRESS"].Value.ToString(),
				});
			}

			return datas;
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			if (actionHelper.Update(GridToObjects()))
			{
				MessageBox.Show("Update success!");
				btnQuery.PerformClick();
			}
			else
			{
				MessageBox.Show("Update fail!");
			}
		}
	}
}

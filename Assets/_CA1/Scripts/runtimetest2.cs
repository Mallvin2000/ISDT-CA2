using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;

//---------------------------------------------------------------------------------
// Author		: Mallvin Rajamohan
// Date  		: 5/2/2021
// Description	: Write testing result to Excel file in Output folder.
//---------------------------------------------------------------------------------
public class runtimetest2 : MonoBehaviour {

	private string excelName;

    public string startTime;
    public string endTime;

	void Start() {
		RunTimeTest();
	}

	void RunTimeTest(){
		DateTime dt = DateTime.Now;
		excelName = dt.ToString("yyyy-MM-dd") + ".xls";

        string path = Application.dataPath + "/Output/";

        if (!Directory.Exists(path))
        {
            Debug.Log("Create Directory");
            Directory.CreateDirectory(path);
        }

        Debug.Log("streaming assets: " + Application.streamingAssetsPath);
            

        if (System.IO.File.Exists (path + excelName)) {
			Debug.Log ("File Exist: ["+path+"]");
            //*****
            HSSFWorkbook book;
            using (FileStream file = new FileStream(@path+excelName, FileMode.Open, FileAccess.Read))
            {
                book = new HSSFWorkbook(file);
                file.Close();
            }

            ISheet sheet = book.GetSheetAt(0);

            IRow hRow = sheet.GetRow(0);
            IRow row = sheet.CreateRow(sheet.LastRowNum);

           /*  for (int i = 0; i < hRow.LastCellNum; i++)
            {
                row.CreateCell(i).SetCellValue("F");
            } */

            sheet.CreateRow(sheet.LastRowNum + 1).CreateCell(0).SetCellValue("-END-");

            using (FileStream file = new FileStream(@path+excelName, FileMode.Open, FileAccess.Write))
            {
                book.Write(file);
                file.Close();
            }
             //*/
            //IWorkbook book = new HSSFWorkbook();
			//ISheet sheet = book.GetSheetAt(0); //GetSheet("Batch" + dt.ToString("yyyy-MM-dd"));

            //int lastRow = sheet.LastRowNum;
            //Debug.Log("Last Row: " + sheet.LastRowNum);
            //sheet.CreateRow(1).CreateCell(0).SetCellValue("Victor");
            //saveCreateCell
            //FileStream xfile = File.Create(path);
			//book.Write(xfile);
			//xfile.Close ();

		} else {
			Debug.Log ("File DOES NOT Exist");

			//*****
			IWorkbook book = new HSSFWorkbook();;
            //using (var file = new FileStream(path, FileMode.Open, FileAccess.ReadWrite)) {
            //	book = new XSSFWorkbook();
            //}
            ISheet sheet = book.CreateSheet("Batch"+ dt.ToString("yyyy-MM-dd"));
            sheet.CreateRow(0).CreateCell(0).SetCellValue("Name");
            //*
            sheet.GetRow(0).CreateCell(1).SetCellValue("StartTime");
            sheet.GetRow(0).CreateCell(2).SetCellValue("EndTime");
            sheet.GetRow(0).CreateCell(3).SetCellValue("Attempt");
            sheet.GetRow(0).CreateCell(4).SetCellValue("Place wet floor sign down");
            sheet.GetRow(0).CreateCell(5).SetCellValue("Secure safety harness");
            sheet.GetRow(0).CreateCell(6).SetCellValue("Reconnect loose wires near water ");
            //******/
            Debug.Log("headers created");
            sheet.CreateRow(sheet.LastRowNum+1).CreateCell(0).SetCellValue("-END-");
            Debug.Log("Last ROW: " + sheet.LastRowNum);

            //save
            FileStream xfile = File.Create(path+excelName);
            book.Write(xfile);
            xfile.Close();
            

        }
        startTime = DateTime.Now.ToString("hh:mm:ss tt");
	}

      public void writeToSheet(List<string> results)
    {
        Debug.Log("results received");
        var result1 = results[0];
        var result2 = results[1];
        var result3 = results[2];

        Debug.Log(result1);
        Debug.Log(result2);
        Debug.Log(result3);
        
        
        DateTime dt = DateTime.Now;
		excelName = dt.ToString("yyyy-MM-dd") + ".xls";

        string path = Application.dataPath + "/Output/";

        if (!Directory.Exists(path))
        {
            Debug.Log("Create Directory");
            Directory.CreateDirectory(path);
        }

        Debug.Log("streaming assets: " + Application.streamingAssetsPath);
            

        if (System.IO.File.Exists (path + excelName)) {
			Debug.Log ("File Exist: ["+path+"]");
            //*****
            HSSFWorkbook book;
            using (FileStream file = new FileStream(@path+excelName, FileMode.Open, FileAccess.Read))
            {
                book = new HSSFWorkbook(file);
                file.Close();
            }

           

            ISheet sheet = book.GetSheetAt(0);
            IRow row = sheet.CreateRow(sheet.LastRowNum);

         /*    int attemptNo = sheet.LastRowNum;

            if (attemptNo > 1 )
            {
                attemptNo = sheet.LastRowNum - 1;
            } */

            row.CreateCell(0).SetCellValue("User");
            row.CreateCell(1).SetCellValue(startTime);
            row.CreateCell(2).SetCellValue(endTime);
            row.CreateCell(3).SetCellValue("");
            row.CreateCell(4).SetCellValue(result1);
            row.CreateCell(5).SetCellValue(result2);
            row.CreateCell(6).SetCellValue(result3);
            sheet.CreateRow(sheet.LastRowNum + 1).CreateCell(0).SetCellValue("-END-");

            using (FileStream file = new FileStream(@path+excelName, FileMode.Open, FileAccess.Write))
            {
                book.Write(file);
                file.Close();
            }

		}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for cnn_predict
/// </summary>
public class cnn_predict
{

    public string symptoms = null;
    public string disease = null;

    DataTable dt1 = null;
    DataSet dst1 = null;

    DataTable dt2 = null;
    DataSet dst2 = null;

    common_source cls1 = new common_source();
    bool predict_flag = false;

    string Qry1 = null;

    int Count1 = 0;

    string predict_result = null;

	public cnn_predict()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public String result(string symptom,string userName)
    {

        Qry1 = "select * from TblDatasetsym where symptom='" + symptom + "'";
        dst1 = cls1.bnd(Qry1);
        dt1 = dst1.Tables[0];
        foreach (DataRow dr1 in dt1.Rows)
        {
            disease = Convert.ToString(dr1["disease"]);
            Qry1 = "insert into TblTmpResult (disease) values ('" + disease + "')";
            cls1.insert_update_delete(Qry1);
        }

        dst2 = cls1.bnd("select * from TblPatSymptoms where user1='" + userName + "'");
        dt2 = dst2.Tables[0];
        foreach (DataRow dr2 in dt2.Rows)
        {
            symptom = Convert.ToString(dr2["symptom"]);
            disease = cls1.return_single_string("select Disease from TblDataSetSym where symptom like '%" + symptom + "'");
            Qry1 = "insert into TblTmpResult (symptom) values ('" + symptom + "')";
            cls1.insert_update_delete(Qry1);
        }

        dst1 = cls1.bnd("select * from tblTmpResult");
        dt1 = dst1.Tables[0];
        foreach (DataRow dr1 in dt1.Rows)
        {
            disease = Convert.ToString(dr1["Disease"]);
            Count1 = cls1.record_count("select count(*) from TblPatSymptoms where diease='" + disease + "'");
            Qry1 = "update TblTmpResult set TotCount=" + Count1 + " where Disease='" + disease + "'";
            cls1.insert_update_delete(Qry1);
        }


        dst2 = cls1.bnd("select * from TmpResult where user1='" + userName + "'");
        dt2 = dst2.Tables[0];

        int[] arr = new int[] { };

        int temp;

        // traverse 0 to array length 
        for (int i = 0; i < arr.Length - 1; i++)

            // traverse i+1 to array length 
            for (int j = i + 1; j < arr.Length; j++)

                // compare array element with  
                // all next element 
                if (arr[i] < arr[j])
                {

                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }

        // print all element of array 
        foreach (int value in arr)
        {
            predict_result = Convert.ToString(value);
            //Console.Write(value + " ");
        } 

        return predict_result;


    }


}
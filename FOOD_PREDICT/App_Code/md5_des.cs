using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Collections.Specialized;
using System.Security.Cryptography;




/// <summary>
/// Summary description for md5_des
/// </summary>
public class md5_des : System.Web.UI.Page 
{

    private byte[] lbtVector = {240,3,45,29,0,76,173,59};

    private string lscryptoKey = "ChangeThis!";


    public md5_des()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string psDecrypt(string sQueryString)
    {

        byte[] buffer = null;
        TripleDESCryptoServiceProvider loCryptoClass = new TripleDESCryptoServiceProvider();
        MD5CryptoServiceProvider loCryptoProvider = new MD5CryptoServiceProvider();


        try
        {
            buffer = Convert.FromBase64String(sQueryString);
            loCryptoClass.Key = loCryptoProvider.ComputeHash(ASCIIEncoding.ASCII.GetBytes(lscryptoKey));
            loCryptoClass.IV = lbtVector;
            return Encoding.ASCII.GetString(loCryptoClass.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length));
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            loCryptoClass.Clear();
            loCryptoProvider.Clear();
            loCryptoClass = null;
            loCryptoProvider = null;
        }


    }

    public string psEncrypt(string sInputVal)
    {
        string functionReturnValue = null;

        TripleDESCryptoServiceProvider loCryptoClass = new TripleDESCryptoServiceProvider();
        MD5CryptoServiceProvider loCryptoProvider = new MD5CryptoServiceProvider();
        byte[] lbtBuffer = null;

        try
        {
            lbtBuffer = System.Text.Encoding.ASCII.GetBytes(sInputVal);
            loCryptoClass.Key = loCryptoProvider.ComputeHash(ASCIIEncoding.ASCII.GetBytes(lscryptoKey));
            loCryptoClass.IV = lbtVector;
            sInputVal = Convert.ToBase64String(loCryptoClass.CreateEncryptor().TransformFinalBlock(lbtBuffer, 0, lbtBuffer.Length));
            functionReturnValue = sInputVal;
        }
        catch (CryptographicException ex)
        {
            throw ex;
        }
        catch (FormatException ex)
        {
            throw ex;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            loCryptoClass.Clear();
            loCryptoProvider.Clear();
            loCryptoClass = null;
            loCryptoProvider = null;
        }
        return functionReturnValue;
    }


}

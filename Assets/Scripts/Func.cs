using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;
public class Func {

    //读取json文件
    public string readJsonData(string file)
    {
        FileInfo fi = new FileInfo(file);

        StreamReader sr = fi.OpenText();
        string jsonData = sr.ReadToEnd();
        Debug.Log(jsonData);
        sr.Close();
        sr.Dispose();
        return jsonData;
    }
    //写入json文件
    public void writeJsonData(string file, object ob)
    {
        string json = JsonUtility.ToJson(ob);
        Debug.Log("json:" + json);
        StreamWriter sw;
        FileInfo fi = new FileInfo(file);
        /* if (!fi.Exists)
         {
             //如果此文件不存在则创建
             sw = fi.CreateText();
         }
         else
         {
             //如果此文件存在则打开
             sw = fi.AppendText();
         }*/
        if (fi.Exists)
        {
            fi.Delete();
        }
        sw = fi.CreateText();//创建
        sw.Write(json);
        sw.Close();
        sw.Dispose();
    }

    //读取数据
    //public void readData()
    //{
    //    FileInfo fi = new FileInfo(Application.dataPath + "/Data/GameData.json");
    //    StreamReader sr;
    //    sr = fi.OpenText();

    //    string jsonData = sr.ReadToEnd();
    //    sr.Close();
    //    sr.Dispose();
    //    //TextAsset jsonData = Resources.Load<TextAsset>("GameData");
    //    Debug.Log(jsonData);
    //    GameManager.PrefectureModel jsonObject = JsonUtility.FromJson<GameManager.PrefectureModel>(jsonData);


    //    foreach (GameManager.Prefecture info in jsonObject.preList)
    //    {
    //        Debug.Log((int)info.dd + " " + (int)info.j);
    //    }
    //    //FileInfo fi = new FileInfo(Application.dataPath + "/Data/GameData.json");
    //    //if (fi.Exists)
    //    //{
    //    //    StreamReader sr;
    //    //    sr = fi.OpenText();
    //    //    string line = "";
    //    //    string gameDataStr = "";
    //    //    string key = "";
    //    //    //if ((line = sr.ReadLine()) != null && line.Length == 32)
    //    //    //{
    //    //    //    key = line;
    //    //    //    Debug.Log("读取key:" + key);
    //    //    //}
    //    //    //else
    //    //    //{

    //    //    //    sr.Close();
    //    //    //    sr.Dispose();
    //    //    //    Debug.Log("数据文件出错");
    //    //    //    saveData();
    //    //    //    return;
    //    //    //}

    //    //    if ((line = sr.ReadLine()) != null)
    //    //    {
    //    //        gameDataStr = line;
    //    //        Debug.Log("读取json:" + gameDataStr);
    //    //    }
    //    //    else
    //    //    {
    //    //        sr.Close();
    //    //        sr.Dispose();
    //    //        Debug.Log("数据文件出错");
    //    //        saveData();
    //    //        return;
    //    //    }
    //    //    sr.Close();
    //    //    sr.Dispose();
    //    //    byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
    //    //    /*
    //    //    RijndaelManaged rDel = new RijndaelManaged();
    //    //    rDel.Key = keyArray;
    //    //    rDel.Mode = CipherMode.ECB;
    //    //    rDel.Padding = PaddingMode.PKCS7;
    //    //    ICryptoTransform cTrans = rDel.CreateDecryptor();
    //    //    byte[] toEncryptArray = System.Convert.FromBase64String(gameDataStr);
    //    //    byte[] resu = cTrans.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
    //    //    gameDataStr = UTF8Encoding.UTF8.GetString(resu);*/
    //    //    //解密完
    //    //    Debug.Log("读取:" + gameDataStr);
    //    //    GameManager.getInstance().playerData = JsonUtility.FromJson<GameManager.PlayerDataJson>(gameDataStr);
    //    //    Debug.Log("对象:" + GameManager.getInstance().playerData.time);


    ////}
    ////    else
    ////    {
    ////        saveData();
    ////        Debug.Log("数据文件出错");
    ////    }

    //}
    //写入数据
    //public void saveData()
    //{
    //    string json = JsonUtility.ToJson(GameManager.getInstance().playerData);
    //    Debug.Log("json:" + json);
    //    StreamWriter sw;
    //    FileInfo fi = new FileInfo(Application.dataPath + "/Data/GameData.json");
    //    if (fi.Exists)
    //    {
    //        fi.Delete();
    //        sw = fi.AppendText();
    //    }
    //    else
    //    {
    //        sw = fi.CreateText();
    //    }

    //    string key = "";
    //    for (int i = 0; i < 32; i++)
    //    {
    //        key += Random.Range(0, 10);
    //    }
    //    Debug.Log("key:" + key + ";lengt:" + key.Length);
    //    /*
    //    byte[] keyArray = UTF8Encoding.UTF8.GetBytes(key);
    //    RijndaelManaged rDel = new RijndaelManaged();
    //    rDel.Key = keyArray;
    //    rDel.Mode = CipherMode.ECB;
    //    rDel.Padding = PaddingMode.PKCS7;
    //    ICryptoTransform cTransform = rDel.CreateEncryptor();
    //    byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(json);
    //    byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
    //    json = System.Convert.ToBase64String(resultArray, 0, resultArray.Length);*/
    //    //加密完

    //    //sw.WriteLine(key);
    //    //sw.WriteLine(json);
    //    sw.Close();
    //    sw.Dispose();
    //}

    //读取XML文件
    public string readXMLData(string fileName, string itemName)
    {

        XmlDocument XMLDoc = new XmlDocument();
        XMLDoc.LoadXml(fileName);
        XmlNodeList nodeList = XMLDoc.FirstChild.ChildNodes;

        /// XMLDoc.
        foreach (XmlNode xe in nodeList)
        {
            if (xe.Attributes["name"].InnerText == itemName)
            {

                return xe.InnerText;
            }




        }
        return "";
    }

    //读取军队XML文件
    public string readXMLArmsData(string fileName, string itemName, string value)
    {


        XmlDocument XMLDoc = new XmlDocument();
        XMLDoc.LoadXml(fileName);
        //XMLDoc.l

        // XmlNode armsNode = XMLDoc.FirstChild.SelectSingleNode("Arms");
        XmlNodeList armsNodeList = XMLDoc.FirstChild.ChildNodes;
        // if (armsNodeList != null)
        // {
        foreach (XmlNode armsXmlNode in armsNodeList)
        {
            if (armsXmlNode.Attributes["id"].Value == itemName)
            {
                //Debug.Log(courseNode.Attributes["id"].Value);
                return armsXmlNode.Attributes[value].Value;
            }
        }




        return "";

    }
    [ExecuteInEditMode]
    public static GameManager.PlayerDataJson LoadJsonFromFile(string path)
    {
        BinaryFormatter bf = new BinaryFormatter();

        if (!File.Exists(path))
        {
            return null;
        }

        StreamReader sr = new StreamReader(path);

        //FileStream file = File.Open(Application.dataPath + "/Test.json", FileMode.Open, FileAccess.ReadWrite);
        //if (file.Length == 0)
        //{
        //    return null;
        //}

        //string json = (string)bf.Deserialize(file);
        //file.Close();
        
        if (sr == null)
        {
            return null;
        }
        string json = sr.ReadToEnd();

        if (json.Length > 0)
        {
            // sr.Close();
            //sr.Dispose();
            GameManager.PlayerDataJson A= JsonUtility.FromJson<GameManager.PlayerDataJson>(json);
            
           sr.Close();
          sr.Dispose();
            return A;
        }

        return null;
    }





    private static Func func;
    public static Func getInstance()
    {
        if (func == null)
        {
            func = new Func();
        }
        return func;
    }
    private Func()
    {
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;

using System;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;


namespace AssemblyCSharp1
{

    public class AddressData1
    {
        public string timeURL;
        public static string all;
        public static string hp;
        public static string speed;
        public static string demage;

        public static string localPath;
        public static string id;
        public static string score;
        public static List<int> allScore;

        public void AddressData()
        {
            Debug.Log(localPath);
        }

        public static List<int> getAllScore()
        {
            return allScore;
        }

        /// <summary>
        /// 获取XML路径
        /// </summary>
        /// <returns>The XM.</returns>
        public static IEnumerator GetXML()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                localPath = Application.streamingAssetsPath + "/score.xml"; //在Android中实例化WWW不能在路径前面加"file://"
                Debug.Log(localPath);
            }
            else
            {
                localPath = "file://" + UnityEngine.Application.streamingAssetsPath + "/score.xml";//在Windows中实例化WWW必须要在路径前面加"file://"

                Debug.Log(localPath);
            }
            WWW www = new WWW(localPath);
            while (!www.isDone)
            {
                Debug.Log("Getting GetXML");
                yield return www;
                all = www.text;
                ParseXml(www);
            }
        }

        /// <summary>
        ///按属性获取节点
        /// </summary>
        /// <param name="www">Www.</param>
        public static void ParseXml(WWW www)
        {
            if (allScore == null)
            {
                allScore = new List<int>();
            }
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(www.text);
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("rank").ChildNodes;

            foreach (XmlElement xe in nodeList)
            {
                id = xe.GetAttribute("id");
                score = xe.GetAttribute("score");
                allScore.Add(int.Parse(score));  //将所有得分读入List

                Debug.Log("ID:" + id + " Score:" + score);
            }
            allScore.Sort();
            allScore.Reverse();
            foreach (var score in allScore)
            {
                Debug.Log(score.ToString());
            }
        }

        /// <summary>
        /// 读取xml内容
        /// </summary>
        public static IEnumerator load()
        {
            string url = string.Empty;
            string path = string.Empty;
            string line1 = string.Empty;
            if (Application.platform == RuntimePlatform.Android)
            {
                url = Application.streamingAssetsPath + "/hp.xml"; //在Android中实例化WWW不能在路径前面加"file://"

                WWW wWA = new WWW(path);///WWW读取在各个平台上都可使用
                yield return wWA;
                line1 = wWA.text;
                Debug.Log(line1);
            }
            else
            {
                url = "file://" + Application.streamingAssetsPath + "/hp.xml";//在Windows中实例化WWW必须要在路径前面加"file://"
                WWW wWA = new WWW("file://" + url);
                yield return wWA;
                line1 = wWA.text;
                Debug.Log(line1);
            }
            yield return null;
        }


        /// <summary>
        /// 加载xml文档
        /// </summary>
        /// <returns></returns>
        public static XmlDocument ReadAndLoadXml()
        {
            XmlDocument doc = new XmlDocument();
            //Debug.Log("加载xml文档");
            doc.Load(localPath);
            return doc;
        }

        /// <summary>
        /// 增加节点
        /// </summary>
        /// <returns>The node.</returns>
        /// <param name="score">Score.</param>
        public static void insertNode(int score)
        {
            int minute = int.Parse((System.DateTime.Now.Minute.ToString()));
            string order = System.DateTime.Now.Hour + "" + System.DateTime.Now.Minute + "" + System.DateTime.Now.Second;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Application.dataPath + "/StreamingAssets/score.xml");
            XmlNode root = xmlDoc.SelectSingleNode("rank");

            XmlElement xel = xmlDoc.CreateElement("rank");    //建立节点
            xel.SetAttribute("id", order);
            xel.SetAttribute("score", score.ToString());

            root.AppendChild(xel);
            xmlDoc.Save(Application.dataPath + "/StreamingAssets/score.xml");
            return;
        }

    }


}

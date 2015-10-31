/// <summary>
/// 類說明：XmlHelper
/// 編 碼 人：蘇飛
/// 聯繫方式：361983679  
/// 更新網站：http://www.sufeinet.com/thread-655-1-1.html
/// </summary>
using System.Xml;
using System.Data;

namespace DotNet.Utilities
{
    /// <summary>
    /// Xml的操作公共類
    /// </summary>    
    public class XmlHelper
    {
        #region 字段定義
        /// <summary>
        /// XML文件的物理路徑
        /// </summary>
        private string _filePath = string.Empty;
        /// <summary>
        /// Xml文檔
        /// </summary>
        private XmlDocument _xml;
        /// <summary>
        /// XML的根節點
        /// </summary>
        private XmlElement _element;
        #endregion

        #region 構造方法
        /// <summary>
        /// 實例化XmlHelper對像
        /// </summary>
        /// <param name="xmlFilePath">Xml文件的相對路徑</param>
        public XmlHelper(string xmlFilePath)
        {
            //獲取XML文件的絕對路徑
            _filePath = SysHelper.GetPath(xmlFilePath);
        }
        #endregion

        #region 創建XML的根節點
        /// <summary>
        /// 創建XML的根節點
        /// </summary>
        private void CreateXMLElement()
        {

            //創建一個XML對像
            _xml = new XmlDocument();

            if (DirFileHelper.IsExistFile(_filePath))
            {
                //加載XML文件
                _xml.Load(this._filePath);
            }

            //為XML的根節點賦值
            _element = _xml.DocumentElement;
        }
        #endregion

        #region 獲取指定XPath表達式的節點對像
        /// <summary>
        /// 獲取指定XPath表達式的節點對像
        /// </summary>        
        /// <param name="xPath">XPath表達式,
        /// 範例1: @"Skill/First/SkillItem", 等效於 @"//Skill/First/SkillItem"
        /// 範例2: @"Table[USERNAME='a']" , []表示篩選,USERNAME是Table下的一個子節點.
        /// 範例3: @"ApplyPost/Item[@itemName='崗位編號']",@itemName是Item節點的屬性.
        /// </param>
        public XmlNode GetNode(string xPath)
        {
            //創建XML的根節點
            CreateXMLElement();

            //返回XPath節點
            return _element.SelectSingleNode(xPath);
        }
        #endregion

        #region 獲取指定XPath表達式節點的值
        /// <summary>
        /// 獲取指定XPath表達式節點的值
        /// </summary>
        /// <param name="xPath">XPath表達式,
        /// 範例1: @"Skill/First/SkillItem", 等效於 @"//Skill/First/SkillItem"
        /// 範例2: @"Table[USERNAME='a']" , []表示篩選,USERNAME是Table下的一個子節點.
        /// 範例3: @"ApplyPost/Item[@itemName='崗位編號']",@itemName是Item節點的屬性.
        /// </param>
        public string GetValue(string xPath)
        {
            //創建XML的根節點
            CreateXMLElement();

            //返回XPath節點的值
            return _element.SelectSingleNode(xPath).InnerText;
        }
        #endregion

        #region 獲取指定XPath表達式節點的屬性值
        /// <summary>
        /// 獲取指定XPath表達式節點的屬性值
        /// </summary>
        /// <param name="xPath">XPath表達式,
        /// 範例1: @"Skill/First/SkillItem", 等效於 @"//Skill/First/SkillItem"
        /// 範例2: @"Table[USERNAME='a']" , []表示篩選,USERNAME是Table下的一個子節點.
        /// 範例3: @"ApplyPost/Item[@itemName='崗位編號']",@itemName是Item節點的屬性.
        /// </param>
        /// <param name="attributeName">屬性名</param>
        public string GetAttributeValue(string xPath, string attributeName)
        {
            //創建XML的根節點
            CreateXMLElement();

            //返回XPath節點的屬性值
            return _element.SelectSingleNode(xPath).Attributes[attributeName].Value;
        }
        #endregion

        #region 新增節點
        /// <summary>
        /// 1. 功能：新增節點。
        /// 2. 使用條件：將任意節點插入到當前Xml文件中。
        /// </summary>        
        /// <param name="xmlNode">要插入的Xml節點</param>
        public void AppendNode(XmlNode xmlNode)
        {
            //創建XML的根節點
            CreateXMLElement();

            //導入節點
            XmlNode node = _xml.ImportNode(xmlNode, true);

            //將節點插入到根節點下
            _element.AppendChild(node);
        }

        /// <summary>
        /// 1. 功能：新增節點。
        /// 2. 使用條件：將DataSet中的第一條記錄插入Xml文件中。
        /// </summary>        
        /// <param name="ds">DataSet的實例，該DataSet中應該只有一條記錄</param>
        public void AppendNode(DataSet ds)
        {
            //創建XmlDataDocument對像
            XmlDataDocument xmlDataDocument = new XmlDataDocument(ds);

            //導入節點
            XmlNode node = xmlDataDocument.DocumentElement.FirstChild;

            //將節點插入到根節點下
            AppendNode(node);
        }
        #endregion

        #region 刪除節點
        /// <summary>
        /// 刪除指定XPath表達式的節點
        /// </summary>        
        /// <param name="xPath">XPath表達式,
        /// 範例1: @"Skill/First/SkillItem", 等效於 @"//Skill/First/SkillItem"
        /// 範例2: @"Table[USERNAME='a']" , []表示篩選,USERNAME是Table下的一個子節點.
        /// 範例3: @"ApplyPost/Item[@itemName='崗位編號']",@itemName是Item節點的屬性.
        /// </param>
        public void RemoveNode(string xPath)
        {
            //創建XML的根節點
            CreateXMLElement();

            //獲取要刪除的節點
            XmlNode node = _xml.SelectSingleNode(xPath);

            //刪除節點
            _element.RemoveChild(node);
        }
        #endregion //刪除節點

        #region 保存XML文件
        /// <summary>
        /// 保存XML文件
        /// </summary>        
        public void Save()
        {
            //創建XML的根節點
            CreateXMLElement();

            //保存XML文件
            _xml.Save(this._filePath);
        }
        #endregion //保存XML文件

        #region 靜態方法

        #region 創建根節點對像
        /// <summary>
        /// 創建根節點對像
        /// </summary>
        /// <param name="xmlFilePath">Xml文件的相對路徑</param>        
        private static XmlElement CreateRootElement(string xmlFilePath)
        {
            //定義變量，表示XML文件的絕對路徑
            string filePath = "";

            //獲取XML文件的絕對路徑
            filePath = SysHelper.GetPath(xmlFilePath);

            //創建XmlDocument對像
            XmlDocument xmlDocument = new XmlDocument();
            //加載XML文件
            xmlDocument.Load(filePath);

            //返回根節點
            return xmlDocument.DocumentElement;
        }
        #endregion

        #region 獲取指定XPath表達式節點的值
        /// <summary>
        /// 獲取指定XPath表達式節點的值
        /// </summary>
        /// <param name="xmlFilePath">Xml文件的相對路徑</param>
        /// <param name="xPath">XPath表達式,
        /// 範例1: @"Skill/First/SkillItem", 等效於 @"//Skill/First/SkillItem"
        /// 範例2: @"Table[USERNAME='a']" , []表示篩選,USERNAME是Table下的一個子節點.
        /// 範例3: @"ApplyPost/Item[@itemName='崗位編號']",@itemName是Item節點的屬性.
        /// </param>
        public static string GetValue(string xmlFilePath, string xPath)
        {
            //創建根對像
            XmlElement rootElement = CreateRootElement(xmlFilePath);

            //返回XPath節點的值
            return rootElement.SelectSingleNode(xPath).InnerText;
        }
        #endregion

        #region 獲取指定XPath表達式節點的屬性值
        /// <summary>
        /// 獲取指定XPath表達式節點的屬性值
        /// </summary>
        /// <param name="xmlFilePath">Xml文件的相對路徑</param>
        /// <param name="xPath">XPath表達式,
        /// 範例1: @"Skill/First/SkillItem", 等效於 @"//Skill/First/SkillItem"
        /// 範例2: @"Table[USERNAME='a']" , []表示篩選,USERNAME是Table下的一個子節點.
        /// 範例3: @"ApplyPost/Item[@itemName='崗位編號']",@itemName是Item節點的屬性.
        /// </param>
        /// <param name="attributeName">屬性名</param>
        public static string GetAttributeValue(string xmlFilePath, string xPath, string attributeName)
        {
            //創建根對像
            XmlElement rootElement = CreateRootElement(xmlFilePath);

            //返回XPath節點的屬性值
            return rootElement.SelectSingleNode(xPath).Attributes[attributeName].Value;
        }
        #endregion

        #endregion

        public static void SetValue(string xmlFilePath, string xPath, string newtext)
        {
            //string path = SysHelper.GetPath(xmlFilePath);
            //var queryXML = from xmlLog in xelem.Descendants("msg_log")
            //               //所有名字為Bin的記錄
            //               where xmlLog.Element("user").Value == "Bin"
            //               select xmlLog;

            //foreach (XElement el in queryXML)
            //{
            //    el.Element("user").Value = "LiuBin";//開始修改
            //}
            //xelem.Save(path);
        }
    }
}

// ***************************** Blatchford Devolpment Team **************************
using System;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using LitJson;

namespace DataBase
{
    public class JSONFileManger
    {
        private static string jsonString;
        private static JsonData elementData;
        private static JsonMapper jsonMap;
        
        /// <summary>
        /// Get a number value from from JSON File.
        /// </summary>
        public static double GetValueInt(string path, string objectName, int group, string elementName)
        {
            if(!File.Exists(Application.dataPath + "\\" + path) {
                Debug.Log("There no File Called {0}", Application.dataPath + "\\" + path); 
                return 0;
            }else {
                jsonString = File.ReadAllText(Application.dataPath + "\\" + path);
                elementData = JsonMapper.ToObject(jsonString);
                return (double)elementData[objectName][group][elementName];
            }
        }
        
        /// <summary>
        /// Get a string value from from JSON File
        /// </summary>
        public static string GetValueString(string path, string objectName, int group, string elementName)
        {
            if(!File.Exists(Application.dataPath + "\\" + path) {
                Debug.Log("There no File Called {0}", Application.dataPath + path); 
                return null;
            }else {
                jsonString = File.ReadAllText(Application.dataPath + "\\" + path);
                elementData = JsonMapper.ToObject(jsonString);
                return elementData[objectName][group][elementName].ToString();
            }
        }
        
        /// <summary>
        /// Add Data to a JSON File if not exist will creat new
        /// Simple to use Exemple :
        /// A class called player have fildes (name,level,health) with constructer that can pass on it value of last fildes , creat a new object "Player player = new Player("Aymen",5,5);, whene you pass player object ass arge in AddDataObject("playerData.json",player) will creat json struct data on playerData.json
        /// </summary>
        public static void AddDataObject(string path,object objectName)
        {
            elementData = JsonMapper.ToJson(objectName);
            if (File.Exists(Application.dataPath + "\\" + path))
            {
                File.WriteAllText(Application.dataPath + "\\" + path, elementData.ToString);
            }
            else
            {
                Debug.Log("There no File Called {0}, Creating new one !", Application.dataPath + path); 
                File.Create(Application.dataPath + "\\" + path);
            }
        }
    }
}

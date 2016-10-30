using System;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using LitJson;

	public class StringValue {
		public string name;
		public string value;
		
		public StringValue(string _name, string _value) {
			this.name = _name;
			this.value = _value;
		}
	}
	
	public class NumberValue {
		public string name;
		public double value;
		
		public  NumberValue(string _name, double _value) {
			this.name = _name;
			this.value = _value;
		}
	}
	
    public static class JSONFileManger
    {
        private static string jsonString;
        private static JsonData elementData;
        private static JsonMapper jsonMap;
        
        /// <summary>
        /// Get a number value from from JSON File.
        /// </summary>
        public static double GetValueInt(string path, string objectName, int group, string elementName)
        {
        	if(!File.Exists(Application.dataPath + "\\" + path)) {
                Debug.Log("There no File, Creating new one !"); 
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
        	if(!File.Exists(Application.dataPath + "\\" + path)) {
                Debug.Log("There no File, Creating new one !"); 
                return null;
            }else {
                jsonString = File.ReadAllText(Application.dataPath + "\\" + path);
                elementData = JsonMapper.ToObject(jsonString);
                return elementData[objectName][group][elementName].ToString();
            }
        }
        
        /// <summary>
        /// Add Data to a JSON File if not exist will creat new
        /// Simple to use 
        /// 
        /// </summary>
        public static void AddStringData(string path,string name,string value)
        {
        	StringValue str = new StringValue(name,value);
            elementData = JsonMapper.ToJson(str);
            if (File.Exists(Application.dataPath + "\\" + path))
            {
            	File.WriteAllText(Application.dataPath + "\\" + path, elementData.ToString());
            }
            else
            {
                Debug.Log("There no File, Creating new one !");
                File.WriteAllText(Application.dataPath + "\\" + path, elementData.ToString());
               // File.Create(Application.dataPath + "\\" + path);
            }
        }
        
        public static void AddNumberData(string path,string name,double value)
        {
        	NumberValue str = new NumberValue(name,value);
            elementData = JsonMapper.ToJson(str);
            if (File.Exists(Application.dataPath + "\\" + path))
            {
            	File.WriteAllText(Application.dataPath + "\\" + path, elementData.ToString());
            }
            else
            {
                Debug.Log("There no File, Creating new one !");
                File.WriteAllText(Application.dataPath + "\\" + path, elementData.ToString());
            }
        }
    }


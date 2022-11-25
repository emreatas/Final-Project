using System.Collections.Generic;
using System.IO;
using System.Linq;
using Player;
using UnityEngine;

namespace JSONSystem
{
    public static class JSONSaveSystem
    {
        public static string filename = "Characters.json";
        public static string resourcesFilename = "Characters";
        
        public static void SaveToJSON<T>(T saveData, bool prettyPrint)
        {
            List<T> dataInJson = ReadFromJson<T>();
            string content = JsonHelper.ToJson(saveData, prettyPrint, dataInJson);
            WriteFile(GetPath(), content);
        }
        
        public static void SaveToJSON<T>(List<T> saveData, bool prettyPrint)
        {
            List<T> dataInJson = ReadFromJson<T>();
            string content = JsonHelper.ToJson(saveData, prettyPrint, dataInJson);
            WriteFile(GetPath(), content);
        }
        
        public static List<T> ReadFromJson<T>()
        {
            Debug.Log(GetPath());
            string content = ReadFile(GetPath());
            if (string.IsNullOrEmpty(content) || content == "")
            {
                return new List<T>();
            }
            List<T> res = JsonHelper.FromJson<T>(content).ToList();

            return res;
        }
        
        private static string GetPath()
        {
            return Path.Combine(Application.persistentDataPath, filename);
        }

        private static void WriteFile(string path, string content)
        {
            FileStream fileStream = new FileStream(path, FileMode.Create);

            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                writer.Write(content);
            }
            fileStream.Close();
        }
/*
        private static void ResetDataInJson()
        {
            string content = JsonHelper.ResetJson<PlayerClass>();
            WriteFile(GetPath(),content);
        }
        
        public static void InitializeLevels()
        {
            ResetDataInJson();  
            var levels = Resources.Load<TextAsset>(resourcesFilename);
            List<PlayerClass> levelsList = JsonHelper.FromJson<PlayerClass>(levels.ToString()).ToList();
            SaveToJSON(levelsList,true);
        }
*/
        public static string ReadFile(string path)
        {
            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string content = reader.ReadToEnd();
                    reader.Close();
                    return content;
                    
                }
            }
            return "";
        }
    }
}
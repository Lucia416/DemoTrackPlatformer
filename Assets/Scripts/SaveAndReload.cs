using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq;


public static class SaveAndReload
{

    private static string m_savePath = Application.dataPath + "/GameSave/";
    private const string m_extension = "txt";

    public static void Init()
    {
        if (!Directory.Exists(m_savePath)) Directory.CreateDirectory(m_savePath);
    }
    public static void Save(string saveString)
    {
        int gameDataNumber = 1;
        while (File.Exists(m_savePath + "game_" + gameDataNumber + "." + m_extension))
        {
            gameDataNumber++;
        }

        File.WriteAllText(m_savePath + "game_" + gameDataNumber + "." + m_extension, saveString);
    }

    public static string Load()
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(m_savePath);
        FileInfo[] fileInfo = directoryInfo.GetFiles("*." + m_extension);
        FileInfo m_savedData = null;
        foreach (FileInfo info in fileInfo)
        {
            if (m_savedData == null)
            {
                m_savedData = info;
            }
            else
            {
                if (info.LastWriteTime > m_savedData.LastWriteTime)
                {
                    m_savedData = info;
                }
            }
        }
        if (m_savedData != null)
        {
            string saveString = File.ReadAllText(m_savedData.FullName);
            return saveString;
        }
        else
        {
            return null;
        }

    }
}

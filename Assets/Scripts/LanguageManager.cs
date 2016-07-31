using System;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class LanguageManager
{
    private static Language language = null;

    static BinaryFormatter formatter = new BinaryFormatter();

    public static bool setText(string goName, string text)
    {
        var go = GameObject.Find(goName);
        return setText(go, text);
    }

    public static bool setText(GameObject go, string text)
    {
        if (go != null)
        {
            go.GetComponent<Text>().text = text;
            return true;
        }
        else
        {
            return false;
        }
    }

    public static Language getLanguage()
    {
        return language;
    }

    public static void setLanguage(string languageName)
    {
        var text = Resources.Load(ScenesParameters.LanguagesDirectory + '/' + languageName) as TextAsset;
        Stream s = new MemoryStream(text.bytes);
        BinaryReader br = new BinaryReader(s);

        language = (Language)formatter.Deserialize(br.BaseStream);

        Debug.Log(language);

        /*if (File.Exists(path))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            //FileStream file = File.Open(path, FileMode.Open);
            //language = (Language) binaryFormatter.Deserialize(file);
            var stream = new StreamReader(path, Encoding.GetEncoding(1251));
            Debug.Log(path);
            language = (Language)serializer.Deserialize(stream);
            stream.Close();
            //file.Close();
        }*/

        /*TextAsset textAsset = Resources.Load<TextAsset>(
                                            ScenesParameters.LanguagesDirectory +
                                             '/' + languageName);*/
        /*MemoryStream stream = new MemoryStream();
        StreamWriter writer = new StreamWriter(stream);
        writer.Write(textAsset.text);
        writer.Flush();
        stream.Position = 0;

        var str1 = formatter.Deserialize(stream).ToString();
        Debug.Log("234241 " + str1);

        StringReader stringReader = new StringReader(textAsset.text);
        //StreamReader streamReader = new StreamReader(textAsset.text, Encoding.GetEncoding("ISO-8859-9"));
        //XmlReader reader = System.Xml.XmlReader.Create(stringReader);

        Debug.Log("тест " + Resources.Load<TextAsset>(ScenesParameters.LanguagesDirectory +
                                             '/' + "1.txt"));
        //using (StreamReader reader = new StreamReader(textAsset.text, Encoding.UTF8, true))
        //{

        //    language = (Language)serializer.Deserialize(reader);
        //}

        // deserialize xml to object

        // converts a string to a UTF-8 byte array.
        //UTF8Encoding encodingDeserialize = new UTF8Encoding();

        Encoding encoding = Encoding.GetEncoding(1251);

        var str = stringReader.ReadToEnd();
        Debug.Log("1string тест" + encoding.GetString(textAsset.bytes));

        byte[] byteArray = encoding.GetBytes(str);

        using (MemoryStream memoryStreamDeserialize = new MemoryStream(byteArray))
        {
            XmlSerializer xmlSerializerDeserialize = new XmlSerializer(typeof(Language));
            XmlTextWriter xmlTextWriterDeserialize = new XmlTextWriter(memoryStreamDeserialize, encoding);

            language = (Language)xmlSerializerDeserialize.Deserialize(xmlTextWriterDeserialize.BaseStream);
        }

        //language = (Language)serializer.Deserialize(reader);*/
    }


}

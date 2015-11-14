using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.Xml;

public class XMLParser : MonoBehaviour {

    XmlSerializer serializer = new XmlSerializer(typeof(GameObject));

    public void parse(string filename)
    {
        var resultingMessage = (GameObject)serializer.Deserialize(new XmlTextReader(filename));
    }
}

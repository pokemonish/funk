using System.Xml.Serialization;
using System.Xml;
using System.IO;
using UnityEngine;

public class XMLParser {

    XmlSerializer serializer = new XmlSerializer(typeof(Level));

    public object parse(string filename)
    {
        TextAsset textAsset = (TextAsset)Resources.Load(
                                            ScenesParameters.LevelsDirectory +
                                            '/' + ScenesParameters.Section +
                                             '/' + filename);
        
        System.IO.StringReader stringReader = new System.IO.StringReader(textAsset.text);
        System.Xml.XmlReader reader = System.Xml.XmlReader.Create(stringReader);

        return (Level)serializer.Deserialize(reader);
    }

    public void makeLevel(Level level)
    {
        var serializationFile = Path.Combine(Directory.GetCurrentDirectory(), 
                                            ScenesParameters.LevelsDirectory + Path.DirectorySeparatorChar 
                                            + ScenesParameters.Section + 
                                            Path.DirectorySeparatorChar + ScenesParameters.LevelName 
                                            + ScenesParameters.LevelsNumber + ".xml");

        using (var writer = XmlWriter.Create(serializationFile))
        {
            serializer.Serialize(writer, level);
        }
    }

    public void makeLevelTest()
    {
        var ball = new Ball(1, 1, "1");
        var basket = new Basket(1, 1, 1);
        var obs = new ObsticleTriangle(1, 1, 1);

        Level level = new Level(ball, basket, obs);

        makeLevel(level);
    }
}

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Scripts.Saving
{
    public static class SerializationManager
    {
        public static void Save(string saveName, object saveData)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            if (!Directory.Exists(Utilities.Utilities.savePath))
            {
                Directory.CreateDirectory(Utilities.Utilities.savePath);

            }

            string path = Utilities.Utilities.savePath + saveName + ".save";

            FileStream file = File.Create(path);

            binaryFormatter.Serialize(file, saveData);

            file.Close();
        }

        public static object Load(string path)
        {
            if (!File.Exists(path))
            {
                return null;
            }

            BinaryFormatter binaryFormatter = new BinaryFormatter();

            FileStream file = File.Open(path, FileMode.Open);

            object save = binaryFormatter.Deserialize(file);
            file.Close();
            return save;
        }
    }
}
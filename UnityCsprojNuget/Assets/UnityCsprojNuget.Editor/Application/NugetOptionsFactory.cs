using System;
using System.IO;
using System.Xml.Serialization;
using UnityCsprojNuget.Editor.Domain;
using UnityEngine;

namespace UnityCsprojNuget.Editor.Application
{
    public sealed class NugetOptionsFactory : INugetOptionsFactory
    {
        public void Save(NugetOptions options)
        {
            var serializer = new XmlSerializer(typeof(NugetOptions));

            using (var file = new StreamWriter(NugetOptions.CreateDefaultPath()))
            {
                serializer.Serialize(file, options);
            }
        }

        public NugetOptions LoadFromFile()
        {
            var serializer = new XmlSerializer(typeof(NugetOptions));

            try
            {
                using (var file = File.Open(NugetOptions.CreateDefaultPath(), FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    return (NugetOptions)serializer.Deserialize(file);
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);

                Debug.Log("Saving default file");

                var options = new NugetOptions();

                Save(options);

                return options;
            }
        }

        public static INugetOptionsFactory CreateDefault() => new NugetOptionsFactory();
    }
}
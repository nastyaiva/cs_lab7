using System;
using System.IO;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Xml.Linq;
using AnimalLibrary;

class Program
{
    static void Main()
    {
        Animal[] animals = { new Cow(), new Lion(), new Pig() };
        XElement xml = new XElement("Animals");

        foreach (var animal in animals)
        {
            var type = animal.GetType();
            var commentAttr = (CommentAttribute)Attribute.GetCustomAttribute(type, typeof(CommentAttribute));

            XElement animalElement = new XElement("Animal",
                new XElement("Type", type.Name),
                new XElement("Country", animal.Country),
                new XElement("HideFromOtherAnimals", animal.HideFromOtherAnimals),
                new XElement("FavoriteFood", animal.GetFavouriteFood()),
                new XElement("Classification", animal.GetClassificationAnimal()),
                new XElement("Comment", commentAttr?.Description)
            );

            xml.Add(animalElement);
        }
        File.WriteAllText("animals.xml", xml.ToString());
        Console.WriteLine("XML файл с животными создан.");
    }
}
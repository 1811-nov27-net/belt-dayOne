using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializationAndAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            //var list = GetPeople();
            Task<List<Person>> listTask = DeserializeFromFileAsync(@"C:\revature\belt-dayOne\week1\day5\SerializationAndAsync\Data.xml");
            List<Person> list = listTask.Result;
            list[0].id *= 2;
            Console.WriteLine(list[0].name.firstName);
            SerializeToFile(@"C:\revature\belt-dayOne\week1\day5\SerializationAndAsync\Data.xml", list);
        }

        private static void SerializeToFile(string fileName, List<Person> people)
        {
            var serializer = new XmlSerializer(typeof(List<Person>));

            FileStream fileStream = null;
            try
            {
                fileStream = new FileStream(fileName, FileMode.Create);

                serializer.Serialize(fileStream, people);
            }
            catch (IOException e)
            {
                Console.WriteLine($"Some error in file I/O: {e.Message}");
            }
            finally
            {
                fileStream?.Dispose();
            }
        }

        public static async Task<List<Person>> DeserializeFromFileAsync(string fileName)
        {
            var serializer = new XmlSerializer(typeof(List<Person>));
            List<Person> result = new List<Person>();

            using (var memoryStream = new MemoryStream())
            {
                using (var fileStream = new FileStream(fileName, FileMode.Open))
                {
                    await fileStream.CopyToAsync(memoryStream);
                }
                memoryStream.Position = 0;
                result = (List<Person>)serializer.Deserialize(memoryStream);
            }
            return result;
        }

        static List<Person> GetPeople()
        {
            return new List<Person>
            {
                new Person
                {
                    id = 3,
                    name = new Name
                    {
                        firstName = "William",
                        middleName = "Wortham",
                        lastName = "Belt"
                    },
                    address = new Address
                    {
                        street = "709 W Cooper",
                        city = "Arlington",
                        state = "Texas",
                        country = "USA"
                    },
                    age = 30,
                    nicknames = new List<string> {"Will", "Liam"}
                }
            };
        }
    }
}

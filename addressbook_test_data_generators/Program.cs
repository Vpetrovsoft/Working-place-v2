using System;
using System.Collections.Generic;
using System.IO;
using WebAddressbookTests;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            // 4 аргумента которые необходимо передать при генерации:
            // Тип данных contacts или groups:
            string dataType = args[0];
            // количество сгенерированных экземпляров:
            int count = Convert.ToInt32(args[1]);
            // Куда будет записано:
            StreamWriter writer = new StreamWriter(args[2]);
            // Формат файла:
            string format = args[3];

            if (dataType == "groups")
            {
                List<GroupData> groups = new List<GroupData>();
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData()
                    {
                        Name = TestBase.GenerateRandomString(10),
                        Header = TestBase.GenerateRandomString(10),
                        Footer = TestBase.GenerateRandomString(10)
                    });
                }
                if (format == "csv")
                {
                    WriteGroupsToCsvFile(groups, writer);
                }
                else if (format == "xml")
                {
                    WriteGroupsToXmlFile(groups, writer);
                }
                else if (format == "json")
                {
                    WriteGroupsToJsonFile(groups, writer);
                }
                else
                {
                    Console.WriteLine($"Неизвестный формат {format}");
                }

                writer.Close();
            }

            else if (dataType == "contacts")
            {
                List<ContactForm> contacts = new List<ContactForm>();
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactForm()
                    {
                        LastName = TestBase.GenerateRandomString(6),
                        FirstName = TestBase.GenerateRandomString(6),
                        MiddleName = TestBase.GenerateRandomString(6),
                        NickName = TestBase.GenerateRandomString(6),
                        Title = TestBase.GenerateRandomString(6),
                        Company = TestBase.GenerateRandomString(6),
                        Address = TestBase.GenerateRandomString(6),
                        THome = TestBase.GenerateRandomPhoneNumber(),
                        TMobile = TestBase.GenerateRandomPhoneNumber(),
                        TWork = TestBase.GenerateRandomPhoneNumber(),
                        TFax = TestBase.GenerateRandomPhoneNumber(),
                        Email = $"{TestBase.GenerateRandomString(8)}@mail.ru",
                        Email2 = $"{TestBase.GenerateRandomString(8)}@mail.ru",
                        Email3 = $"{TestBase.GenerateRandomString(8)}@mail.ru",
                        Homepage = $"{TestBase.GenerateRandomString(8)}.com",
                        BDay = TestBase.GenerateRandomDay(),
                        BMonth = TestBase.GenerateRandomMonth(),
                        BYear = TestBase.GenerateRandomYear(4),
                        ADay = TestBase.GenerateRandomDay(),
                        AMonth = TestBase.GenerateRandomMonth(),
                        AYear = TestBase.GenerateRandomYear(4),
                        SGroup = TestBase.GenerateRandomString(8),
                        SAddress = TestBase.GenerateRandomString(8),
                        SHome = TestBase.GenerateRandomPhoneNumber(),
                        SNotes = TestBase.GenerateRandomString(8)
                    });
                }
                if (format == "json")
                {
                    WriteContactsToJsonFile(contacts, writer);
                }
                else if (format == "xml")
                {
                    WriteContactsToXmlFile(contacts, writer);
                }
                else
                {
                    Console.WriteLine($"Неизвестный формат: {format}");
                }

                writer.Close();
            }
            else
            {
                Console.WriteLine($"Неизвестный формат: {format}");
                writer.Close();
            }
        }

        /// <summary>
        /// Записывает данные в Json файл для контактов
        /// </summary>
        /// <param name="contacts"></param>
        /// <param name="writer"></param>
        static void WriteContactsToJsonFile(List<ContactForm> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }

        /// <summary>
        /// Записывает данные в XML файл для контактов
        /// </summary>
        /// <param name="groups"></param>
        /// <param name="writer"></param>
        static void WriteContactsToXmlFile(List<ContactForm> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactForm>)).Serialize(writer, contacts);
        }

        /// <summary>
        /// Записывает данные в CSV файл для групп
        /// </summary>
        /// <param name="groups"></param>
        /// <param name="writer"></param>
        static void WriteGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }

        /// <summary>
        /// Записывает данные в XML файл для групп
        /// </summary>
        /// <param name="groups"></param>
        /// <param name="writer"></param>
        static void WriteGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            //Создаём новый сериализатор(указываем данные какого типа он будет сериализовывать),
            //затем в Serialize передаём (куда, что)
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        /// <summary>
        /// Записывает данные в JSON файл для групп
        /// </summary>
        /// <param name="groups"></param>
        /// <param name="writer"></param>
        static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }
    }
}

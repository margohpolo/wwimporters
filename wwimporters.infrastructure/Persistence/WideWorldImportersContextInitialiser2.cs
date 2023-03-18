using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using wwimporters.infrastructure.Helpers;

namespace wwimporters.infrastructure.Persistence
{
    public partial class WideWorldImportersContextInitialiser
    {
        public void Seed()
        {
            if (_context.People.Count() == 0)
            {
                Dictionary<string, PropertyInfo> dbSetDict = new Dictionary<string, PropertyInfo>();
                _context.GetDbSetProperties()
                    .ForEach(propInfo =>
                    {
                        string dbSetName = GetDbSetName(propInfo.GetValue(_context, null).ToString());
                        dbSetDict.Add(dbSetName, propInfo);
                    });
                SeedDataFromCsv(dbSetDict);
                //List<PropertyInfo> dbSetProperties = _context.GetDbSetProperties();
                //List<string> dbSetNames = dbSetProperties.Select(x => GetDbSetName(x.GetValue(_context, null).ToString())).ToList();
                //foreach (string dbSetName in dbSetNames)
                //{
                //    SeedDataFromCsv(dbSetName);
                //}
            }
        }

        private string GetDbSetName(string input)
        {
            return input.Substring(input.LastIndexOf('.') + 1).Trim(']');
        }

        private void SeedDataFromCsv(Dictionary<string, PropertyInfo> setDict)
        {
            //var setType = _context.GetType().GetProperties().Where(prop => prop == setDict["doStringNameLater"]).FirstOrDefault();
            //if (setType is null)
            //{
            //    Console.WriteLine("No setType found");
            //}
            //else
            //{
            //    DbSet<setType> currentSet = _context.peo;
            //}
        }

        //private void SeedDataFromCsv(string setName)
        //{
        //    Console.WriteLine($"setName: {setName}");
        //    Type? type = Assembly.GetExecutingAssembly()
        //        .GetTypes()
        //        .FirstOrDefault(t => t.Name.Contains(setName));
        //    if (type is not null)
        //    {
        //        DbSet setContent;
        //        var setContext = setContent.Set(type);
        //        Console.WriteLine($"type: {type.ToString()}");
        //    }
        //    else
        //    {
        //        Console.WriteLine("type is null");
        //    }
        //}




        private string CsvToJson()
        {

            return "";
        }

    }
}

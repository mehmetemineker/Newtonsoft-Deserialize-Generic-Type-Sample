using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeserializeGenericTypeSample
{
	static class Program
	{
		static void Main(string[] args)
		{
			Class1 class1 = new Class1();
			Class2 class2 = new Class2();

			class1.Class1Id = 1;
			class1.Class1Name = "Classs";
			class1.Test = "Testoo";

			class2.Class2Id = 123;
			class2.Class2Name = "asdasd";

			string jsonClass1 = JsonConvert.SerializeObject(class1, new JsonSerializerSettings()
			{
				TypeNameHandling = TypeNameHandling.All
			});

			string jsonClass2 = JsonConvert.SerializeObject(class2, new JsonSerializerSettings()
			{
				TypeNameHandling = TypeNameHandling.All
			});

			Console.WriteLine(jsonClass1);
			Console.WriteLine(jsonClass2);

			var settings = new JsonSerializerSettings()
			{
				Converters = new List<JsonConverter>()
				{
					new AbstractEntityConverter()
				}
			};

			var obj1 = JsonConvert.DeserializeObject<ModelBase>(jsonClass1, settings);
			var obj2 = JsonConvert.DeserializeObject<ModelBase>(jsonClass2, settings);

			Console.WriteLine(obj1.GetType().Name);
			Console.WriteLine(obj2.GetType().Name);

			Console.ReadKey();
		}
	}
}

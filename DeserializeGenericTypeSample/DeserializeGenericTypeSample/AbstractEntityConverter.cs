﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeserializeGenericTypeSample
{
	public class AbstractEntityConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(ModelBase);
		}

		public override object ReadJson(JsonReader reader,
			Type objectType, object existingValue, JsonSerializer serializer)
		{
			JObject item = JObject.Load(reader);
			var type = item["$type"].Value<string>();
			return item.ToObject(Type.GetType(type));
		}

		public override void WriteJson(JsonWriter writer,
			object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
}

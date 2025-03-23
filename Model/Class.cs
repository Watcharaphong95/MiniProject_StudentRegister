// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using Project.Model;
//
//    var class = Class.FromJson(jsonString);

namespace Project.Model
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Class
    {
        [JsonProperty("semester")]
        public string Semester { get; set; }

        [JsonProperty("year")]
        public string Year { get; set; }

        [JsonProperty("subjectName")]
        public string SubjectName { get; set; }

        [JsonProperty("subjectID")]
        public string SubjectId { get; set; }
    }

    public partial class Class
    {
        public static List<Class> FromJson(string json) => JsonConvert.DeserializeObject<List<Class>>(json, Project.Model.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this List<Class> self) => JsonConvert.SerializeObject(self, Project.Model.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}

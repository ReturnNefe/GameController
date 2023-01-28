using System.Text.Json.Serialization;

namespace GameController.Global
{
    public class Setting
    {
        public class Element<T>
        {
            [JsonPropertyName("content")]
            public T[]? Content { get; set; }

            [JsonPropertyName("style")]
            public string? Style { get; set; }
        }

        public class LayoutSetting
        {
            public class Button
            {
                [JsonPropertyName("text")]
                public string? Text { get; set; }

                [JsonPropertyName("key")]
                public string? Key { get; set; }

                [JsonPropertyName("style")]
                public string? Style { get; set; }
            }

            [JsonPropertyName("panel")]
            public Element<Element<Element<Button>?>?>? Panel { get; set; }
        }

        [JsonPropertyName("layout")]
        public LayoutSetting? Layout { get; set; }
    }
}
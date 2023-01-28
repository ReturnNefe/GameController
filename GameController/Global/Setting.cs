using System.Text.Json.Serialization;

namespace GameController.Global
{
    public class Setting
    {
        public class Element<T>
        {
            private T[] content = Array.Empty<T>();
            private string cssClass = "";
            private string style = "";

            [JsonPropertyName("content")]
            public T[] Content { get => content; set => content = value ?? Array.Empty<T>(); }
            
            [JsonPropertyName("class")]
            public string CssClass { get => cssClass; set => cssClass = value ?? ""; }

            [JsonPropertyName("style")]
            public string Style { get => style; set => style = value ?? ""; }
        }

        public class LayoutSetting
        {
            public class Button
            {
                private string text = "";
                private string key = "";
                private string cssClass = "";
                private string style = "";

                [JsonPropertyName("text")]
                public string Text { get => text; set => text = value ?? ""; }

                [JsonPropertyName("key")]
                public string Key { get => key; set => key = value ?? ""; }
                
                [JsonPropertyName("class")]
                public string CssClass { get => cssClass; set => cssClass = value ?? ""; }

                [JsonPropertyName("style")]
                public string Style { get => style; set => style = value ?? ""; }
            }

            private Element<Element<Element<Button>>> panel = new();

            [JsonPropertyName("panel")]
            public Element<Element<Element<Button>>> Panel { get => panel; set => panel = value ?? new(); }
        }

        private LayoutSetting layout = new();
        
        [JsonPropertyName("layout")]
        public LayoutSetting Layout { get => layout; set => layout = value ?? new(); }
    }
}
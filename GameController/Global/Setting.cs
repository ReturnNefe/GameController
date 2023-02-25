using System.Text.Json.Serialization;

namespace GameController.Global
{
    public class Setting
    {
        public class LayoutSetting
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

                [JsonPropertyName("autoColWidth")]
                public bool AutoColWidth { get; set; } = true;
            }

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
                
                [JsonPropertyName("autoColWidth")]
                public bool AutoColWidth { get; set; } = true;
            }

            public class DeviceSetting
            {
                private Element<Element<Element<Button>>> panel = new();

                [JsonPropertyName("panel")]
                public Element<Element<Element<Button>>> Panel { get => panel; set => panel = value ?? new(); }
            }

            private DeviceSetting mobileDevice = new();
            private DeviceSetting? desktopDevice = null;

            [JsonPropertyName("mobile")]
            public DeviceSetting MobileDevice { get => mobileDevice; set => mobileDevice = value ?? new(); }

            // Set to null to be same as MobileDevice
            [JsonPropertyName("desktop")]
            public DeviceSetting DesktopDevice { get => desktopDevice ?? MobileDevice; set => desktopDevice = value; }
        }

        private LayoutSetting layout = new();

        [JsonPropertyName("layout")]
        public LayoutSetting Layout { get => layout; set => layout = value ?? new(); }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NetSharp
{
    public class Message
    {
        public string? Text { get; set; }

        public DateTime DateTime { get; set; }

        public string? NickNameFrom { get; set; }
        public string? NickNameTo { get; set; }

        public string SerializeMessageToJson() => JsonSerializer.Serialize(this);

        public static Message? DeserializeFromJson(string message) => JsonSerializer.Deserialize<Message>(message);

        public void Print()
        {
            Console.WriteLine(ToString());
        }
        public override string ToString()
        {
            return $"{this.DateTime} Получено сообщение {this.Text} от {this.NickNameFrom}";
        }
    }
}

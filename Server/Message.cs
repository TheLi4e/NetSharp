using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NetSharp
{
    public enum Commands
    {
        Register,
        Delete
    }
    public class Message : ICloneable
    {
        public string? Text { get; set; }

        public Commands command { get; set; }

        public DateTime DateTime { get; set; }

        public string? NicknameFrom { get; set; }
        public string? NicknameTo { get; set; }

        public string SerializeMessageToJson() => JsonSerializer.Serialize(this);

        public static Message? DeserializeFromJson(string message) => JsonSerializer.Deserialize<Message>(message);

        public object Clone(string sendTo)
        {
            return new Message
            {
                Text = this.Text,
                DateTime = this.DateTime,
                NicknameFrom = this.NicknameFrom,
                NicknameTo = sendTo
            };
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"{this.DateTime} Получено сообщение {this.Text} от {this.NicknameFrom} для {this.NicknameTo}";
        }

        public object Clone()
        {
            return new Message
            {
                Text = this.Text,
                DateTime = this.DateTime,
                NicknameFrom = this.NicknameFrom,
                NicknameTo = this.NicknameTo
            };
        }
    }
}

using System.Runtime.Serialization;

namespace BestStories.Model
{
    [DataContract]
    public class Story
    {
        [DataMember(Name = "by")]
        public string PostedBy { get; set; }

        [DataMember(Name = "descendants")]
        public int CommentCount { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "kids")]
        public object[] Kids { get; set; }

        [DataMember(Name = "score")]
        public int Score { get; set; }

        [DataMember(Name = "time")]
        public double Time { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "url")]
        public string Uri { get; set; }
    }
}
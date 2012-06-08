namespace SilviaPlayer
{
    class Channel
    {
        public Channel(string name, string url)
        {
            Name = name;
            Url = url;
        }
        public string Name { get; private set; }
        public string Url { get; private set; }

        public override string ToString()
        {
            return Name;
        }
    }

    class AvailableChannels
    {
        public Channel[] GetChannels()
        {
            return new Channel[]
                       {
                           new Channel("TVR1 S1", "sop://broker.sopcast.com:3912/60706"),
                           new Channel("TVR1 S2", "sop://broker.sopcast.com:3912/112099"),

                           new Channel("TVR2 S1", "sop://broker.sopcast.com:3912/80620"),

                           new Channel("Antena1 S1", "sop://broker.sopcast.com:3912/80625"),
                           new Channel("Antena1 S2", "sop://broker.sopcast.com:3912/111718"),

                           new Channel("Antena3 S1", "sop://broker.sopcast.com:3912/74842"),
                           new Channel("Antena3 S2", "sop://broker.sopcast.com:3912/115507"),

                           new Channel("Realitatea S1", "sop://broker.sopcast.com:3912/74843"),
                           new Channel("Realitatea S2", "sop://broker.sopcast.com:3912/115506"),

                           new Channel("Protv S1", "sop://broker.sopcast.com:3912/80621"),
                           new Channel("Protv HD S2", "sop://broker.sopcast.com:3912/86738"),
                           new Channel("Protv S3", "sop://broker.sopcast.com:3912/111617"),
                           new Channel("Protv S4", "sop://broker.sopcast.com:3912/90686"),

                           new Channel("B1 S1", "sop://broker.sopcast.com:3912/74841"),
                       };
        }
    }
}

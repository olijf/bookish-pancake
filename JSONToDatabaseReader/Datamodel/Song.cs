using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace JSONToDatabaseReader.Datamodel
{
    [DataContract]
    public class Song : IRepositoryObject
    {
        /*{
            "Id": 190,
            "Name": "(Don't Fear) The Reaper",
            "Year": 1975,
            "Artist": "Blue Öyster Cult",
            "Shortname": "dontfearthereaper",
            "Bpm": 141,
            "Duration": 322822,
            "Genre": "Classic Rock",
            "SpotifyId": "5QTxFnGygVM4jFQiBovmRo",
            "Album": "Agents of Fortune"
        }
        */

        [DataMember]
        public virtual int Id { get; set; }

        [DataMember]
        public virtual string Name { get; set; }

        [DataMember]
        public virtual int? Year { get; set; }

        [DataMember]
        public virtual string Artist { get; set; }

        [DataMember]
        public virtual string Shortname { get; set; }

        [DataMember]
        public virtual int? Bpm { get; set; }

        [DataMember]
        public virtual int? Duration { get; set; }

        [DataMember]
        public virtual string Genre { get; set; }

        [DataMember]
        public virtual string SpotifyId { get; set; }

        [DataMember]
        public virtual string Album { get; set; }
    }
}

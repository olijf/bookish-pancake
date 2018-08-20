using System;
using System.Runtime.Serialization;

namespace JSONToDatabaseReader.Datamodel
{
    [DataContract]
    public class Artist
    {
        /*
         * 		"Id": 760, "Name": "\"Weird Al\" Yankovic"
         */

        [DataMember]
        public virtual int Id { get; set; }


        [DataMember]
        public virtual string Name { get; set; }
    }
}

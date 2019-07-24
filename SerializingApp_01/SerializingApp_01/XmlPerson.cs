using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializingApp_01
{
    [Serializable]
    public class XmlPerson
    {
        [XmlElement]
        public string FirstName { get; set; }
        [XmlElement]
        public string LastName { get; set; }
        [XmlElement]
        public string Age { get; set; }
    }
}

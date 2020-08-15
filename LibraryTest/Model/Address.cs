using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryTest.Model
{
    public class Address
    {
        [BsonId]
        public int ID { get; set; }
        public string ADD { get; set; }
        public string ADD_DETAIL { get; set; }
        public string ZIP_NO { get; set; }
        public string POST_NO { get; set; }
    }
}

using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryTest.Model
{
    public class Member
    {
        [BsonId]
        public int ID { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
    }
}

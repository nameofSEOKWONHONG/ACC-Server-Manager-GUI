using LibraryTest.Model;
using NUnit.Framework;

using HigLabo.Core;

namespace LibraryTest
{
    public class HigLaboMapperTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            
            var member = new Member();
            member.Name = "홍길동";
            var addres = new Address();
            addres.ADD = "서울시 강서구 면목동 한신아파트1차";
            addres.ADD_DETAIL = "501동 201호";
            addres.POST_NO = "28709";
            addres.ZIP_NO = "32988";
            member.Address = addres;

            var tempAddres = member.Address.Map(new Address());

            Assert.AreEqual("28709", tempAddres.POST_NO);

            var newMember = member.Map(new Member());

            Assert.AreEqual("홍길동", newMember.Name);
            Assert.NotNull(newMember.Address);

            Assert.Pass();
        }
    }
}
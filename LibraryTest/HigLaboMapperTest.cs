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
            member.Name = "ȫ�浿";
            var addres = new Address();
            addres.ADD = "����� ������ ��� �ѽž���Ʈ1��";
            addres.ADD_DETAIL = "501�� 201ȣ";
            addres.POST_NO = "28709";
            addres.ZIP_NO = "32988";
            member.Address = addres;

            var tempAddres = member.Address.Map(new Address());

            Assert.AreEqual("28709", tempAddres.POST_NO);

            var newMember = member.Map(new Member());

            Assert.AreEqual("ȫ�浿", newMember.Name);
            Assert.NotNull(newMember.Address);

            Assert.Pass();
        }
    }
}
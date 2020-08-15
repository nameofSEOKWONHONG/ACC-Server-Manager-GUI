using LibraryTest.Model;
using LiteDB;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using JDotnetExtension;

namespace LibraryTest
{
    public class LiteDbTest
    {
        private LiteDatabase _database; // DB 선언
        private ILiteCollection<Member> _members; // 데이터를 담을 컬렉션 선언
        [SetUp]
        public void Setup()
        {
            var executePath = "temp.db".jToAppPath();
            _database = new LiteDatabase(executePath); // 지정된 경로로 초기화
            _members = _database.GetCollection<Member>("members");
        }

        #region [test code]
        [Test]
        public void AddMemerTest()
        {
            var newMember = new Member()
            {
                Name = "홍길동",
                Address = new Address()
                {
                    ADD = "test1",
                    ADD_DETAIL = "test2",
                    POST_NO = "1",
                    ZIP_NO = "1"
                }
            };

            var result = _members.Insert(newMember);
            // Create an index over the Field name (if it doesn't exist)
            _members.EnsureIndex(x => x.Name);

            Assert.Pass();
        }

        [Test]
        public void GetMembersTest()
        {
            var members = GetMembers();
            Assert.Greater(members.jCount(), 0);
        }

        [Test]
        public void UpdateMemberTest()
        {
            var members = GetMembers();
            var member = members.jLast();
            if (member.jIsNotNull())
            {
                member.Name = "김길동";
                bool result = _members.Update(member);
                var updatedMember = _members.Find(m => m.Name == "김길동").jFirst();

                Assert.AreEqual("김길동", updatedMember.Name);
            }
        }

        [Test]
        public void SameMemberTest()
        {
            var members = GetMembers();
            var firstMember = members.jFirst();
            var lastMember = members.jLast();

            Assert.AreEqual(firstMember.Name, lastMember.Name);
        }

        [Test]
        public void DeleteMemberTest()
        {
            var members = GetMembers();
            var member = members.jFirst(m => m.Name == "홍길동");

            if(member.jIsNotNull())
            {
                _members.Delete(member.ID);
                var deletedMember = _members.Find(m => m.Name == "홍길동").FirstOrDefault();
                Assert.IsNull(deletedMember);
            }
        }
        #endregion

        #region [biz code]
        private List<Member> GetMembers()
        {
            var members = _members.FindAll().jToList();
            return members;
        }
        #endregion





    }
}

using MyWorld.DTO;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWorld.MemberHelper
{
    public class MemberDatabase
    {
        readonly SQLiteAsyncConnection database;
        public MemberDatabase(string path)
        {
            database = new SQLiteAsyncConnection(path);
            database.CreateTableAsync<Member>().Wait();
        }
        public Task<List<Member>> GetAllMember()
        {
            return database.Table<Member>().ToListAsync();
        }
        public Task<Member> GetMember(int id)
        {
            return database.Table<Member>().Where(e => e.Id == id).FirstOrDefaultAsync();
        }
        public Task<int> SaveMember(Member member)
        {
            if (member.Id != 0)
            {
                return database.UpdateAsync(member);
            }
            else
            {
                return database.InsertAsync(member);
            }
        }
        public Task<int> DeleteMember(Member member)
        {
            return database.DeleteAsync(member);
        }
    }
}

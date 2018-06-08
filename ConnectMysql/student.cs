using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectMysql
{
    public class student
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public int GENDER { get; set; }
        public string ADDRESS { get; set; }

        public student(int ID, string NAME, int GENDER, string ADDRESS)
        {
            this.ID = ID;
            this.NAME = NAME;
            this.GENDER = GENDER;
            this.ADDRESS = ADDRESS;
        }
        public student() { }

        public virtual List<student> Select(int ID=0)
        {
            var sql = "SELECT * FROM student ";
            if (ID == 0) return MysqlManager<student>.ExecuteReader(sql);
            sql +=" WHERE ID=@ID";

            return MysqlManager<student>.ExecuteReader(sql, new { ID = ID});
        }

        public virtual List<student> SelectPaging(int start=0, int end=10)
        {
            var sql = "SELECT * FROM student LIMIT @start, @end;";

            return MysqlManager<student>.ExecuteReader(sql, new { start=start, end = end});
        }

        public virtual int GetCount()
        {
            var sql = "SELECT COUNT(1) AS CNT FROM student;";
            var result = MysqlManager<student>.ExecuteScalar(sql);
            return Convert.ToInt32(result);
        }

        public virtual int Insert(string NAME,int GENDER,string ADDRESS)
        {
            var sql = "INSERT INTO student(NAME,GENDER,ADDRESS) VALUES(@NAME,@GENDER,@ADDRESS)";
            return MysqlManager<student>.Execute(sql, new { NAME = NAME,GENDER = GENDER,ADDRESS = ADDRESS});
        }

        public virtual int Update(int ID, string NAME, int GENDER, string ADDRESS)
        {
            var sql = "UPDATE student SET NAME=@NAME,GENDER=@GENDER,ADDRESS=@ADDRESS WHERE ID=@ID";

            return MysqlManager<student>.Execute(sql,  new { ID = ID,NAME = NAME,GENDER = GENDER,ADDRESS = ADDRESS});
        }

        public virtual int UpdateColumn(int ID, string COLUMN, string VALUE)
        {
            var sql =string.Format(@"UPDATE student SET {0}=@VALUE WHERE ID=@ID", COLUMN);

            return MysqlManager<student>.Execute(sql, new { ID = ID, VALUE = VALUE });
        }

        public virtual int Delete(int ID=0)
        {
            var sql = "DELETE FROM student ";
            if (ID == 0) return MysqlManager<student>.Execute(sql);
            sql += " WHERE ID=@ID ";
            return MysqlManager<student>.Execute(sql, new { ID = ID });
        }


    }

   
}

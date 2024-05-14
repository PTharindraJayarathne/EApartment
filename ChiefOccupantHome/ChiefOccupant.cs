using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ChiefOccupantHome
{
    internal class ChiefOccupant
    {
        public int CH_ID { get; set; }
        public string Name { get; set; }
        public string NIC { get; set; }
        public string PassportNo { get; set; }
        public string Nationality { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
        public string Occupation { get; set; }
        public string MobileNo1 { get; set; }
        public string MobileNo2 { get; set; }
        public string Landline { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }

    //public void SaveCh(ChiefOccupant Ch)
    //{

    //    string sql = "insert into ChiefOccupant_Table (Name,NIC,PassportNo,Nationality,Country,Gender,Occupation,MobileNo1,MobileNo2,Landline,Email,Address) values  " +
    //        "('" + Ch.Name + "'," + Ch.NIC + ",'" + Ch.PassportNo + "','" + Ch.Nationality + "','" + Ch.Country + "','" + Ch.Gender + "','" + Ch.Occupation + "'," +
    //        "'" + Ch.MobileNo1 + "','" + Ch.MobileNo2 + "','" + Ch.Landline + "','" + Ch.Email + "','" + Ch.Address + "')";
    //    Data.ExecuteQuery(sql);
    //}
}

//    public void UpdateEmp(Employee emp)
//    {
//        string sql = "update employee set Name='" + emp.Name + "',Salary=" + emp.Salary +
//            ",dob='" + emp.Dob + "',deptCode='" + emp.DeptCode + "' where empno='" + emp.EmpNo + "'";

//        Data.ExecuteQuery(sql);
//    }

//    public void DeleteEmp(Employee emp)
//    {
//        string sql = "delete from employee where empno=" + emp.EmpNo;
//        Data.ExecuteQuery(sql);
//    }
//}

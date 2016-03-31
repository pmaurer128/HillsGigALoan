using GigaLoan_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GigALoanService
{
    public class GigALoanService : IGigALoanService
    {
        public string GetName()
        {
            return "First Web Service Twice";
        }

        public string GetFirstCollege()
        {
            using(GigALoan_DAL.DB_42039_gigaloanEntities context = new GigALoan_DAL.DB_42039_gigaloanEntities())
            {
                var college = context.SPRT_Colleges.First();

                return college.CollegeName;
            }
        }

        public List<DTO_College> GetColleges()
        {
            List<DTO_College> returnList = new List<DTO_College>();
            
            using(GigALoan_DAL.DB_42039_gigaloanEntities context = new GigALoan_DAL.DB_42039_gigaloanEntities())
            {
                var list = context.SPRT_Colleges.Take(10).ToList();

                foreach( var c in list)
                {
                    var collegeObject = new DTO_College();
                    
                    collegeObject.CollegeID = c.CollegeID;
                    collegeObject.CollegeName = c.CollegeName;

                    returnList.Add(collegeObject);
                }
            }

            return returnList;
        }

        public List<DTO_College> GetCollege(DTO_College token)
        {
            List<DTO_College> returnList = new List<DTO_College>();

            using (GigALoan_DAL.DB_42039_gigaloanEntities context = new GigALoan_DAL.DB_42039_gigaloanEntities())
            {
                var list = context.SPRT_Colleges.Where(c=>c.CollegeID == token.CollegeID).ToList();

                foreach (var c in list)
                {
                    var collegeObject = new DTO_College();

                    collegeObject.CollegeID = c.CollegeID;
                    collegeObject.CollegeName = c.CollegeName;

                    returnList.Add(collegeObject);
                }
            }

            return returnList;
        }
    }
}

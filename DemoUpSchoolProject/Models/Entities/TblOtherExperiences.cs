//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoUpSchoolProject.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblOtherExperiences
    {
        public int ExperienceID { get; set; }
        public string ExperienceTitle { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string OrgnizationName { get; set; }
        public string ImageUrl { get; set; }
        public Nullable<int> MemberID { get; set; }
    
        public virtual TblMember TblMember { get; set; }
        public virtual TblOtherExperiences TblOtherExperiences1 { get; set; }
        public virtual TblOtherExperiences TblOtherExperiences2 { get; set; }
    }
}

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
    
    public partial class TblLatestWorks
    {
        public int ProjectID { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectType { get; set; }
        public string ProjectImage { get; set; }
        public string ProjectDescription { get; set; }
        public Nullable<System.DateTime> ProjectDate { get; set; }
        public Nullable<int> MemberID { get; set; }
        public string GithubLink { get; set; }
    
        public virtual TblLatestWorks TblLatestWorks1 { get; set; }
        public virtual TblLatestWorks TblLatestWorks2 { get; set; }
        public virtual TblMember TblMember { get; set; }
    }
}
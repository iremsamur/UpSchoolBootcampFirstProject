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
    
    public partial class TblEducationInformations
    {
        public int EducationInformationID { get; set; }
        public string EducationOrganizationName { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
        public Nullable<int> MemberID { get; set; }
    
        public virtual TblEducationInformations TblEducationInformations1 { get; set; }
        public virtual TblEducationInformations TblEducationInformations2 { get; set; }
        public virtual TblMember TblMember { get; set; }
    }
}
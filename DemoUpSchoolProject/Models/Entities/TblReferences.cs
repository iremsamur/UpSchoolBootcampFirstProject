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
    
    public partial class TblReferences
    {
        public int ReferenceID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string EMail { get; set; }
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public Nullable<int> MemberID { get; set; }
        public string Comment { get; set; }
        public string Image { get; set; }
    
        public virtual TblMember TblMember { get; set; }
    }
}

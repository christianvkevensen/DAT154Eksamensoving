//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPF_Application_DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class grade
    {
        public int studentid { get; set; }
        public string coursecode { get; set; }
        public string grade1 { get; set; }
    
        public virtual course course { get; set; }
        public virtual student student { get; set; }
    }
}

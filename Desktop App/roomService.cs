//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Desktop_App
{
    using System;
    using System.Collections.Generic;
    
    public partial class roomService
    {
        public int roomNr { get; set; }
        public System.DateTime requestTime { get; set; }
        public string reqStatus { get; set; }
        public string note { get; set; }
    
        public virtual room room { get; set; }
    }
}

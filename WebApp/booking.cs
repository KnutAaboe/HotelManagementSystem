//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class booking
    {
        public int ID { get; set; }
        public string phoneNr { get; set; }
        public int roomNr { get; set; }

        //System.DateTime

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public System.DateTime startTime { get; set; }

        //System.DateTime
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public System.DateTime endTime { get; set; }
    
        public virtual guest guest { get; set; }
        public virtual room room { get; set; }


        //Nylig lagt til
        public int RoomId { get; set; }

        public string GuestName { get; set; }
    }
}

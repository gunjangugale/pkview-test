//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace iPortal.App_Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class IPORTAL_SCALE
    {
        public IPORTAL_SCALE()
        {
            this.IPORTAL_FP = new HashSet<IPORTAL_FP>();
        }
    
        public int SCALE_ID { get; set; }
        public string CODE { get; set; }
    
        public virtual ICollection<IPORTAL_FP> IPORTAL_FP { get; set; }
    }
}

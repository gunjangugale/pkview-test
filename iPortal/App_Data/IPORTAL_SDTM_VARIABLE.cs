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
    
    public partial class IPORTAL_SDTM_VARIABLE
    {
        public IPORTAL_SDTM_VARIABLE()
        {
            this.IPORTAL_VARIABLE_MAPPING = new HashSet<IPORTAL_VARIABLE_MAPPING>();
        }
    
        public int SDTM_VARIABLE_ID { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public string LONG_DESCRIPTION { get; set; }
    
        public virtual ICollection<IPORTAL_VARIABLE_MAPPING> IPORTAL_VARIABLE_MAPPING { get; set; }
    }
}

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
    
    public partial class ESAFETY_WORKFLOW
    {
        public int WORKFLOW_ID { get; set; }
        public string WORKFLOW_NAME { get; set; }
        public int PROJECT_ID { get; set; }
        public Nullable<int> ESAFETY_PROJECT2_PROJECT2_ID { get; set; }
    
        public virtual ESAFETY_PROJECT ESAFETY_PROJECT { get; set; }
        public virtual ESAFETY_PROJECT2 ESAFETY_PROJECT2 { get; set; }
    }
}

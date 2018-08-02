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
    
    public partial class IPORTAL_STUDY
    {
        public IPORTAL_STUDY()
        {
            this.IPORTAL_DM_DATASET = new HashSet<IPORTAL_DM_DATASET>();
            this.IPORTAL_EX_DATASET = new HashSet<IPORTAL_EX_DATASET>();
            this.IPORTAL_PC_DATASET = new HashSet<IPORTAL_PC_DATASET>();
            this.IPORTAL_PP_DATASET = new HashSet<IPORTAL_PP_DATASET>();
            this.IPORTAL_STUDY1 = new HashSet<IPORTAL_STUDY>();
        }
    
        public int STUDY_ID { get; set; }
        public string STUDY_CODE { get; set; }
        public string EDR_LINK { get; set; }
        public Nullable<System.DateTime> START_DATE { get; set; }
        public Nullable<System.DateTime> END_DATE { get; set; }
        public string SCREENING_DAY { get; set; }
        public string WASHOUT_DAY { get; set; }
        public string SAMPLING_TIME { get; set; }
        public int STUDY_TYPE_ID { get; set; }
        public int STUDY_DESIGN_ID { get; set; }
        public Nullable<int> PARENT_STUDY_ID { get; set; }
        public int SUBMISSION_ID { get; set; }
    
        public virtual ICollection<IPORTAL_DM_DATASET> IPORTAL_DM_DATASET { get; set; }
        public virtual ICollection<IPORTAL_EX_DATASET> IPORTAL_EX_DATASET { get; set; }
        public virtual ICollection<IPORTAL_PC_DATASET> IPORTAL_PC_DATASET { get; set; }
        public virtual ICollection<IPORTAL_PP_DATASET> IPORTAL_PP_DATASET { get; set; }
        public virtual ICollection<IPORTAL_STUDY> IPORTAL_STUDY1 { get; set; }
        public virtual IPORTAL_STUDY IPORTAL_STUDY2 { get; set; }
        public virtual IPORTAL_STUDY_TYPE IPORTAL_STUDY_TYPE { get; set; }
        public virtual IPORTAL_STUDY_DESIGN IPORTAL_STUDY_DESIGN { get; set; }
        public virtual IPORTAL_SUBMISSION IPORTAL_SUBMISSION { get; set; }
    }
}
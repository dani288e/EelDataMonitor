//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EelDataMonitor.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sensor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sensor()
        {
            this.SensorDatas = new HashSet<SensorData>();
        }
    
        public int ID { get; set; }
        public int BassinID { get; set; }
        public string IPAddress { get; set; }
    
        public virtual Bassin Bassin { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SensorData> SensorDatas { get; set; }
    }
}

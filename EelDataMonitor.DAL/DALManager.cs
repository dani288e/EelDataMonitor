using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EelDataMonitor.DAL
{
    public class DALManager
    {
        public List<SensorData> GetSesnsorDatas(List<SensorData> sensorDatas)
        {
            using (Ringsted1Entities context = new Ringsted1Entities())
            {
                DateTime dateCriteria = DateTime.Now.AddDays(-30);

                var query = (from o in context.SensorDatas
                             select o).ToList();
                if (query != null)
                {
                    foreach (var result in query)
                    {
                        sensorDatas.Add(result);
                    }
                }
            }
            return sensorDatas;
        }
    }
}

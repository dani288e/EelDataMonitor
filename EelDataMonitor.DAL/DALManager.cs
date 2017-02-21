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

        public bool CreateBassin(Bassin record, int hallid)
        {
            using (Ringsted1Entities context = new Ringsted1Entities())
            {
                Bassin query = (from o in context.Bassins
                                where o.HallID == record.HallID
                                select o).FirstOrDefault();

                if (query == null)
                {
                    Bassin bassinE = new Bassin();
                    bassinE.HallID = hallid;
                    context.Bassins.Add(bassinE);
                    try
                    {
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw;

                        //LoggerSingleton.Instance.Log("An exception occurred when attempting to save a new bassin to the database: ", ex);
                    }
                }
            }
            return true;
        }
    }
}

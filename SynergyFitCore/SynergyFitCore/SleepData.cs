using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SynergyFitCore
{
    public class SleepData
    {
        private string _displayName;
        private Dictionary<DateTime, int> _dataDictionary;
        private bool _endSensor;

        public SleepData(string displayName)
        {
            _displayName = displayName;
            _dataDictionary = new Dictionary<DateTime, int>();
        }

        public string DisplayName
        {
            get
            {
                return _displayName;
            }
            set
            {
                _displayName = value;
            }
        }

        public Dictionary<DateTime, int> DataDictionary
        {
            get
            {
                return _dataDictionary;
            }
            set
            {
                _dataDictionary = value;
            }
        }

        public void StartSensorLoop()
        {
            _endSensor = false;
            Task.Run(() =>
            {
                while (_endSensor == false)
                {
                    Thread.Sleep(1000);
                    DataDictionary.Add(DateTime.Now, new Random().Next());
                }
            });
        }

        public void EndSensorLoop()
        {
            _endSensor = true;
        }

        public Dictionary<DateTime, int> ReturnDataRequest(DateTime fromDate, DateTime toDate)
        {
            Dictionary<DateTime, int> keyValuePairs = new Dictionary<DateTime, int>();
            foreach (var item in DataDictionary)
            {
                if (item.Key.Ticks > fromDate.Ticks && item.Key.Ticks < toDate.Ticks)
                {
                    keyValuePairs.Add(item.Key, item.Value);
                }
            }

            return keyValuePairs;
        }

    }
}

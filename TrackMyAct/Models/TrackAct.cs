﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace TrackMyAct.Models
{
    public class TrackAct
    {
        public static RootObjectTrackAct trackactDataDeserializer(string response)
        {
            RootObjectTrackAct rtrackact = JsonConvert.DeserializeObject<RootObjectTrackAct>(response);
            return rtrackact;
        }

        public static string trackactSerializer(RootObjectTrackAct rtrackact)
        {
            string response = JsonConvert.SerializeObject(rtrackact);
            return response;
        }
    }

    [DataContract]
    public class TimerData
    {
        [DataMember]
        public long time_in_seconds { get; set; }
        [DataMember]
        public int position { get; set; }   // keep track of in which order the position was added.
        [DataMember]
        public bool oldest { get; set; }   // set to true if it is the oldest. It'll be the first to be re-written if it is.
    }

    [DataContract]
    public class ActivityData
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string median { get; set; }
        [DataMember]
        public string ninetypercentile { get; set; }
        [DataMember]
        public int current_count { get; set; }
        [DataMember]
        public string personal_best { get; set; }
        [DataMember]
        public List<TimerData> timer_data { get; set; }
    }

    [DataContract]
    public class RootObjectTrackAct
    {
        [DataMember]
        public List<ActivityData> activity { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZDC.Discord.Data
{
    public class Constants
    {
        public static ulong HomeControllerRole = 507976410321911848;
        public static ulong VisitingControllerRole = 507970040310792224;
        public static ulong ObsRole = 561034693634686976;
        public static ulong S1Role = 561034693412257822;
        //Todo set back to S2 role id
        //public static ulong S2Role = 561034693097553930;
        public static ulong S2Role = 787174525250043924;
        public static ulong S3Role = 561034692749557812;
        public static ulong C1Role = 561034692506419200;
        public static ulong C3Role = 561034691830874133;
        public static ulong I1Role = 561034691797450763;
        public static ulong I3Role = 561034691420094486;
        public static ulong SupRole = 475896028864970752;
        public static ulong MtrRole = 395385474950103041;
        public static ulong InsRole = 395387275607015445;

        public static List<ulong> RatingRoles = new List<ulong>
        {
            561034693634686976,
            561034693412257822,
            //561034693097553930,
            787174525250043924,
            561034692749557812,
            561034692506419200,
            561034691830874133,
            561034691797450763,
            561034691420094486,
            475896028864970752
        };

        public static List<ulong> TrainingRoles = new List<ulong>
        {
            395385474950103041,
            395387275607015445
        };

        public static List<ulong> ControllerRoles = new List<ulong>
        {
            507976410321911848,
            507970040310792224
        };
    }
}

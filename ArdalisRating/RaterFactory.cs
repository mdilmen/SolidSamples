using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating
{
    public class RaterFactory
    {
        public Rater Create(Policy policy, RatingEngine engine)
        {
            //switch (policy.Type)
            //{
            //    case PolicyType.Life:
            //        return new AutoPolicyRater(engine, engine.Logger);
            //    case PolicyType.Land:
            //        return new LandPolicyRater(engine, engine.Logger);
            //    case PolicyType.Auto:
            //        return new LifePolicyRater(engine, engine.Logger);
            //    case PolicyType.Flood:
            //        return new FloodPolicyRater(engine, engine.Logger);
            //    default:
            //        return null;                                       
            //}

            try
            {
                return (Rater)Activator.CreateInstance(
                    Type.GetType($"ArdalisRating.{policy.Type}PolicyRater"), new object[] { engine, engine.Logger });
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}

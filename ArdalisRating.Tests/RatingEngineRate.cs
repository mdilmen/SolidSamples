using Newtonsoft.Json;
using System;
using System.IO;
using Xunit;

namespace ArdalisRating.Tests
{
    public class RatingEngineRate
    {
        [Fact]
        public void ReturnsRatingFloodPolicy()
        {
            var policy = new Policy
            {
                Type = PolicyType.Flood,
                BondAmount = 200000,
                Valuation = 200000,
                ElevationAboveSeaLevelFeet = 200
            };
            string json = JsonConvert.SerializeObject(policy);
            File.WriteAllText("policy.json", json);

            var engine = new RatingEngine();
            engine.Rate();
            var result = engine.Rating;

            Assert.Equal(15000, result);
        }

        [Fact]
        public void ReturnsSimpleAutoPolicyFromValidJsonString()
        {
            var inputJson = @"{
                                  ""type"": ""Auto"",
                                  ""make"": ""BMW""
                                }
                                ";
            var serializer = new PolicySerializer();

            var result = serializer.GetPolicyFromJsonString(inputJson);

            var policy = new Policy { Type = PolicyType.Auto, Make = "BMW" };
            AssertPoliciesEqual(result, policy);
        }
        [Fact]
        public void ReturnsRatingOf10000For200000LandPolicy()
        {
            var policy = new Policy
            {
                Type = PolicyType.Land,
                BondAmount = 200000,
                Valuation = 200000
            };
            string json = JsonConvert.SerializeObject(policy);
            File.WriteAllText("policy.json", json);

            var engine = new RatingEngine();
            engine.Rate();
            var result = engine.Rating;

            Assert.Equal(10000, result);
        }

        [Fact]
        public void ReturnsRatingOf0For200000BondOn260000LandPolicy()
        {
            var policy = new Policy
            {
                Type = PolicyType.Land,
                BondAmount = 200000,
                Valuation = 260000
            };
            string json = JsonConvert.SerializeObject(policy);
            File.WriteAllText("policy.json", json);

            var engine = new RatingEngine();
            engine.Rate();
            var result = engine.Rating;

            Assert.Equal(0, result);
        }

        [Fact]
        public void ReturnDefaultPolicyFromEmptyJsonString()
        {
            var inputJson = "{}";
            var serializer = new PolicySerializer();

            var result = serializer.GetPolicyFromJsonString(inputJson);

            var policy = new Policy();
            //var policy3 = new Policy();
            AssertPoliciesEqual(result, policy);

        }
        private static void AssertPoliciesEqual(Policy result, Policy policy)
        {
            Assert.Equal(policy.Address, result.Address);
            Assert.Equal(policy.Amount, result.Amount);
            Assert.Equal(policy.BondAmount, result.BondAmount);
            Assert.Equal(policy.DateOfBirth, result.DateOfBirth);
            Assert.Equal(policy.Deductible, result.Deductible);
            Assert.Equal(policy.FullName, result.FullName);
            Assert.Equal(policy.IsSmoker, result.IsSmoker);
            Assert.Equal(policy.Make, result.Make);
            Assert.Equal(policy.Miles, result.Miles);
            Assert.Equal(policy.Model, result.Model);
            Assert.Equal(policy.Type, result.Type);
            Assert.Equal(policy.Valuation, result.Valuation);
            Assert.Equal(policy.Year, result.Year);

        }
    }
}

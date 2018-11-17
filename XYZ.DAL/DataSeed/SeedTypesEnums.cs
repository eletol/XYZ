namespace XYZ.DAL.DataSeed
{




    public static class ChallengeStatuses
    {


        public static readonly SeedType Active = new SeedType { Id = 1, Name = "Active" };
        public static readonly SeedType InActive = new SeedType { Id = 2, Name = "InActive" };


    }
    public static class BehaviorTypes
    {
        public static readonly SeedType AmountBased = new SeedType { Id = 1, Name = "AmountBased" };
        public static readonly SeedType ActionBased = new SeedType { Id = 2, Name = "ActionBased" };
        public static readonly SeedType ActionBasedAndAmountBased = new SeedType { Id = 3, Name = "ActionBasedAndAmountBased" };
        public static readonly SeedType HighScore = new SeedType { Id = 4, Name = "HighScore" };

    }
    public static class ActionTypes
    {
        public static readonly SeedType Default = new SeedType { Id = 1, Name = "Default" };
        public static readonly SeedType ValueDifference = new SeedType { Id = 2, Name = "ValueDifference" };


    }
    public static class TimeIntervalTypes
    {
        public static readonly SeedType Daily = new SeedType { Id = 1, Name = "Daily" };
        public static readonly SeedType Weekly = new SeedType { Id = 2, Name = "Weekly" };
        public static readonly SeedType Biweekly = new SeedType { Id = 3, Name = "Biweekly" };
        public static readonly SeedType Monthly = new SeedType { Id = 4, Name = "Monthly" };
        public static readonly SeedType Quarterly = new SeedType { Id = 5, Name = "Quarterly" };
        public static readonly SeedType FixedInterval = new SeedType { Id =6, Name = "FixedInterval" };


    }

    public static class TagStatuses
    {
        public static readonly SeedType Active = new SeedType { Id = 1, Name = "Active" };
        public static readonly SeedType InActive = new SeedType { Id = 2, Name = "InActive" };
    }

    public static class ActivationCriteriaTypes
    {
        public static readonly SeedType AlwaysOn = new SeedType { Id = 1, Name = "AlwaysOn" };
        public static readonly SeedType BasedOnXFrubies = new SeedType { Id = 2, Name = "BasedOnXFrubies" };
        public static readonly SeedType BasedOnSpecificLevel = new SeedType { Id = 3, Name = "BasedOnSpecificLevel" };

    }








    public class SeedType
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

  


    

  
}
namespace P08_MilitaryElite.Contracts
{
    using P08_MilitaryElite.Enumerations;

    public interface IMission
    {
        string CodeName { get; }

        State State { get; }

        void CompleteMission();
    }
}

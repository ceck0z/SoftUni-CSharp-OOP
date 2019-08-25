namespace P08_MilitaryElite.Contracts
{
    using P08_MilitaryElite.Enumerations;

    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }
    }
}

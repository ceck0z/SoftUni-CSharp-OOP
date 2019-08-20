namespace P03_Ferrari.Contracts
{
    public interface ICar
    {
        string Driver { get; set; }

        string UseBrakes();

        string PushTheGasPedal();
    }
}

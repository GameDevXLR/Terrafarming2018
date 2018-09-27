

public interface IConsommation  {
    int Conso { get; }
    int ConsoBoost { get; }
    void BoostConso();
    void StartConsommation();
    void StopConsommation();
    void FailConsommation();
}

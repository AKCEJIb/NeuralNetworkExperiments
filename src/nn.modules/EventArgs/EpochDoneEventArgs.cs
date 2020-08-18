namespace NeuroModule.Neuro
{
    public class EpochDoneEventArgs
    {
        public EpochDoneEventArgs(double error, long epoch)
        {
            Error = error;
            Epoch = epoch;
        }

        public double Error { get; }
        public long Epoch { get; }

    }
}
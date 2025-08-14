namespace ExerciseTracking
{
    public class Running : Activity
    {
        private double _distance;

        public Running(DateOnly date, int durationInMinutes, double distance) : base(date, durationInMinutes)
        {
            _distance = distance;
        }

        public override double GetDistance()
        {
            return _distance;
        }

        public override double GetSpeed()
        {
            return (_distance / GetDurationInMinutes()) * 60;
        }

        public override double GetPace()
        {
            return GetDurationInMinutes() / _distance;
        }
    }
}

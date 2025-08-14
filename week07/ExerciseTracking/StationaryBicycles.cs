namespace ExerciseTracking
{
    public class StationaryBicycles : Activity
    {
        private double _speed;

        public StationaryBicycles(DateOnly date, int durationInMinutes, double speed) : base(date, durationInMinutes)
        {
            _speed = speed;
        }

        public override double GetDistance()
        {
            return (_speed * GetDurationInMinutes()) / 60;
        }

        public override double GetSpeed()
        {
            return _speed;
        }

        public override double GetPace()
        {
            return 60 / _speed;
        }
    }
}

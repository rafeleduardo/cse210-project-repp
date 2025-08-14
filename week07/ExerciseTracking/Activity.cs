namespace ExerciseTracking
{
    public abstract class Activity
    {
        private DateOnly _date;
        private int _durationInMinutes;

        public Activity(DateOnly date, int durationInMinutes)
        {
            _date = date;
            _durationInMinutes = durationInMinutes;
        }

        protected int GetDurationInMinutes()
        {
            return _durationInMinutes;
        }
        
        public abstract double GetDistance();
        public abstract double GetSpeed();
        public abstract double GetPace();
        
        public virtual string GetSummary()
        {
            return $"{_date.ToString("dd MMM yyyy")} {GetType().Name} ({_durationInMinutes} min) - Distance: {GetDistance():F1} miles, Speed: {GetSpeed():F1} mph, Pace: {GetPace():F2} min per mile";
        }
    }
}

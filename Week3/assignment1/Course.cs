namespace assignment1
{
    public class Course
    {
        public string Name;
        public int Grade;
        public PracticalGrade Practical;

        public bool Passed()
        {
            if ((this.Grade >= 55) && ((int)this.Practical >= 3))
            {
                return true;
            }
            return false;
        }

        public bool CumLaude()
        {
            if ((this.Grade >= 80) && ((int)this.Practical == 4))
            {
                return true;
            }
            return false;
        }
    }

    public enum PracticalGrade
    {
        None, Absent, Insufficient, Sufficient, Good
    }

    
}

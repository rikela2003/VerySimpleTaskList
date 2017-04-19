namespace VerySimpleTaskList
{
    public class ReminderTask : Task 
    {
        public ReminderTask(string description, int numberofHours) : base(description)
        {
            _numberofHours = numberofHours;
        }

        public override string DescribeYourself()
        {
            string parentsDescription = base.DescribeYourself();
            return (parentsDescription + "and I will remind you in" + _numberofHours + "hour(s).");
        }

        private int _numberofHours;
    }
}

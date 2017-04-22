namespace SortingAlgorithmsPresenter.Models
{
    public class TimedResultModel
    {
        public string Name { get; set; }
        public string Time { get; set; }

        public TimedResultModel(string name, string time)
        {
            Name = name;
            Time = time;
        }
    }
}

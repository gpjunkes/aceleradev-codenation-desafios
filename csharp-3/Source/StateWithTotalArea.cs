namespace Source
{
    public class StateWithTotalArea
    {
        public StateWithTotalArea(string name, string acronym, double totalArea)
        {
            this.Name = name;
            this.Acronym = acronym;
            this.TotalArea = totalArea;
        }

        public string Name { get; set; }
        public string Acronym { get; set; }
        public double TotalArea { get; set; }
    }
}

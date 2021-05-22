namespace StoreModels
{
    /// <summary>
    /// This class should contain all the fields and properties that define a store location.
    /// </summary>
    public class Location
    {
        public string Address { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public Location() { }
        public Location(string name, string Address)
        {
            this.Name = name;
            this.Address = Address;

        }

        // Constructor chaining
      public Location(int id, string name, string Address) : this(name,Address)
        {
            this.Id = id;
        }


        public override string ToString()
        {
            //  return base.ToString();
            return $" LocationName: {Name} \t Address: {Address}";
        }
    }
}
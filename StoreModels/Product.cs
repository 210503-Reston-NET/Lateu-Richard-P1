namespace StoreModels
{
    /// <summary>
    ///  This class should contain all necessary fields to define a product.
    /// </summary>
    public class Product
    {

        public Product(){}

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Barcode { get; set; }
        public int AvailableStock{get;set;}

        //todo: add more properties to define a product (maybe a category?)
          public Product(string name,string barcode ,double price,int stock){
              this.Name=name;
              this.Barcode=barcode;
              this.Price=price;
              this.AvailableStock=stock;
          }

            public Product(int id,string name,double price,string barcode ,int stock):this(name,barcode ,price,stock){
              this.Id=id;
              this.Name=name;
              this.Barcode=barcode;
              this.Price=price;
              this.AvailableStock=stock;
          }
        

   public override string ToString()
        {
          //  return base.ToString();
             return $"Id:{Id} \tName: {Name} \t Barcode: {Barcode} \t Price Unit: {Price} \t Stock:{AvailableStock} \n";
        }
    }
}
namespace Parcial_02
{
    public class Product
    {
        public int idproduct{get; set;}
        public int idbiz{get; set;}
        
        public string prodname{get; set;}

        public Product()
        {
            idproduct = 0;
            idbiz = 0;
            prodname = "";
        }
    }
}
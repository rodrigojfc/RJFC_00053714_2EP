using System;
using System.Globalization;

namespace Parcial_02
{
    public class Order
    {
        public int idorder{get; set;}
        
        public int idprod { get; set; }
        
        public int idaddress{get; set;}
        
        public DateTime fecha{get; set;}


        public Order()
        {
            idaddress = 0;
            idprod = 0;
            idorder = 0;
            fecha  = new DateTime();
        }
        
    }
}
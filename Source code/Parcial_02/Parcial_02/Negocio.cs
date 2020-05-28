namespace Parcial_02
{
    public class Negocio
    {
      public string nombre {get; set ;}
      public string descripcion {get; set;}
      
      public int idneg { get; set; }

      public Negocio()
      {
          this.descripcion = "";
          this.nombre = "";
          this.idneg = 0;
      }
    }
    
    
}
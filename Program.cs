using System; 
namespace Juego
{
public interface Ipokemon{
    int Atacar();
    int Defender();
}

public class Pokemon : Ipokemon{
    private string Nombre;
    private string Tipo;
    private int Salud;
    private int[] Ataques = new int[3];
    private int[] Defensas = new int[2];
    private Random random = new Random();

    public Pokemon(string Nombre, string Tipo){
        this.Nombre = Nombre;
        this.Tipo = Tipo;
        this.Salud = 100;

        for(int i = 0; i < 3; i++){
            Ataques[i] = random.Next(0, 40);
        }
        
        for(int i = 0; i < 2; i++){
            Defensas[i] = random.Next(10, 35);
        }
    }

    public int Atacar(){
        int ataqueSele = Ataques[random.Next(0, 3)];
        double multiplicar = (random.Next(0, 2) == 0) ? 1 : 1.5;
        return(int)(ataqueSele * multiplicar);
    }

    public int Defender(){
        int defensaSele = Defensas[random.Next(0, 2)];
        double multiplicar = (random.Next(0, 2) == 0) ? 1 : 1.5;
        return(int)(defensaSele * multiplicar); 
    }
    public string getNombre(){
        return Nombre;
    }

    public string getTipo(){
        return Tipo;
    }

    public int getSalud(){
        return Salud;
    }

    public void RestarSalud(int cantidad){
        Salud -= cantidad;
        if(Salud < 0){
            Salud = 0;
        }
    }

}

class Juego{
    public static void Main(string[] args){
        Pokemon pokemon1 = CrearPokemon();
        Pokemon pokemon2 = CrearPokemon();

        for (int Turno = 1; Turno <= 3; Turno++){
            Console.WriteLine("Turno" + Turno);
            Console.WriteLine(pokemon1.getNombre() + " ataca a " + pokemon2.getNombre());
            int AtaqueUno = pokemon1.Atacar();
            int DefensaDos = pokemon2.Defender();
            if ( AtaqueUno > DefensaDos){
                int Diferencia = AtaqueUno - DefensaDos;
                pokemon2.RestarSalud(Diferencia);
                Console.WriteLine(pokemon2.getNombre() + " pierde " + Diferencia + " puntos de salud. ");
            } else {
                Console.WriteLine(pokemon2.getNombre() + " se defiende con exito. ");
            }

            Console.WriteLine(pokemon2.getNombre() + " ataca a " + pokemon1.getNombre());
            int AtaqueDos = pokemon2.Atacar();
            int DefensaUno = pokemon1.Defender();
            if (AtaqueDos > DefensaUno){
                int Diferencia = AtaqueDos - DefensaDos;
                pokemon1.RestarSalud(Diferencia);
                Console.WriteLine(pokemon1.getNombre() + " pierde " + Diferencia + " puntos de salud. ");
            } else {
                Console.WriteLine(pokemon1.getNombre() + " se defiende con exito. ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("Resultado del combate: ");
        Console.WriteLine();
        if (pokemon1.getSalud() > pokemon2.getSalud()){
            Console.WriteLine("Ha ganado: " + pokemon1.getNombre() );
            Console.WriteLine();
        } else if (pokemon2.getSalud() > pokemon1.getSalud()){
            Console.WriteLine("Ha ganado:  " +pokemon2.getNombre() );
            Console.WriteLine();
        } else {
            Console.WriteLine("Empate en el combate.");
            Console.WriteLine();
        }
    }
    static Pokemon CrearPokemon(){
        Console.WriteLine();
        Console.WriteLine("Ingrese nombre del primer pokemon: ");
        string Nombre = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("Ingrese su tipo de pokemon: ");
        string Tipo = Console.ReadLine();
        Console.WriteLine();
        return new Pokemon (Nombre,Tipo);
    }
    
}
}


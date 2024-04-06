using System;
namespace Juego
{


interface IBasket{
    string Nombre { get; }
    void AgregarJugador(Jugador jugador);
    int RendimientoTotal();
}

class Basket : IBasket{
    private string nombre;
    private List<Jugador> jugadores;

    public Basket(string nombre){
        this.nombre = nombre;
        this.jugadores = new List<Jugador>();
    }

    public string Nombre { get { return nombre; } }

    public void AgregarJugador(Jugador jugador){
        jugadores.Add(jugador);
    }

    public int RendimientoTotal(){
        int Total = 0;
        foreach(var jugador in jugadores){
            Total += jugador.Rendimiento;
        }
        return Total;
    }

    public void ListaJugadores(){
        Console.WriteLine($"Jugadores en el Equipo {nombre}:");
        foreach(var jugador in jugadores){
            Console.WriteLine($"{jugador.Nombre} - Rendimiento: {jugador.Rendimiento}");
        }
    }

}

class Jugador {
    private string nombre;
    private int rendimiento;

    public Jugador(string nombre, int rendimiento){
        this.nombre = nombre;
        this.rendimiento = rendimiento;
    }

    public string Nombre { get { return nombre; } }

    public int Rendimiento { get { return rendimiento; } }

}

class JuegoBaloncesto{
    private Basket Equipo1;
    private Basket Equipo2;
    private Random Aleatorio;

    public JuegoBaloncesto(){
        Console.WriteLine();
        Equipo1 = new Basket("A ");
        Equipo2 = new Basket("B ");
        Aleatorio = new Random();
    }

    public void AgregarEquipos(){
        for(int i = 0; i < 3; i++){
            Equipo1.AgregarJugador(JugadorAleatorio());
            Equipo2.AgregarJugador(JugadorAleatorio());
        }
    }
    
    private Jugador JugadorAleatorio(){
        string[] nombres = { "Jugador1", "Jugador2", "Jugador3", "Jugador4", "Jugador5" };
        string nombre = nombres[Aleatorio.Next(nombres.Length)];
        int rendimiento = Aleatorio.Next(1, 10);
        return new Jugador(nombre, rendimiento);
    }

    public void DeterminarGanador(){
        Console.WriteLine("Equipo A: ");
        Equipo1.ListaJugadores();
        int RendimientoEquipo1 =Equipo1.RendimientoTotal();
        Console.WriteLine($"Rendimiento total del equipo A: {RendimientoEquipo1}");
        Console.WriteLine();

        Console.WriteLine("Equipo B: ");
        Equipo2.ListaJugadores();
        int RendimientoEquipo2 = Equipo2.RendimientoTotal();
        Console.WriteLine($"Rendimiento total del equipo B: {RendimientoEquipo2}");
        Console.WriteLine();

        if(RendimientoEquipo1 > RendimientoEquipo2){
            Console.WriteLine("🥇 Ha ganado el equipo A 🥇");
            Console.WriteLine();
        }
        else if(RendimientoEquipo2 > RendimientoEquipo1){
            Console.WriteLine("🥈 Ha ganado el equipo B 🥈");
            Console.WriteLine();
        }
        else{
            Console.WriteLine("🥇🥈 Es un empate 🥇🥈");
            Console.WriteLine();
        }

    }
}

class Juego{
    static void Main(string[] args){
        JuegoBaloncesto juego = new JuegoBaloncesto();
        juego.AgregarEquipos();
        juego.DeterminarGanador();
    }
}
}
using MarsRovers;

var rover = new MarsRovers.MarsRovers(new Gps(0, 0), new FacingNorth());

while (true)
{
    Console.Clear();
    Console.WriteLine($"       N  📍({rover.GetPosition().X}, {rover.GetPosition().Y})");
    Console.WriteLine("    W  +  E    ");
    Console.WriteLine("       S       ");
    Console.WriteLine(
        $"Posición del Mars Rovers: 🗺️ ({rover.GetPosition().X}, {rover.GetPosition().Y}), Dirección: 🧭 {rover.GetFacing()}");

    Console.WriteLine(
        "Introduzca la secuencia de comandos (f para avanzar, b para retroceder, l para girar a la izquierda, r para girar a la derecha):");
    string commands = Console.ReadLine();
    
    rover.Move(commands.Select(c => c.ToString()).ToArray());
}
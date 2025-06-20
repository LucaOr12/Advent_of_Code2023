using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

const int MaxRed = 12;
const int MaxGreen = 13;
const int MaxBlue = 14;


var input = File.ReadAllText("Input.txt");

int GameSum = 0;
var lines = input.Split('\n');


var config = new Dictionary<string, int> { { "red", 12}, {"green", 13 }, {"blue", 14 } };

foreach (var line in lines)
{
    var mainParts = line.Split(": ");
    var gameId = int.Parse(mainParts[0].Split(" ")[1]);
    var cubes = mainParts[1].Split(new char[] { ';', ',' });
    if (cubes.Any(c =>
    {
        var cubeStringParts = c.Trim().Split(" ");
        var numberOfCubes = int.Parse(cubeStringParts[0]);
        var cubeColor = cubeStringParts[1];
        return config[cubeColor] < numberOfCubes;
    })) continue;
    GameSum += gameId;
}

Console.WriteLine(GameSum);
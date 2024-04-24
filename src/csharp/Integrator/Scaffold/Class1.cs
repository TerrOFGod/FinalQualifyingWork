using System;
using System.IO;

namespace Scaffold;

public static class CodeScaffoldPlugin
{
    public static void ScaffoldCode(string codeType, string outputDirectory)
    {
        switch (codeType)
        {
            case "controller":
                ScaffoldController(outputDirectory);
                break;
            case "model":
                ScaffoldModel(outputDirectory);
                break;
            // Добавьте другие типы кода, если необходимо
            default:
                Console.WriteLine("Неподдерживаемый тип кода.");
                break;
        }
    }

    private static void ScaffoldController(string outputDirectory)
    {
        // Логика генерации кода для контроллера
        // Запись кода в файл в указанной директории
    }

    private static void ScaffoldModel(string outputDirectory)
    {
        // Логика генерации кода для модели
        // Запись кода в файл в указанной директории
    }
}

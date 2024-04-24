// Scaffold.cpp : Определяет функции для статической библиотеки.
//

#include "pch.h"
#include "framework.h"


#include <iostream>
#include <fstream>

// TODO: Это пример библиотечной функции.
void fnScaffold()
{
}

class CodeScaffoldPlugin
{
public:
    static void ScaffoldCode(const std::string& codeType, const std::string& outputDirectory)
    {
        if (codeType == "controller")
        {
            ScaffoldController(outputDirectory);
        }
        else if (codeType == "model")
        {
            ScaffoldModel(outputDirectory);
        }
        else
        {
            std::cout << "Неподдерживаемый тип кода." << std::endl;
        }
    }

private:
    static void ScaffoldController(const std::string& outputDirectory)
    {
        // Логика генерации кода для контроллера
        // Запись кода в файл в указанной директории
    }

    static void ScaffoldModel(const std::string& outputDirectory)
    {
        // Логика генерации кода для модели
        // Запись кода в файл в указанной директории
    }
};

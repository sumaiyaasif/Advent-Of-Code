using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace AventoOfCode.Day17
{
    static class Day17
    {
        public static void Part1()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Day17/input.txt");
            string[] lines = File.ReadAllLines(path);
            List<List<List<char>>> cube = new List<List<List<char>>>(){
                new List<List<char>>()
            };
            foreach (var line in lines)
            {
                cube[0].Add(line.ToCharArray().ToList());
            }
            
            

            printCube(cube);
            addPadding(cube);
            addPadding(cube);
            addPadding(cube);
            Console.WriteLine("--------------------");
            printCube(cube);
        }

        public static void addPadding(List<List<List<char>>> cube){
            
            List<char> emptyRow = new List<char>();
            for (int i = 0; i < cube[0][0].Count; i++)
            {
                emptyRow.Add('.');
            }

            List<char> emptyCol = new List<char>();
            for (int i = 0; i < cube[0][0].Count; i++)
            {
                emptyCol.Add('.');
            }
            // Add padding to exisiting planes in cube
            foreach (var plane in cube)
            {
                plane.Insert(0, JsonConvert.DeserializeObject<List<char>>(JsonConvert.SerializeObject(emptyRow)));
                plane.Insert(plane.Count, JsonConvert.DeserializeObject<List<char>>(JsonConvert.SerializeObject(emptyRow)));
            }
            foreach (var plane in cube)
            {
                foreach (var element in plane)
                {
                    element.Insert(0, '.');
                    element.Insert(element.Count, '.');
                }
            }
            List<List<char>> emptyPlane = new List<List<char>>();
            for (int i = 0; i < cube[0].Count; i++)
            {
                List<char> row = new List<char>();
                for (int j = 0; j < cube[0][0].Count; j++)
                {
                    row.Add('.');
                }
                emptyPlane.Add(JsonConvert.DeserializeObject<List<char>>(JsonConvert.SerializeObject(row)));
            }
            cube.Insert(0, JsonConvert.DeserializeObject<List<List<char>>>(JsonConvert.SerializeObject(emptyPlane)));
            cube.Insert(cube.Count, JsonConvert.DeserializeObject<List<List<char>>>(JsonConvert.SerializeObject(emptyPlane)));
        }
        public static void printCube(List<List<List<char>>> cube)
        {
            foreach (var plane in cube)
            {
                foreach (var row in plane)
                {
                    foreach (var element in row)
                    {
                        Console.Write(element);
                    }

                    Console.WriteLine();
                }
                Console.WriteLine("******************");
            }
        }


    }
}

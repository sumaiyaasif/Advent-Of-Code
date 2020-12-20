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
            addPadding(cube);
            addPadding(cube);
            addPadding(cube);
            addPadding(cube);
            addPadding(cube);
            addPadding(cube);
            addPadding(cube);
            List<List<List<char>>> newCube = JsonConvert.DeserializeObject<List<List<List<char>>>>(JsonConvert.SerializeObject(cube));

            for (int cycle = 0; cycle < 6; cycle++)
            {
                for (int z = 1; z < cube.Count - 1; z++)
                {
                    for (int x = 1; x < cube[0].Count - 1; x++)
                    {
                        for (int y = 1; y < cube[0][0].Count - 1; y++)
                        {
                            // cube[z][x][y]
                            if (cube[z][x][y] == '#')
                            {
                                var numOfActive = checkNeighbors(cube, z, x, y);
                                if (!(numOfActive == 2 || numOfActive == 3))
                                {
                                    newCube[z][x][y] = '.';
                                }
                            }
                            else if (cube[z][x][y] == '.')
                            {
                                var numOfActive = checkNeighbors(cube, z, x, y);
                                if (numOfActive == 3)
                                {
                                    newCube[z][x][y] = '#';
                                }
                            }
                        }
                    }
                }
                cube = JsonConvert.DeserializeObject<List<List<List<char>>>>(JsonConvert.SerializeObject(newCube));
                if (cycle == 5)
                {
                    int answer = 0;
                    // Count active and return
                    for (int z = 0; z < newCube.Count; z++)
                    {
                        for (int x = 0; x < newCube[0].Count; x++)
                        {
                            for (int y = 0; y < newCube[0][0].Count; y++)
                            {
                                if (newCube[z][x][y] == '#')
                                {
                                    answer++;
                                }
                            }
                        }
                    }
                    Console.WriteLine("Cubes Active: " + answer);
                }
            }
        }

        public static int checkNeighbors(List<List<List<char>>> cube, int z, int x, int y)
        {
            int numOfActive = 0;
            // ones in front
            if (cube[z + 1][x][y] == '#')
            {
                numOfActive++;
            }
            if (cube[z + 1][x + 1][y] == '#')
            {
                numOfActive++;
            }
            if (cube[z + 1][x + 1][y + 1] == '#')
            {
                numOfActive++;
            }
            if (cube[z + 1][x][y + 1] == '#')
            {
                numOfActive++;
            }
            if (cube[z + 1][x - 1][y + 1] == '#')
            {
                numOfActive++;
            }
            if (cube[z + 1][x - 1][y - 1] == '#')
            {
                numOfActive++;
            }
            if (cube[z + 1][x][y - 1] == '#')
            {
                numOfActive++;
            }
            if (cube[z + 1][x - 1][y] == '#')
            {
                numOfActive++;
            }
            if (cube[z + 1][x + 1][y - 1] == '#')
            {
                numOfActive++;
            }

            // current one
            if (cube[z][x + 1][y] == '#')
            {
                numOfActive++;
            }
            if (cube[z][x + 1][y + 1] == '#')
            {
                numOfActive++;
            }
            if (cube[z][x][y + 1] == '#')
            {
                numOfActive++;
            }
            if (cube[z][x - 1][y + 1] == '#')
            {
                numOfActive++;
            }
            if (cube[z][x - 1][y - 1] == '#')
            {
                numOfActive++;
            }
            if (cube[z][x][y - 1] == '#')
            {
                numOfActive++;
            }
            if (cube[z][x - 1][y] == '#')
            {
                numOfActive++;
            }
            if (cube[z][x + 1][y - 1] == '#')
            {
                numOfActive++;
            }

            // behind us
            if (cube[z - 1][x][y] == '#')
            {
                numOfActive++;
            }
            if (cube[z - 1][x + 1][y] == '#')
            {
                numOfActive++;
            }
            if (cube[z - 1][x + 1][y + 1] == '#')
            {
                numOfActive++;
            }
            if (cube[z - 1][x][y + 1] == '#')
            {
                numOfActive++;
            }
            if (cube[z - 1][x - 1][y + 1] == '#')
            {
                numOfActive++;
            }
            if (cube[z - 1][x - 1][y - 1] == '#')
            {
                numOfActive++;
            }
            if (cube[z - 1][x][y - 1] == '#')
            {
                numOfActive++;
            }
            if (cube[z - 1][x - 1][y] == '#')
            {
                numOfActive++;
            }
            if (cube[z - 1][x + 1][y - 1] == '#')
            {
                numOfActive++;
            }

            return numOfActive;
        }
        public static void addPadding(List<List<List<char>>> cube)
        {

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

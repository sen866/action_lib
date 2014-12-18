using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace action_game.sources.model.file
{
    public static class FilePathSearcher
    {
        static FilePathSearcher()
        {
            scenarioFileRootPath = "OGamesProject/resources/scenario/";
            unityResourcesScenarioFileRootPath = "scenario/";
        }

        public static string FindPath(FileType type, string file)
        {
            string fullpath = "";

            switch (type)
            {
                case FileType.Scenario:
                    fullpath = scenarioFileRootPath;
                    break;
                case FileType.UnityResourcesScenario:
                    fullpath = unityResourcesScenarioFileRootPath;
                    break;
            }

            fullpath += file;

            return fullpath;
        }

        public enum FileType
        {
            Scenario,
            UnityResourcesScenario,
        }

        static private string scenarioFileRootPath { get; set; }
        static private string unityResourcesScenarioFileRootPath { get; set; }
    }
}

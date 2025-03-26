using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ChessApp.Models.Moves;

namespace ChessApp.Utils
{
    internal static class Serializer
    {
        private static readonly JsonSerializerOptions options = new() { WriteIndented = true };
        private static readonly string path = @"..\..\..\data.json"; // Same place as stockfish.exe

        public static void Write(LinkedList<Move> moves)
        {
            using StreamWriter writer = CreateFile();
            writer.Write(SerializeMoveHistory(moves));
        }

        // public static void Write(... options) { using StreamWriter writer = CreateFile(); Write(SerializeOptions(...)); } // Overload for options

        public static string SerializeMoveHistory(LinkedList<Move> moves)
        {
            return JsonSerializer.Serialize(moves, options);
        }

        public static string SerializeOptions() // Options still need to be implemented, then this can be done
        {
            throw new NotImplementedException();
        }

        public static StreamWriter CreateFile()
        {
            return File.CreateText(path);
        }
    }
}

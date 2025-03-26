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

        private record MoveHistory(LinkedList<string> Moves); // Needed for serialization to generate a better JSON outcome

        public static void Write(LinkedList<Move> moves) // Needs second parameter for options, but as stated below that is not implemented yet
        {
            using StreamWriter writer = CreateFile();
            writer.Write(SerializeMoveHistory(moves));
        }

        public static string SerializeMoveHistory(LinkedList<Move> moves)
        {
            MoveHistory moveData = new(
                Moves: new LinkedList<string>(moves.Select(move => move.ToString()))
            );

            return JsonSerializer.Serialize(moveData, options);
        }

        public static string SerializeOptions() // Options still need to be implemented, then this can be done
        {
            throw new NotImplementedException();
        }

        public static StreamWriter CreateFile()
        {
            return File.CreateText(path);
        }

        public static LinkedList<Move>? DeserializeMoveHistory()
        {
            string json;
            using (StreamReader reader = File.OpenText(path))
            {
                json = reader.ReadToEnd();
            }

            MoveHistory? moveData = JsonSerializer.Deserialize<MoveHistory>(json, options);
            if (moveData == null)
            {
                return null;
            }

            LinkedList<Move> moves = new(moveData.Moves.Select(moveString => new Move(moveString)));
            return moves;
        }
    }
}
